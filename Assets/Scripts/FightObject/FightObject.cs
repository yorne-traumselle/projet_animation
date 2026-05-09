using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class FightObject : MonoBehaviour
{
    Fighter caster;
    Fighter target;
    List<Fighter> fightersHit = new List<Fighter>();
    float damage;
    Trajectory trajectory = new Trajectory();
    float lifetime = float.MaxValue;
    [SerializeField]
    float collisionAngle = 361f;

    bool removeOnHit = false;

    void Start()
    {
        trajectory.Initialize(this);
        Collider collider = GetComponent<Collider>();
        if (collider != null)        {
            collider.isTrigger = true; 
        }

        // Ensure trigger events are generated
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = true;
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;         
    }

    public void SetTrajectory(Trajectory newTrajectory)
    {
        trajectory = newTrajectory;
        trajectory.Initialize(this);
    }

    public void SetLifetime(float newLifetime)
    {
        lifetime = newLifetime;
    }

    public void SetDamage(float damageAmount)
    {
        damage = damageAmount;
    }

    public void SetCaster(Fighter newCaster)
    {
        caster = newCaster;
    }

    void Update()
    {
        trajectory.Update();
        if (trajectory.IsFinished)
        {
            Destroy(gameObject);
        }
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void SetRemoveOnHit(bool value)
    {
        removeOnHit = value;
    }
    
    Vector3 Iso(Vector3 input)
    {
        return new Vector3(input.x, 0, input.z);
    }

    void OnTriggerEnter(Collider other)
    {
        float angle = Vector3.Angle(transform.forward, Iso(other.transform.position - transform.position));

        if (Mathf.Abs(angle) * 2 > collisionAngle)
        {
            return;
        }

        Fighter target = other.GetComponent<Fighter>();
        if (target != null && target != caster && !fightersHit.Contains(target))
        {
            Debug.Log("FightObject collided with " + other.name);
            fightersHit.Add(target);
            target.ApplyDamage(damage);
            if (removeOnHit)
            {
                Destroy(gameObject);
            }
        }
    }


}