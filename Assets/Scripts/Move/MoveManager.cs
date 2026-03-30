
public class MoveManager
{
    Move currentMove;
    Fighter parent;

    public MoveManager(Fighter parent)
    {
        this.parent = parent;
        
    }

    public void ChangeMove(Move newMove)
    {
        if (currentMove != null)
        {
            currentMove.Exit();
        }
        currentMove = newMove;
        currentMove.Enter();
    }

    public void Update()
    {
        Move newMove = currentMove.Update();
        if (newMove != null)
        {
            ChangeMove(newMove);
        }
    }
}