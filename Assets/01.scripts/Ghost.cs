using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    private bool isChasing;
    private float waitingTime = 10f;
    private float passTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isChasing = false;
    }

    void Update()
    {
        // 누적 시간 증가
        passTime += Time.deltaTime;

        // 기다린 시간이 넘고, 아직 추적 중이 아니면 추적 시작
        if (passTime > waitingTime )
        {
            StartCoroutine(Chase());
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
}
