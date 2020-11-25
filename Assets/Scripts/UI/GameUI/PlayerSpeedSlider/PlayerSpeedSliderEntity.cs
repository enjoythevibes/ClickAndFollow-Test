using UnityEngine;
using UnityEngine.UI;
using TMPro;
using enjoythevibes.Player;

namespace enjoythevibes.UI.GameUI
{
    public class PlayerSpeedSliderEntity : MonoBehaviour
    {
        [SerializeField] private PlayerCircleMovementConfig playerCircleMovementConfig = default;
        [SerializeField] private TextMeshProUGUI minValueField = default;
        [SerializeField] private TextMeshProUGUI maxValueField = default;
        private Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
            slider.minValue = playerCircleMovementConfig.MinMovementSpeed;
            slider.maxValue = playerCircleMovementConfig.MaxMovementSpeed;
            var minValueFieldFormat = minValueField.text;
            var maxValueFieldFormat = maxValueField.text;
            minValueField.SetText(minValueFieldFormat, slider.minValue);
            maxValueField.SetText(maxValueFieldFormat, slider.maxValue);
            slider.value = playerCircleMovementConfig.CurrentMovementSpeed;
        }

        private void Start()
        {
            slider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(float value)
        {
            playerCircleMovementConfig.CurrentMovementSpeed = value;
        }
    }
}