using TMPro;
using UnityEngine;

public class Move : MonoBehaviour

{
    Animator anim;
    Rigidbody rb;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public bool isRun;

    private Vector3 targetPosition;
    private bool isMoving;
   

    private void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position; // 현재 위치로 초기화
        isMoving = false;
    }

    void Update()
    {
        Running();
        HandleClick();
        Moving();
    }

   void Running()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRun=!isRun;

        }


    }

    void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider!=null)
                {
                    targetPosition = hit.point;
                    isMoving = true;
                }
            }
        }
    }

    void Moving()
    {
        if (!isMoving) return;

        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0; // Y축 회전 방지

        float speed = isRun ? runSpeed : walkSpeed;
        Vector3 move = direction * speed * Time.deltaTime;

        // 거리가 매우 가까워지면 이동 멈춤
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
            
            return;
        }

        // 이동
        transform.position += move;

        // 회전
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
        }

      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider!=null)
        {
            isMoving=false;


        }
    }
}
