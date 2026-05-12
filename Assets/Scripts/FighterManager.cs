using UnityEngine;
using System.Collections.Generic;

public class FighterManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    GameObject rangeEnemyPrefab;
    [SerializeField]
    Fighter meleeEnemyPrefab;

    [SerializeField]
    Fighter healerEnemyPrefab;

    [SerializeField]
    CameraManager camera_manager;

    [SerializeField]
    StageManager stage_manager;

    [SerializeField]
    GameObject winMenuPrefab;

    [SerializeField]
    GameObject deathMenuPrefab;

    Fighter player;
    public Fighter Player => player;

    public List<Fighter> enemies;
    public Stage currentStage = Stage.Stage1;
    
    void Start()
    {
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Fighter>();
        player.SetFighterManager(this);
        camera_manager.SetPlayer(player.gameObject);

        enemies = new List<Fighter>();
        Stage1();
    }

    void Stage1()
    {
        AddRangeEnemy(new Vector3(50, 0, 0));
        AddRangeEnemy(new Vector3(-50, 0, 0));
        AddMeleeEnemy(new Vector3(0, 0, -50));    
    }

    public void Stage2()
    {
        // 4 range enemies on each angle
        AddRangeEnemy(new Vector3(50, 0, 50) + stage_manager.stage2Center);
        AddRangeEnemy(new Vector3(-50, 0, -50) + stage_manager.stage2Center);
        AddRangeEnemy(new Vector3(-50, 0, 50) + stage_manager.stage2Center);
        AddRangeEnemy(new Vector3(50, 0, -50) + stage_manager.stage2Center);

        // 2 melee enemies in the middle
        AddMeleeEnemy(new Vector3(10, 0, 0) + stage_manager.stage2Center);
        AddMeleeEnemy(new Vector3(-10, 0, 0) + stage_manager.stage2Center);

        // 1 healer enemy in the back
        AddHealerEnemy(new Vector3(0, 0, -50) + stage_manager.stage2Center);    
    }

    public void Stage3()
    {
        // 6 shooters on the sides
        AddRangeEnemy(new Vector3(50, 0, 50) + stage_manager.stage3Center);
        AddRangeEnemy(new Vector3(-50, 0, -50) + stage_manager.stage3Center);
        AddRangeEnemy(new Vector3(-50, 0, 50) + stage_manager.stage3Center);
        AddRangeEnemy(new Vector3(50, 0, -50) + stage_manager.stage3Center);
        AddRangeEnemy(new Vector3(50, 0, 0) + stage_manager.stage3Center);
        AddRangeEnemy(new Vector3(-50, 0, 0) + stage_manager.stage3Center);

        // 4 melee enemies in the middle
        AddMeleeEnemy(new Vector3(10, 0, 0) + stage_manager.stage3Center);
        AddMeleeEnemy(new Vector3(20, 0, 0) + stage_manager.stage3Center);
        AddMeleeEnemy(new Vector3(-10, 0, 0) + stage_manager.stage3Center);
        AddMeleeEnemy(new Vector3(-20, 0, 0) + stage_manager.stage3Center);

        // 3 healer enemies in the back
        AddHealerEnemy(new Vector3(0, 0, -50) + stage_manager.stage3Center);
        AddHealerEnemy(new Vector3(-10, 0, -50) + stage_manager.stage3Center);
        AddHealerEnemy(new Vector3(10, 0, -50) + stage_manager.stage3Center);
    }

    void AddMeleeEnemy(Vector3 position)
    {
        Fighter meleeEnemy = Instantiate(meleeEnemyPrefab, position, Quaternion.identity);
        meleeEnemy.SetFighterManager(this);
        enemies.Add(meleeEnemy);
    }

    void AddRangeEnemy(Vector3 position)
    {
        Fighter rangeEnemy = Instantiate(rangeEnemyPrefab, position, Quaternion.identity).GetComponent<Fighter>();
        rangeEnemy.SetFighterManager(this);
        enemies.Add(rangeEnemy);
    }

    void AddHealerEnemy(Vector3 position)
    {
        Fighter healerEnemy = Instantiate(healerEnemyPrefab, position, Quaternion.identity).GetComponent<Fighter>();
        healerEnemy.SetFighterManager(this);
        enemies.Add(healerEnemy);
    }

    void Update()
    {
        if (player.FighterState == FighterState.Dead)
        {
            if (deathMenuPrefab != null && currentStage != Stage.Death)
            {
                Debug.Log("Player defeated!");
                currentStage = Stage.Death;
                Instantiate(deathMenuPrefab, Vector3.zero, Quaternion.identity);
            }
        }

        List<Fighter> toRemove = new List<Fighter>();
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].FighterState == FighterState.Dead)
            {
                toRemove.Add(enemies[i]);
            }
        }

        if (toRemove.Count > 0)
        {
            foreach (var enemy in toRemove)
            {
                enemies.Remove(enemy);
                Destroy(enemy.gameObject);
            }

            if (enemies.Count == 0)
            {
                Debug.Log("All enemies defeated!");
                switch (currentStage)
                {
                    case Stage.Stage1:
                        stage_manager.InitPath1();
                        currentStage = Stage.Stage2;
                        break;
                    case Stage.Stage2:
                        stage_manager.InitPath2();
                        currentStage = Stage.Stage3;
                        break;
                    case Stage.Stage3:
                        Debug.Log("Game Completed!");
                        if (winMenuPrefab != null)
                        {
                            Instantiate(winMenuPrefab, Vector3.zero, Quaternion.identity);
                        }
                        break;
                }
            }
        }
    }
}

public enum Stage
{
    Stage1,
    Stage2,
    Stage3,
    Death
}
