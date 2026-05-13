using UnityEngine;
public class BoxHitbox : HitBox
{
    public Vector3 Size = Vector3.one;

    public BoxHitbox(float depth, float width)
    {
        Size = new Vector3(width, HEIGHT, depth);
    }

    public override void OnInitialize()
    {
        BoxCollider box = fightObject.gameObject.AddComponent<BoxCollider>();
        box.isTrigger = true;
        box.size = Size;
        collider = box;
    }
}