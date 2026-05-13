using UnityEngine;

public class Trajectory
{
    protected FightObject fightObject;
    protected bool isFinished = false;
    public bool IsFinished { get { return isFinished; } }

    public void Initialize(FightObject fightObject)
    {
        this.fightObject = fightObject;
    }

    public virtual void Update()
    {
        // Trajectory logic to be implemented in derived classes
    }
}