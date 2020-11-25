using UnityEngine;

namespace enjoythevibes.Path
{
    [CreateAssetMenu(fileName = "PathEntityConfig", menuName = "ClickAndBall-Test/Path/PathEntityConfig", order = 100)]
    public class PathEntityConfig : ScriptableObject 
    {
        [SerializeField] private GameObject wayPointPrefab = default;

        public GameObject WayPointPrefab => wayPointPrefab;    
    }
}