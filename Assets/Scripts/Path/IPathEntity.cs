using enjoythevibes.WayPoint;
using UnityEngine;

namespace enjoythevibes.Path
{
    public delegate void OnPathUpdateEvent();
    public interface IPathEntity
    {
        int VertexCount { get; }
        IWayPointEntity GetWayPointByIndex(int index);
        event OnPathUpdateEvent OnPathUpdate;
        void RemovePoint(int index);
        bool TryAddPoint(Vector3 position);
    }
}