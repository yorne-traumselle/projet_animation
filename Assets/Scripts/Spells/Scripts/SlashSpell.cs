using UnityEngine;
public class SlashSpell : Spell
{
    [SerializeField]
    GameObject objectPrefab;

    public override Action OnCast()
    {
        Debug.Log("Slash spell casted");

        GameObject projectile = Instantiate(objectPrefab, caster.transform.position, Quaternion.FromToRotation(Vector3.forward, caster.transform.forward));

        FightObject fightObject = projectile.GetComponent<FightObject>();
        fightObject.SetCaster(caster);
        fightObject.SetDamage(10f);
        fightObject.SetLifetime(.5f);
        return new DefaultAction(caster);
    }
}