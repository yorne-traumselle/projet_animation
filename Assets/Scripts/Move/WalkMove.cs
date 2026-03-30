using UnityEngine;

public class WalkMove: Move
{
    Vector3 destination;
    
    public WalkMove(Fighter fighter, Vector3 destination): base(fighter)
    {
        this.destination = destination;
    }

    public override Move Update()
    {
        Vector3 direction = (destination - fighter.transform.position).normalized;
        fighter.transform.position += direction * MoveSpeed * Time.deltaTime;
        if (Vector3.Distance(fighter.transform.position, destination) < 0.1f)
        {
            return new Stationary(fighter);
        }
        return null;
    }

}
