
using UnityEngine;

public class StatsManager
{
    Fighter fighter;

    float maxHealth;
    float health;
    float movementSpeed;

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

    public StatsManager(Fighter fighter, float maxHealth, float movementSpeed)
    {
        this.fighter = fighter;
        this.maxHealth = maxHealth;
        health = maxHealth;
        this.movementSpeed = movementSpeed;
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