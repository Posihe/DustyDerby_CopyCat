using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : LivingEntity
{
    public GameObject target;
    private NavMeshAgent agent;
    private bool isChasing;
    private float waitingTime = 10f;
    private float passTime = 0f;
    public ParticleSystem hitEffect;
    public float timeBetAttack=1f;
    private float lastAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isChasing = false;
        health = 200;
    }

    //public override void OnDamage(float damage)
    //{
    //    base.OnDamage(damage);
    //}

    void Update()
    {
        // 누적 시간 증가
        passTime += Time.deltaTime;

        // 기다린 시간이 넘고, 아직 추적 중이 아니면 추적 시작
        if (passTime > waitingTime)
        {
            StartCoroutine(Chase());
        }
    }



  

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Box box = other.gameObject.GetComponent<Box>();
            if (box.isHit == true && !dead)
            {
                OnDamage(10);
                hitEffect.transform.position = gameObject.transform.position;
                hitEffect.Play();
                box.isHit = false;
                Debug.Log(health);
                if (health <= 0)
                {

                    dead = true;
                    Destroy(gameObject);
                }

            }

        }
    }

    IEnumerator Chase()
    {

        isChasing = true;
        agent.SetDestination(target.transform.position);


        yield return new WaitForSeconds(waitingTime);

        isChasing = false;
        passTime = 0f;
    }

    public override void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null && Time.time >= lastAttackTime + timeBetAttack&&isChasing)
            {
                lastAttackTime = Time.time;
                player.OnDamage(10);
                Debug.Log(player.health);
            }
        }
    }

}
