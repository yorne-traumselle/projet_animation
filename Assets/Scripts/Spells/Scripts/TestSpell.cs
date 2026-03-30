using UnityEngine;
public class TestSpell : Spell
{
    public override Action OnCast()
    {
        Debug.Log("Test spell casted on " + (Target != null ? Target.name : "no target") + " at position " + PointTarget);
        return new DefaultAction(caster);
    }
}