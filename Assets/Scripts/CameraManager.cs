using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    GameObject myCamera;
    [SerializeField]
    GameObject player;

    void Start()
    {
        myCamera = Camera.main.gameObject;
    }

    void Update()
    {
        gameObject.transform.position = player.transform.position;
    }
}