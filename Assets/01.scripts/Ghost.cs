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
        // ���� �ð� ����
        passTime += Time.deltaTime;

        // ��ٸ� �ð��� �Ѱ�, ���� ���� ���� �ƴϸ� ���� ����
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
