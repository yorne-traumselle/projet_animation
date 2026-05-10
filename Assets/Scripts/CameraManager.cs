using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    GameObject myCamera;
    GameObject player;

    void Start()
    {
        myCamera = Camera.main.gameObject;
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
        target = player.transform;
    }

    void Update()
    {
        if (player != null)
        {
            gameObject.transform.position = player.transform.position;
        }
    }
}