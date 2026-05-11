using UnityEngine;

public class HealSpell : Spell
{
    [SerializeField]
    float healAmount = 20f;

    public override Action OnCast()
    {
        Debug.Log("Heal spell casted");
        caster.Stats.ApplyHeal(healAmount);
        return new DefaultAction(caster);
    }
}