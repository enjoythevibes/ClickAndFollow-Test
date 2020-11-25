using UnityEngine;

namespace enjoythevibes.Player
{
    [RequireComponent(typeof(LineRenderer))]
    public class PlayerPathDrawer : MonoBehaviour
    {
        private IPlayerCircleEntity playerCircleEntity;
        private IPlayerPathFollower playerPathFollower;
        private LineRenderer lineRenderer;

        private void Awake()
        {
            playerCircleEntity = GetComponent<IPlayerCircleEntity>();
            playerPathFollower = GetComponent<IPlayerPathFollower>();
            lineRenderer = GetComponent<LineRenderer>();
            playerPathFollower.OnPlayerPathUpdate += OnPlayerPathUpdate;
        }

        private void OnDestroy()
        {
            playerPathFollower.OnPlayerPathUpdate -= OnPlayerPathUpdate;
        }

        private void OnPlayerPathUpdate()
        {
            if (playerPathFollower.HasDestination == false)
            {
                lineRenderer.positionCount = 0;
            }
            else
            {
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, playerCircleEntity.PlayerTransform.position);
                lineRenderer.SetPosition(1, playerPathFollower.CurrentDestinationPosition);
            }
        }
    }
}