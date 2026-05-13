using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public abstract class HitBox
{
    protected Collider collider;
    protected FightObject fightObject;
    protected const float HEIGHT = 10f;
    List<Fighter> targets = new List<Fighter>();
    Action<Fighter> onHit;

    public Action<Fighter> OnHit { set { onHit = value; } }

    public void Initialize(FightObject fightObject)
    {
        this.fightObject = fightObject;
        OnInitialize();
    }

    public virtual void OnInitialize()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Fighter target = other.GetComponent<Fighter>();
        if (target != null && target)
        {
            targets.Add(target);
            onHit?.Invoke(target);
        }
    }
}