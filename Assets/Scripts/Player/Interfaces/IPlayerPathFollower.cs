using UnityEngine;

namespace enjoythevibes.Player
{
    public delegate void OnPlayerPathUpdateEvent();
    public interface IPlayerPathFollower
    {
        Vector3 CurrentDestinationPosition { get; }
        bool HasDestination { get; }

        event OnPlayerPathUpdateEvent OnPlayerPathUpdate;

        void SetDestination(Vector3 position);
    }
}