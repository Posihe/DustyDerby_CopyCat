using UnityEngine;

public class CamMove : MonoBehaviour
{
    private CamInput CamInput;
    private int moveSpeed;
    private int rotateSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CamInput = GetComponent<CamInput>();
        moveSpeed = 10;
        rotateSpeed = 30;
    }

    // Update is called once per frame
    void Update()
    {
       // Move();
        Rotate();
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate(CamInput.verticalMove * transform.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(CamInput.verticalMove * transform.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(CamInput.horizontalMove * transform.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(CamInput.horizontalMove * transform.forward * moveSpeed * Time.deltaTime);
        }
    }

    private void Rotate()
    {

       
            if (Input.GetKey(KeyCode.E))
            {


                transform.Rotate(0, 1 * rotateSpeed * Time.deltaTime, 0);

            }


        

        


            if (Input.GetKey(KeyCode.Q))
            {


                transform.Rotate(0, -1 * rotateSpeed * Time.deltaTime, 0);

            }

        
    }
}
