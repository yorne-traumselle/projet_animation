using UnityEngine;

public class HealthbarSizeManager : MonoBehaviour
{
    static float currentSize = 1f;
    static float currentValue = 0f;

    static public void setSize(float value)
    {
        currentSize = 1f + value * 2f; // Scale from 1 to 3
        Debug.Log("Healthbar size set to: " + currentSize);
        currentValue = value;
    }

    static public float getValue()
    {
        return currentValue;
    }

    void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(currentSize, currentSize, currentSize);
    }
}