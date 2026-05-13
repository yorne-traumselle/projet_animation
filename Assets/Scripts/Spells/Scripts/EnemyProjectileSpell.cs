using Unity.VisualScripting;
using UnityEngine;
public class EnemyProjectileSpell : Spell
{
    [SerializeField]
    GameObject projectilePrefab;
    [SerializeField]
    float projectileRange = 40f;
    [SerializeField]
    float projectileSpeed = 15f;
    [SerializeField]
    float damage = 10f;

    public override Action OnCast()
    {
        // Debug.Log("Enemy projectile spell casted on " + (Target != null ? Target.name : "no target") + " at position " + PointTarget);

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