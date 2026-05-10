using UnityEngine;

public class PauseButton: MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenuprefab;

    private void Start()
    {
        // Anchor button to top-left
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 1);  // top-left
        rectTransform.anchorMax = new Vector2(0, 1);  // top-left
        rectTransform.pivot = new Vector2(0, 1);      // pivot at top-left
        rectTransform.anchoredPosition = Vector2.zero;  // position at (0, 0)
    }

    public void OnClick()
    {
        if (pauseMenuprefab != null)
        {
            Instantiate(pauseMenuprefab, Vector3.zero, Quaternion.identity);
        }
    }
}