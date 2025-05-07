using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : LivingEntity
{
    NavMeshAgent agent;
    public Transform[] w_Point;
    Transform m_target = null;
    public ParticleSystem hitEffect;
    int m_count;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        m_count = 0;
        InvokeRepeating("MoveToWaypoint", 0f, 2f);
        health = 3;
    }

    private void Update()
    {
        if (m_target != null)
        {
            agent.SetDestination(m_target.position);


        }
    }

    public void SetTarget(Transform p_target)
    {
        CancelInvoke();
        m_target = p_target;

    }

    public void RemoveTarget()
    {

        m_target = null;
        InvokeRepeating("MoveToWaypoint", 0f, 2f);

    }



    void MoveToWaypoint()
    {
        if (m_target == null)
        {
            if (agent.velocity == Vector3.zero)
            {

                agent.SetDestination(w_Point[m_count++].position);

                if (m_count >= w_Point.Length)
                {

                    m_count = 0;
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Box box = other.gameObject.GetComponent<Box>();
            if (box.isHit == true&&!dead)
            {
                OnDamage(1);
                hitEffect.transform.position = gameObject.transform.position;
                hitEffect.Play();
                box.isHit = false;
                Debug.Log(health);
                if(health<=0)
                {

                    dead = true;
                    Destroy(gameObject);
                }

            }

        }
    }
}
