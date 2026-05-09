using UnityEngine;
public class TestSpell : Spell
{
    [SerializeField]
    GameObject projectilePrefab;

    public override Action OnCast()
    {
        Debug.Log("Test spell casted on " + (Target != null ? Target.name : "no target") + " at position " + PointTarget);

        GameObject projectile = Instantiate(projectilePrefab, caster.transform.position, Quaternion.identity);
        FightObject fightObject = projectile.GetComponent<FightObject>();
        fightObject.SetDamage(10f);
        fightObject.SetRemoveOnHit(true);
        fightObject.SetCaster(caster);
        if (fightObject != null)
        {
            fightObject.SetTrajectory(new RectilignTrajectory(caster.transform.position, pointTarget, 10f, 5f));
        }
        return new DefaultAction(caster);
    }
}