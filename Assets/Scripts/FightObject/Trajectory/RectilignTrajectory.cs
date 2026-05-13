using UnityEngine;

public class RectilignTrajectory : Trajectory
{
    Vector3 destination;
    float speed;

    public RectilignTrajectory(Vector3 destination, float speed)
    {
        this.destination = destination;
        this.speed = speed;
    }

    public RectilignTrajectory(Vector3 start, Vector3 destination, float range, float speed)
    {
        Vector3 direction = (destination - start).normalized;
        this.destination = start + direction * range;
        this.speed = speed;
    }

    public override void Update()
    {
        fightObject.transform.position = Vector3.MoveTowards(fightObject.transform.position, destination, speed * Time.deltaTime);
        if ((fightObject.transform.position - destination).magnitude < speed * Time.deltaTime)
        {
            fightObject.transform.position = destination;
            isFinished = true;
        }
    }
}