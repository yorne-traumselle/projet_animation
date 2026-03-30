using UnityEngine;


public class WalkAction : Action
{
    WalkMove move;

    public WalkAction(Fighter fighter, Vector3 destination) : base(fighter)
    {
        this.move = new WalkMove(fighter, destination);
    }

    public override void OnEnter()
    {
        Debug.Log("enter walk");
        fighter.ChangeMove(move);
    }

    public override void OnExit()
    {
        Debug.Log("exit walk");
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
