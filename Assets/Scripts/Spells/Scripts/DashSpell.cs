using UnityEngine;

public class DashSpell : Spell
{

    public override Action OnCast()
    {
        Debug.Log("Dash spell casted at position " + PointTarget);
        return new DashAction(caster, PointTarget, 10f, 5f);
    }
}