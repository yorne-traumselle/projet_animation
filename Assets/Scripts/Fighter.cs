using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

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
    SpellManager spellManager;
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

    [SerializeField]
    float height = 4f;
    [SerializeField]
    float radius = 0.5f;

    [SerializeField]
    GameObject healthBarPrefab;
    Slider healthBarSlider;

    public StatsManager Stats { get { return statsManager; } }
    public SpellManager SpellManager { get { return spellManager; } }

    void Start()
    {
        moveManager = new MoveManager(this);
        actionManager = new ActionManager(this);
        statsManager = new StatsManager(this, maxHealth, movementSpeed, attackDamage, attackSpeed);
        spellManager = gameObject.AddComponent<SpellManager>();
        spellManager.Init(this, spellPrefabs, passivePrefabs);

        InitCollider();

        if (healthBarPrefab != null)
        {
            GameObject healthBar = Instantiate(healthBarPrefab, transform);
            healthBarSlider = healthBar.GetComponentInChildren<Slider>();
        }

    }

    void InitCollider()
    {
        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<CapsuleCollider>();
        }
        collider.height = height;
        collider.radius = radius;
        collider.isTrigger = true;

        // Ensure trigger events are generated
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = true;
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    
    }

    void Update()
    {
        moveManager.Update();
        actionManager.Update();   

        if (healthBarSlider != null)
        {
            healthBarSlider.transform.LookAt(Camera.main.transform);
            healthBarSlider.transform.Rotate(0, 180, 0); // Flip to face the camera
            healthBarSlider.value = statsManager.Health / statsManager.MaxHealth;
        }
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

    public void ApplyDamage(float damage)
    {
            statsManager.ApplyDamage(damage);
    }
}
