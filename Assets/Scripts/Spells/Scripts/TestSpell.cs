using UnityEngine;
public class TestSpell : Spell
{
    [SerializeField]
    GameObject projectilePrefab;
    [SerializeField]
    float projectileRange = 10f;
    [SerializeField]
    float projectileSpeed = 5f;
    [SerializeField]
    float damage = 10f;

    public override Action OnCast()
    {
        Debug.Log("Test spell casted on " + (Target != null ? Target.name : "no target") + " at position " + PointTarget);

        GameObject projectile = Instantiate(projectilePrefab, caster.transform.position, Quaternion.identity);
        FightObject fightObject = projectile.GetComponent<FightObject>();
        fightObject.SetDamage(damage);
        fightObject.SetRemoveOnHit(true);
        fightObject.SetCaster(caster);
        if (fightObject != null)
        {
            fightObject.SetTrajectory(new RectilignTrajectory(caster.transform.position, pointTarget, projectileRange, projectileSpeed));
        }
        return new DefaultAction(caster);
    }
}