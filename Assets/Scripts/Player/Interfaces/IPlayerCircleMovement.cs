using UnityEngine;

namespace enjoythevibes.Player
{
    public interface IPlayerCircleMovement
    {
        float MovementSpeed { get; }

        void Move(Vector3 position);
    }
}