using UnityEngine;

public class EnemyMeleeSpell : Spell
{
    [SerializeField]
    GameObject objectPrefab;
    [SerializeField]
    float damage = 50f;

    public override Action OnCast()
    {
        Debug.Log("Ult spell casted");

        GameObject projectile = Instantiate(objectPrefab, caster.transform.position, Quaternion.identity);
        FightObject fightObject = projectile.GetComponent<FightObject>();
        fightObject.SetCaster(caster);
        fightObject.SetDamage(damage);
        fightObject.SetLifetime(.5f);
        return new DefaultAction(caster);
    }
}