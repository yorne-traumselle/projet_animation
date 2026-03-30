using UnityEngine;

public class Follow: Move
{
    Fighter target;
    Vector3 targetPosition;

    public Follow(Fighter fighter, Fighter target) : base(fighter)
    {
        this.target = target;
    }

    public override void Enter()
    {
        if (target != null)
        {
            targetPosition = target.transform.position;
        }
    }

    public override Move Update()
    {
        if (target == null || !target.IsAlive())
        {
            return new Stationary(fighter);
        }

        targetPosition = target.transform.position;

        float distance = Vector3.Distance(fighter.transform.position, targetPosition);
        
        if (distance < 0.1f)
        {
            return new Stationary(fighter);
        }

        Vector3 direction = (targetPosition - fighter.transform.position).normalized;
        fighter.transform.position += MoveSpeed * Time.deltaTime * direction;
        return null;
    }
}