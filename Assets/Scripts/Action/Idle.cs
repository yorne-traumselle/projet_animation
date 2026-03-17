using Moves;

namespace Actions 
{
    public class Idle: Action
    {
        public Idle(Fighter fighter) : base(fighter)
        {
            
        }

        public override void OnEnter()
        {
            fighter.ChangeMove(new Stationary(fighter));
        }
    }
}