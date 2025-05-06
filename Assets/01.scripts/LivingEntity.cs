using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour,IDamageable
{
    public float startingHealth = 100f;
    public float health { get; protected set; }
    public bool dead { get; protected set; }

    public event Action onDeath;
   
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

    private void OnTriggerEnter(Collider other)
    {
        if(!dead)
        {
            IItem item = other.GetComponent<IItem>();
            if(item!=null)
            {
                item.Use(gameObject);


            }


        }
    }

   
}
