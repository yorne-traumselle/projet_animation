using UnityEngine;
using UnityEngine.Events;

public class TriggerEventComponent : MonoBehaviour
{
    public UnityEvent OnTriggerEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent.Invoke();
    }
}