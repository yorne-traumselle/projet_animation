using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

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
        
        int spellIndex = -1;
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            spellIndex = 0;
        }
        else if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            spellIndex = 1;
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            spellIndex = 2;
        }
        else if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            spellIndex = 3;
        }

        if (spellIndex != -1)
        {
            GetComponent<Fighter>().SpellManager.Cast(spellIndex, null, worldPos);
            Debug.Log("Casting spell at index: " + spellIndex);
        }
    }
}