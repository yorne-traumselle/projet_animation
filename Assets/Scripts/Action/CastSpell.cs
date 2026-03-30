using UnityEngine;
using UnityEngine.Animations;
public class CastSpell : Action
{
    Spell spell;
    bool isCasting;
    float castTime;

    public CastSpell(Spell spell, Fighter fighter) : base(fighter)
    {
        this.spell = spell;
    }

    public override Action Update()
    {
        if (isCasting)
        {
            castTime -= Time.deltaTime;
            if (castTime <= 0)
            {
                return spell.Cast();
            }
            else {
                return null;
            }
        }

        switch (spell.CanCast())
        {
            case CanCastResult.Can:
                isCasting = true;
                castTime = spell.CastTime;
                if (castTime > 0)
                {
                    isCasting = true;
                }
                break;
            case CanCastResult.Cannot:
                return new DefaultAction(fighter);
            case CanCastResult.TargetOutOfRange:
                fighter.ChangeMove(new Follow(fighter, spell.Target));
                break;
            case CanCastResult.PointOutOfRange:
                fighter.ChangeMove(new WalkMove(fighter, spell.PointTarget));
                break;
            default:
                return null;
        }
        return null;
    }
}