using UnityEngine;

namespace enjoythevibes.Path
{
    [RequireComponent(typeof(LineRenderer))]
    public class PathLineDrawer : MonoBehaviour
    {
        private IPathEntity pathEntity;
        private LineRenderer lineRenderer;

        private void Awake()
        {
            pathEntity = GetComponent<IPathEntity>();
            lineRenderer = GetComponent<LineRenderer>();
            pathEntity.OnPathUpdate += OnPathUpdate;
        }

        private void OnDestroy()
        {
            pathEntity.OnPathUpdate -= OnPathUpdate;
        }

        private void OnPathUpdate()
        {
            lineRenderer.positionCount = pathEntity.VertexCount;
            for (int i = 0; i < pathEntity.VertexCount; i++)
            {
                lineRenderer.SetPosition(i, pathEntity.GetWayPointByIndex(i).WayPointPosition);
            }
        }
    }
}