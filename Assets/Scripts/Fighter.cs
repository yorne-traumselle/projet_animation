using UnityEngine;
using Moves;
using Actions;
public class Fighter : MonoBehaviour
{
    MoveManager moveManager;
    ActionManager actionManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveManager = new MoveManager(this);
        actionManager = new ActionManager(this);
        // ChangeAction(new WalkAction(this, new Vector3(10, 0, 10)));
        
    }

    void Update()
    {
        moveManager.Update();
        actionManager.Update();   
    }

    public void ChangeAction(Action newAction)
    {
        actionManager.ChangeAction(newAction);
    }

    public void ChangeMove(Move newMove)
    {
        moveManager.ChangeMove(newMove);
    }

    public void Die()
    {
        Debug.Log("Fighter has died.");
        // Implement death logic here (e.g., play animation, disable fighter, etc.)
    }
}
