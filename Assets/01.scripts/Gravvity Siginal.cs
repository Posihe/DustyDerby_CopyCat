using UnityEngine;

public class GravvitySiginal : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void EnableGravity()
    {
        rb.useGravity = true;
      
    }

   
}
