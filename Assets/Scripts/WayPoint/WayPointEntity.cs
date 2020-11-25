using UnityEngine;

namespace enjoythevibes.WayPoint
{
    public class WayPointEntity : MonoBehaviour, IWayPointEntity
    {
        [SerializeField] private float radius = 0.25f;
        [SerializeField] private float destroyDelay = 0.5f;

        public Vector3 WayPointPosition => transform.position;
        public float WayPointRadius => radius;

        public event OnDestroyWayPointEvent OnDestroyWayPoint;

        public void DestroyWayPoint()
        {
            Destroy(gameObject, destroyDelay);
            OnDestroyWayPoint?.Invoke();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}