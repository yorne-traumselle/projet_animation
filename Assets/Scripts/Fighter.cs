using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public enum FighterState
{
    Alive,
    Cadaver,
    Dead
}

public class Fighter : MonoBehaviour
{
    MoveManager moveManager;
    ActionManager actionManager;
    StatsManager statsManager;
    FighterState state = FighterState.Alive;

    [SerializeField]
    float maxHealth = 100f;
    [SerializeField]
    float movementSpeed = 5f;
    [SerializeField]
    float attackDamage = 10f;
    [SerializeField]
    float attackSpeed = 1f;

    [SerializeField]
    GameObject[] spellPrefabs;
    [SerializeField]
    GameObject[] passivePrefabs;

    public StatsManager Stats { get { return statsManager; } }

    void Start()
    {
        moveManager = new MoveManager(this);
        actionManager = new ActionManager(this);
        statsManager = new StatsManager(this, maxHealth, movementSpeed, attackDamage, attackSpeed);
    }

    void Update()
    {
        moveManager.Update();
        actionManager.Update();   
    }

    public void ChangeAction(Action newAction)
    {
        actionManager.ChangeAction(newAction);
    }

    public void ChangeMove(Move newMove)
    {
        moveManager.ChangeMove(newMove);
    }

    public void Die()
    {
        Debug.Log("Fighter has died.");
        state = FighterState.Dead;
        // Implement death logic here (e.g., play animation, disable fighter, etc.)
    }

    public bool IsAlive()
    {
        return state == FighterState.Alive;
    }
}
