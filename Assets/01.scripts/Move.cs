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
        targetPosition = transform.position; // ���� ��ġ�� �ʱ�ȭ
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
        direction.y = 0; // Y�� ȸ�� ����

        float speed = isRun ? runSpeed : walkSpeed;
        Vector3 move = direction * speed * Time.deltaTime;

        // �Ÿ��� �ſ� ��������� �̵� ����
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
            
            return;
        }

        // �̵�
        transform.position += move;

        // ȸ��
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
