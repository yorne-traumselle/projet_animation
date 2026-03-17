using UnityEngine;

namespace Moves
{
    public class Move
    {
        protected Fighter fighter;
        protected bool finished = false;

        public Move(Fighter fighter)
        {
            this.fighter = fighter;
        }

        public virtual bool IsFinished()
        {
            return finished;
        }

        public void Exit()
        {
            finished = true;
        }

        public void Enter()
        {
        
        }

        public virtual Move Update()
        {
            return null;
        }
    }
}