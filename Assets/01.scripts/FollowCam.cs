using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private int rotateSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rotateSpeed = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        RigthRotae();
        LeftRotate();
    }

    void RigthRotae()
    {
        if(Input.GetKey(KeyCode.E))
        {


            transform.Rotate(0, 1*rotateSpeed*Time.deltaTime, 0);

        }


    }

    void LeftRotate()
    {


        if (Input.GetKey(KeyCode.Q))
        {


            transform.Rotate(0, -1 * rotateSpeed * Time.deltaTime, 0);

        }

    }
}
