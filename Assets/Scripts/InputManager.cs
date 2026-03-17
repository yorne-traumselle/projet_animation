using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;
using Actions;

public class InputManager : MonoBehaviour
{
    public Camera cam;
    Vector3 worldPos;

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
            worldPos = hit.point;   
        }
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            GetComponent<Fighter>().ChangeAction(new WalkAction(GetComponent<Fighter>(), new Vector3(worldPos.x, 0, worldPos.z)));
        }
    }
}