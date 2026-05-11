
using UnityEngine;

public class StatsManager
{
    Fighter fighter;

    float maxHealth;
    float health;
    float movementSpeed;
    float attackDamage;
    float attackSpeed;

    public float MovementSpeed
    {
        get { return movementSpeed; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
    }

    public float Health
    {
        get { return health; }
    }

    public StatsManager(Fighter fighter, float maxHealth, float movementSpeed, float attackDamage, float attackSpeed)
    {
        this.fighter = fighter;
        this.maxHealth = maxHealth;
        this.health = maxHealth;
        this.movementSpeed = movementSpeed;
        this.attackDamage = attackDamage;
        this.attackSpeed = attackSpeed;
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        // Debug.Log($"Fighter took {damage} damage, current health: {health}");
        if (health <= 0)
        {
            health = 0;
            fighter.Die();
        }
    }

    public void ApplyHeal(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}