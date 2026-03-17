using UnityEngine;
namespace Moves
{
    public class WalkMove: Move
    {
        Vector3 destination;
        
        public WalkMove(Fighter fighter, Vector3 destination): base(fighter)
        {
            this.destination = destination;
        }

        public override Move Update()
        {
            fighter.transform.position = Vector3.MoveTowards(fighter.transform.position, destination, Time.deltaTime);
            if (Vector3.Distance(fighter.transform.position, destination) < 0.1f)
            {
                return new Stationary(fighter);
            }
            return null;
        }

    }
}