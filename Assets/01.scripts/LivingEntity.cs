using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour,IDamageable
{
    public float startingHealth = 100f;
    public float health { get; protected set; }
    public bool dead { get; protected set; }

    public event Action onDeath;

    float timeBetAttack = 0.5f;
    float lastAttackTime;

    protected virtual void OnEnable()
    {
        dead = false;

        health = startingHealth;
    
    
    }

    public virtual void OnDamage(float damage)
    {
        health -= damage;
        if(health<=0&&!dead)
        {

            Die();


        }



    }

    public virtual void RestoreHealth(float newHealth)
    {
        if(dead)
        {

            return;
        }

        health += newHealth;


    }

    public virtual void Die()
    {

        if(onDeath!=null)
        {

            onDeath();

        }

        dead = true;

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(!dead)
    //    {
    //        IItem item = other.GetComponent<IItem>();
    //        if(item!=null)
    //        {
    //            item.Use(gameObject);


    //        }


    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[TriggerEnter] {gameObject.name} 감지: {other.gameObject.name}");

        if (!dead)
        {
            IItem item = other.GetComponent<IItem>();
            if (item != null)
            {
                Debug.Log($"[ItemUse] {item} 사용");
                item.Use(gameObject);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!dead)
    {
        IItem item = collision.gameObject.GetComponent<IItem>();
        if (item != null)
        {
            item.Use(gameObject);
        }
    }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null && Time.time >= lastAttackTime + timeBetAttack)
            {
                lastAttackTime = Time.time;
                player.OnDamage(10);
                Debug.Log(player.health);
            }
        }
    }
}
