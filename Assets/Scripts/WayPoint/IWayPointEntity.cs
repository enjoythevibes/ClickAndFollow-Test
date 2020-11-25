using UnityEngine;

namespace enjoythevibes.WayPoint
{
    public delegate void OnDestroyWayPointEvent();
    public interface IWayPointEntity
    {
        Vector3 WayPointPosition { get; }
        float WayPointRadius { get; }
        event OnDestroyWayPointEvent OnDestroyWayPoint;
        void DestroyWayPoint();
    }
}