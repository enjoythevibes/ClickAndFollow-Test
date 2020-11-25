using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enjoythevibes.Player
{
    public class PlayerCircleMovement : MonoBehaviour, IPlayerCircleMovement
    {
        [SerializeField] private PlayerCircleMovementConfig playerCircleMovementConfig = default;
        private IPlayerCircleEntity playerCircleEntity;

        public float MovementSpeed => playerCircleMovementConfig.CurrentMovementSpeed;

        private void Awake()
        {
            playerCircleEntity = GetComponent<IPlayerCircleEntity>();
        }

        public void Move(Vector3 targetPosition)
        {
            var playerTransform = playerCircleEntity.PlayerTransform;
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, targetPosition, Time.deltaTime * playerCircleMovementConfig.CurrentMovementSpeed);
        }
    }
}