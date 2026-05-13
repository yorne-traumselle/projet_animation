using UnityEngine;


public class DashAction : Action
{
    DashMove move;

    public DashAction(Fighter fighter, Vector3 destination, float speed, float length) : base(fighter)
    {
        this.move = new DashMove(fighter, destination, speed, length);
    }

    public override void OnEnter()
    {
        Debug.Log("enter dash");
        fighter.ChangeMove(move);
    }

    public override void OnExit()
    {
        Debug.Log("exit dash");
    }

    public override Action Update()
    {
        if (move.IsFinished())
        {
            return new Idle(fighter);
        }
        return null;
    }
}
