using UnityEngine;

public class DashSpell : Spell
{
    [SerializeField]
    float dashDistance = 10f;
    [SerializeField]
    float dashSpeed = 5f;

    public override Action OnCast()
    {
        Debug.Log("Dash spell casted at position " + PointTarget);
        return new DashAction(caster, PointTarget, dashSpeed, dashDistance);
    }
}