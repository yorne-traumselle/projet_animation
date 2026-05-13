using UnityEngine;

public class DashMove: Move
{
    Vector3 start;
    Vector3 destination;
    float speed;
    float length;

    public DashMove(Fighter fighter, Vector3 destination, float speed, float length): base(fighter)
    {
        this.destination = destination;
        this.speed = speed;
        this.length = length;
        calculateDestination();
    }

    public override Move Update()
    {
        Vector3 direction = (destination - fighter.transform.position).normalized;
        fighter.transform.LookAt(destination);
        fighter.transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(fighter.transform.position, destination) < 0.1f * speed)
        {   
            fighter.transform.position = destination;
            return new Stationary(fighter);
        }
        return null;
    }

    void calculateDestination()
    {
        Vector3 direction = (destination - fighter.transform.position).normalized;
        destination = fighter.transform.position + direction * length;
    }

}
