using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // Remove SerializeField when done
    [SerializeField] private Image progressBar;
    [SerializeField] private float currentValue = 0f;
    [SerializeField] private float maxValue = 100f;
    [SerializeField] public float barWidth = 200f; // Size of the progress bar when full in Unity units
    [SerializeField] public float xOffset = 0f; // Use this to adjust the x position in the scene

    private bool isPaused = false;

    private RectTransform barTransform;

    void Start() {
        barTransform = progressBar.rectTransform;
    }

    // Constantly update progress bar to new value set externally
    void Update() {
        if (!isPaused) {
            UpdateProgressBar(currentValue);
            currentValue = Mathf.Clamp(currentValue, 0f, maxValue);
        } 
    }

    public void UpdateProgressBar(float newValue) {
        // Adjusting the width of the progress bar
        float fillAmount = newValue / maxValue;
        barTransform.sizeDelta = new Vector2(barWidth * fillAmount, barTransform.sizeDelta.y);
    
        // Adjusting the position of the progress bar so it only extends to the right
        float newPos = (-barWidth + barTransform.sizeDelta.x) / 2 + xOffset;
        barTransform.anchoredPosition = new Vector2(newPos, barTransform.anchoredPosition.y);
    }

    public void PauseBar() {
        isPaused = true;
    }

    public void UnpauseBar() {
        isPaused = false;
    }

    public void ResetBar() {
        currentValue = 0f;
    }

    public void SetMaxValue(int newMax) {
        maxValue = newMax;
    }

    public void Increment() {
        currentValue += 1f;
    }
}
