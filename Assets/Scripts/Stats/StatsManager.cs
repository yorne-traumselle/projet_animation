
public class StatsManager
{
    Fighter fighter;

    float maxHealth;
    float health;
    float movementSpeed;
    float attackDamage;
    float attackSpeed;

    public StatsManager(Fighter fighter, float maxHealth, float movementSpeed, float attackDamage, float attackSpeed)
    {
        this.fighter = fighter;
        this.maxHealth = maxHealth;
        this.health = maxHealth;
        this.movementSpeed = movementSpeed;
        this.attackDamage = attackDamage;
        this.attackSpeed = attackSpeed;
    }

    public void applyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            fighter.Die();
        }
    }

    public void applyHeal(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}