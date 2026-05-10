using Unity.VisualScripting;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    FighterManager fighter_manager;

    [SerializeField]
    GameObject CurrentStage;

    [SerializeField]
    GameObject Stage2Prefab;

    [SerializeField]
    GameObject Stage3Prefab;

    [SerializeField]
    GameObject Path1Prefab;
    [SerializeField]
    GameObject Path2Prefab;

    [SerializeField]
    TriggerEventComponent Trigger1;
    [SerializeField]
    TriggerEventComponent Trigger2;
    [SerializeField]
    TriggerEventComponent Trigger3;
    [SerializeField]
    TriggerEventComponent Trigger4;

    GameObject CurrentPath;

    void Start()
    {
        Trigger1.OnTriggerEnterEvent.AddListener(OnTrigger1);
        Trigger2.OnTriggerEnterEvent.AddListener(OnTrigger2);
        Trigger3.OnTriggerEnterEvent.AddListener(OnTrigger3);
        Trigger4.OnTriggerEnterEvent.AddListener(OnTrigger4);
    }

    void OnTrigger1()
    {
        Debug.Log("Trigger1");
        Destroy(CurrentStage);
        CurrentStage =  Instantiate(Stage2Prefab, new Vector3(1.0f, 0, -140.0f), Quaternion.identity);
        
    }
    void OnTrigger2()
    {
        Debug.Log("Trigger2");
        Destroy(CurrentPath);
        fighter_manager.Stage2();
    }

    void OnTrigger3()
    {
        Destroy(CurrentStage);
        CurrentStage = Instantiate(Stage3Prefab, new Vector3(1.0f, 0, -279.6f), Quaternion.identity);
    }

    void OnTrigger4()
    {
        Destroy(CurrentPath);
        CurrentStage = Instantiate(Stage3Prefab, new Vector3(1.0f, 0, -279.6f), Quaternion.identity);
        fighter_manager.Stage3();
    }

    public void InitPath1()
    {
        CurrentPath = Instantiate(Path1Prefab, new Vector3(0, 0, -70.0f), Quaternion.identity);
    }

    public void InitPath2()
    {
        CurrentPath = Instantiate(Path2Prefab, new Vector3(0, 0, -210.1f), Quaternion.identity);
    }
}