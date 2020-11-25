using System.Linq;
using enjoythevibes.Path;
using UnityEngine;

namespace enjoythevibes.Player
{
    public class PlayerInputClick : MonoBehaviour
    {
        private IPlayerPathFollower playerPathFollower;
        private IPathEntity pathEntity;
        private Camera mainCamera;
        private Plane virtualPlane;
        private Bounds cameraBounds;

        private void Awake()
        {
            playerPathFollower = GetComponent<IPlayerPathFollower>();
            pathEntity = FindObjectsOfType<MonoBehaviour>().OfType<IPathEntity>().FirstOrDefault();
            mainCamera = Camera.main;
            virtualPlane.SetNormalAndPosition(Vector3.forward, new Vector3(0f, 0f, 0f));
            var screenAspect = (float)Screen.width / (float)Screen.height;
            var cameraHeight = mainCamera.orthographicSize * 2;
            cameraBounds = new Bounds(new Vector3(0f, 0f, 0f), new Vector3(cameraHeight * screenAspect - 1f, cameraHeight - 1f, 0f));
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying == false) return;
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(cameraBounds.center, cameraBounds.size);
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                var playerTouch = Input.GetTouch(0);
                if (playerTouch.phase == TouchPhase.Began && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(0))
                {
                    var ray = mainCamera.ScreenPointToRay(playerTouch.position);
                    virtualPlane.Raycast(ray, out var distance);
                    var clickedPosition = ray.GetPoint(distance);
                    if (cameraBounds.Contains(clickedPosition))
                    {
                        if (pathEntity.TryAddPoint(clickedPosition))
                        {
                            if (playerPathFollower.HasDestination == false)
                            {
                                playerPathFollower.SetDestination(pathEntity.GetWayPointByIndex(0).WayPointPosition);
                            }
                        }
                    }

                }
            }
        }
    }
}