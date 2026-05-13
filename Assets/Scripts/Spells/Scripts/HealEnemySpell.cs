using UnityEngine;

public class HealEnemySpell : Spell
{
    [SerializeField]
    float healAmount = 50f;

    public override Action OnCast()
    {
        Debug.Log("Heal spell casted");

        target.ApplyHeal(healAmount);
        return new DefaultAction(caster);
    }
}