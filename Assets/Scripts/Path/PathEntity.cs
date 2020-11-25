using System.Collections;
using System.Collections.Generic;
using enjoythevibes.WayPoint;
using UnityEngine;

namespace enjoythevibes.Path
{
    public class PathEntity : MonoBehaviour, IPathEntity
    {
        [SerializeField] private PathEntityConfig pathEntityConfig = default;
        private List<IWayPointEntity> wayPointVerticies = new List<IWayPointEntity>();

        public event OnPathUpdateEvent OnPathUpdate;

        public int VertexCount => wayPointVerticies.Count;
        public IWayPointEntity GetWayPointByIndex(int index) => wayPointVerticies[index];
    
        private bool IntersectsAnyPoint(Vector3 position)
        {
            var intersects = false;
            for (int i = 0; i < wayPointVerticies.Count; i++)
            {
                if ((position - wayPointVerticies[i].WayPointPosition).magnitude < wayPointVerticies[i].WayPointRadius * 2f)
                {
                    intersects = true;
                }
            }
            return intersects;
        }

        public bool TryAddPoint(Vector3 position)
        {
            var intersects = IntersectsAnyPoint(position);
            if (intersects)
                return false;
            var wayPointGameObject = Instantiate(pathEntityConfig.WayPointPrefab, position, pathEntityConfig.WayPointPrefab.transform.rotation);
            wayPointVerticies.Add(wayPointGameObject.GetComponent<IWayPointEntity>());
            OnPathUpdate?.Invoke();
            return true;
        }

        public void RemovePoint(int index)
        {
            if (wayPointVerticies.Count > index && index > -1)
            {
                wayPointVerticies[index].DestroyWayPoint();
                wayPointVerticies.RemoveAt(index);
                OnPathUpdate?.Invoke();
            }
            else
            {
                Debug.LogError($"Error: WayPoint with index {index} doesnt exist.");
            }
        }
    }
}