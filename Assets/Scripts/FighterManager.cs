using UnityEngine;
using System.Collections.Generic;

public class FighterManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    GameObject rangeEnemyPrefab;

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

    List<Fighter> enemies;
    Stage currentStage = Stage.Stage1;
    
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
        AddRangeEnemy(new Vector3(5, 0, 0));
        AddRangeEnemy(new Vector3(-5, 0, 0));        
    }

    public void Stage2()
    {
        AddRangeEnemy(new Vector3(5, 0, -150));
        AddRangeEnemy(new Vector3(-5, 0, -150));        
    }

    public void Stage3()
    {
        AddRangeEnemy(new Vector3(5, 0, -300));
        AddRangeEnemy(new Vector3(-5, 0, -300));        
    }

    void AddRangeEnemy(Vector3 position)
    {
        Fighter rangeEnemy = Instantiate(rangeEnemyPrefab, position, Quaternion.identity).GetComponent<Fighter>();
        rangeEnemy.SetFighterManager(this);
        enemies.Add(rangeEnemy);
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
