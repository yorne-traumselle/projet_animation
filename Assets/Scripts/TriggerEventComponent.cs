using UnityEngine;
using UnityEngine.Events;

public class TriggerEventComponent : MonoBehaviour
{
    public UnityEvent OnTriggerEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fighter>() != null)
        {
            OnTriggerEnterEvent.Invoke();
        }
    }
}