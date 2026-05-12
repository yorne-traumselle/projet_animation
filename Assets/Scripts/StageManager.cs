using Unity.VisualScripting;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    FighterManager fighter_manager;

    [SerializeField]
    GameObject CurrentStage;

    [SerializeField]
    GameObject StagePrefab;

    [SerializeField]
    GameObject PathPrefab;

    [SerializeField]
    TriggerEventComponent Trigger1;
    [SerializeField]
    TriggerEventComponent Trigger2;
    [SerializeField]
    TriggerEventComponent Trigger3;
    [SerializeField]
    TriggerEventComponent Trigger4;

    GameObject CurrentPath;

    public Vector3 stage2Center = new Vector3(1.0f, 0, -140.0f);
    public Vector3 stage3Center = new Vector3(1.0f, 0, -279.6f);

    void Start()
    {
        Trigger1.OnTriggerEnterEvent.AddListener(OnTrigger1);
        Trigger2.OnTriggerEnterEvent.AddListener(OnTrigger2);
        Trigger3.OnTriggerEnterEvent.AddListener(OnTrigger3);
        Trigger4.OnTriggerEnterEvent.AddListener(OnTrigger4);
    }

    void OnTrigger1()
    {
        if (fighter_manager.currentStage != Stage.Stage2)
            return;
        Debug.Log("Trigger1");
        Destroy(CurrentStage);
        CurrentStage =  Instantiate(StagePrefab, stage2Center, Quaternion.identity);
        Trigger1.OnTriggerEnterEvent.RemoveListener(OnTrigger1);
        
    }
    void OnTrigger2()
    {
        if (fighter_manager.currentStage != Stage.Stage2)
            return;
        Debug.Log("Trigger2");
        Destroy(CurrentPath);
        fighter_manager.Stage2();
        Trigger2.OnTriggerEnterEvent.RemoveListener(OnTrigger2);
    }

    void OnTrigger3()
    {
        if (fighter_manager.currentStage != Stage.Stage3)
            return;
        Destroy(CurrentStage);
        CurrentStage = Instantiate(StagePrefab, stage3Center, Quaternion.identity);
        Trigger3.OnTriggerEnterEvent.RemoveListener(OnTrigger3);
    }

    void OnTrigger4()
    {
        if (fighter_manager.currentStage != Stage.Stage3)
            return;
        Destroy(CurrentPath);
        fighter_manager.Stage3();
        Trigger4.OnTriggerEnterEvent.RemoveListener(OnTrigger4);
    }

    public void InitPath1()
    {
        CurrentPath = Instantiate(PathPrefab, new Vector3(0, 0, -70.0f), Quaternion.identity);
    }

    public void InitPath2()
    {
        CurrentPath = Instantiate(PathPrefab, new Vector3(0, 0, -210.1f), Quaternion.identity);
    }
}