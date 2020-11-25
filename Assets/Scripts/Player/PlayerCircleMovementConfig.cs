using UnityEngine;

namespace enjoythevibes.Player
{
    [CreateAssetMenu(fileName = "PlayerCircleMovementConfig", menuName = "ClickAndBall-Test/Player/PlayerCircleMovementConfig", order = 101)]
    public class PlayerCircleMovementConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private float defaultMovementSpeed = 3f;
        [SerializeField] private float minMovementSpeed = 1f;
        [SerializeField] private float maxMovementSpeed = 10f;

        public float DefaultMovementSpeed => defaultMovementSpeed;
        public float MinMovementSpeed => minMovementSpeed;
        public float MaxMovementSpeed => maxMovementSpeed;
        public float CurrentMovementSpeed { set; get; }

        public void OnAfterDeserialize()
        {
            CurrentMovementSpeed = defaultMovementSpeed;
        }

        public void OnBeforeSerialize()
        {
        }   
    }
}