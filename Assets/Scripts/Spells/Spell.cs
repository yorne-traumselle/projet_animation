using UnityEngine;

public enum CastType
{
    Fighter,
    Point,
    Self,
    Passive
}

public enum CanCastResult
{
    Can,
    TargetOutOfRange,
    PointOutOfRange,
    Cannot
}

public class Spell : MonoBehaviour
{
    [SerializeField]
    protected string displayName;

    [SerializeField]
    protected float cooldown;
    [SerializeField]
    protected float range;

    [SerializeField]
    protected float castTime;

    [SerializeField]
    protected CastType castType;

    protected Fighter caster;
    protected Fighter target;
    protected Vector3 pointTarget;
    protected float cooldownTimer;

    public void SetCaster(Fighter fighter)
    {
        this.caster = fighter;
        
    }

    public bool IsOnCooldown()
    {
        return cooldownTimer > 0;
    }

    public float CastTime { get { return castTime; }}
    public Vector3 PointTarget { get { return pointTarget; } }
    public Fighter Target { get { return target; } }

    public void Init(Fighter target, Vector3 pointTarget)
    {
        this.target = target;
        this.pointTarget = pointTarget;
    }

    public void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public CanCastResult CanCast()
    {
        if (castType == CastType.Passive)
        {
            return CanCastResult.Cannot;
        }

        if (IsOnCooldown())
        {
            return CanCastResult.Cannot;
        }

        if (castType == CastType.Fighter && target == null)
        {
            return CanCastResult.Cannot;
        }

        if (range > 0)
        {
            if (castType == CastType.Fighter)
            {
                float distance = Vector3.Distance(caster.transform.position, target.transform.position);
                if (distance > range)
                {
                    return CanCastResult.TargetOutOfRange;
                }
            }
            else if (castType == CastType.Point)
            {
                float distance = Vector3.Distance(caster.transform.position, pointTarget);
                if (distance > range)
                {
                    return CanCastResult.PointOutOfRange;
                }
            }
        }

        return CanCastResult.Can;
    }

    public Action Cast()
    {
        StartCooldown();
        return OnCast();
    }
    public virtual Action OnCast()
    {
        return null;
    }

    public void StartCooldown()
    {
        cooldownTimer = cooldown;
    }
        
}