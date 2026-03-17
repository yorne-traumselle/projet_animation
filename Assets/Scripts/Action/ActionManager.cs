using System;
using UnityEditor;
namespace Actions
{
    public class ActionManager
    {
        Fighter parent;
        Action currentAction;

        public ActionManager(Fighter parent)
        {
            this.parent = parent;
            ChangeAction(new Idle(parent));
        }

        public void ChangeAction(Action newAction)
        {
            if (currentAction != null)
            {
                currentAction.Exit();
            }
            currentAction = newAction;
            currentAction.Enter();
        }

        public void Update()
        {
            Action newAction = currentAction.Update();
            if (newAction != null)
            {            
                ChangeAction(newAction);
            }
        }
    }
}