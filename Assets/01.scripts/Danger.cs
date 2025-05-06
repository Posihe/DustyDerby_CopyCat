using UnityEngine;

public class Danger : MonoBehaviour
{
    public Enemy enemy = null;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            enemy.SetTarget(other.transform);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            enemy.RemoveTarget();
        }
    }

}
