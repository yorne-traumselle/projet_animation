
namespace Actions
{
    public class Action
    {
        protected Fighter fighter;
        public Action(Fighter fighter)
        {
        this.fighter = fighter;
        }

        public bool CanEnter()
        {
            return true;
        }

        public void Enter()
        {
            OnEnter();
        }
        public virtual void OnEnter()
        {

        }

        public void Exit()
        {
            OnExit();
        }
        public virtual void OnExit()
        {

        }

        public virtual Action Update()
        {
            return null;
        }
    }
}