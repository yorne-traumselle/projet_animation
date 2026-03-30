using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float percent = 1f;

    void Start()
    {
        SetHealthPercent(percent);
    }

    public void SetHealthPercent(float percent)
    {
        percent = Mathf.Clamp01(percent);
        fillImage.fillAmount = percent;
    }

}
