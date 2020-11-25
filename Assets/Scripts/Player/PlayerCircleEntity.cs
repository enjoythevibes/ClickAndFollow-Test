using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enjoythevibes.Player
{
    public class PlayerCircleEntity : MonoBehaviour, IPlayerCircleEntity
    {
        private Transform playerTransform;
        public Transform PlayerTransform => playerTransform;

        private void Awake()
        {
            playerTransform = transform;
        }
    }
}