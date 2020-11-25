using UnityEngine;

namespace enjoythevibes.WayPoint
{
    [RequireComponent(typeof(Animator))]
    public class WayPointAnimation : MonoBehaviour
    {
        private IWayPointEntity wayPointEntity;
        private Animator animator;
        [SerializeField] private string hideParameterTrigger = "Hide";

        private void Awake()
        {
            wayPointEntity = GetComponent<IWayPointEntity>();
            animator = GetComponent<Animator>();
            wayPointEntity.OnDestroyWayPoint += OnDestroyWayPoint;
        }

        private void OnDestroy()
        {
            wayPointEntity.OnDestroyWayPoint -= OnDestroyWayPoint;
        }

        private void OnDestroyWayPoint()
        {
            animator.SetTrigger(hideParameterTrigger);
        }
    }
}