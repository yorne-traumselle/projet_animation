using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class GetMousePosition : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }   

    void Update()
    {
        float mouseX = Mouse.current.position.x.ReadValue();
        float mouseY = Mouse.current.position.y.ReadValue();

        Ray ray = cam.ScreenPointToRay(new Vector3(mouseX, mouseY, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 worldPos = hit.point;

            Debug.Log($"Position souris sur le plan : X={worldPos.x:F2}  Y={worldPos.y:F2}  Z={worldPos.z:F2}");
        }
    }
}