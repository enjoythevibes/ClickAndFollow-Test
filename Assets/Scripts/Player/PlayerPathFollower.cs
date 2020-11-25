using System.Linq;
using enjoythevibes.Path;
using UnityEngine;

namespace enjoythevibes.Player
{
    public class PlayerPathFollower : MonoBehaviour, IPlayerPathFollower
    {
        private IPlayerCircleEntity playerCircleEntity;
        private IPlayerCircleMovement playerCircleMovement;
        
        private IPathEntity pathEntity;
        private bool hasDestination;
        private Vector3 currentDestinationPosition;

        public event OnPlayerPathUpdateEvent OnPlayerPathUpdate;

        public bool HasDestination => hasDestination;
        public Vector3 CurrentDestinationPosition => currentDestinationPosition;


        private void Awake()
        {
            pathEntity = FindObjectsOfType<MonoBehaviour>().OfType<IPathEntity>().FirstOrDefault();
            playerCircleEntity = GetComponent<IPlayerCircleEntity>();
            playerCircleMovement = GetComponent<IPlayerCircleMovement>();
        }

        public void SetDestination(Vector3 position)
        {
            currentDestinationPosition = position;
            hasDestination = true;
        }

        private void Update()
        {
            if (hasDestination)
            {
                var playerTransform = playerCircleEntity.PlayerTransform;
                playerCircleMovement.Move(currentDestinationPosition);
                if ((playerTransform.position - currentDestinationPosition).sqrMagnitude < 0.00001f)
                {
                    pathEntity.RemovePoint(0);
                    if (pathEntity.VertexCount == 0)
                    {
                        hasDestination = false;
                    }
                    else
                    {
                        SetDestination(pathEntity.GetWayPointByIndex(0).WayPointPosition);
                    }
                }
                OnPlayerPathUpdate?.Invoke();
            }
        }
    }
}