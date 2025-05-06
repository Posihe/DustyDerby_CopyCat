using UnityEngine;


public class PlayerMovement : LivingEntity
{
    Rigidbody rb;
    PlayerInput playerInput;
    float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        hitcollider();

    }

    

    private void Move()
    {

        // 입력 방향 설정 (월드 기준)
        Vector3 direction = new Vector3(playerInput.horizontalMove, 0f, playerInput.verticalMovve).normalized;

        // 이동 거리 계산
        Vector3 moveDistance = direction * moveSpeed * Time.deltaTime;

        if (direction.magnitude > 0)
        {
            rb.MovePosition(rb.position + moveDistance); // 물리 이동
            transform.forward = direction; // 입력 방향을 바라보게 회전
        }

    }



    private void hitcollider() //콜라이더 감지해서 거리가 너무 가까우면 충돌하기 전에 멈춤
    {
        Vector3 input = new Vector3(playerInput.horizontalMove, 0, playerInput.verticalMovve);
        Vector3 direction = transform.TransformDirection(input).normalized;
        RaycastHit hit;
        //float lineSize = 16;
        //Debug.DrawRay(transform.position, direction * lineSize, Color.yellow);
        if (Physics.Raycast(transform.position, direction, out hit))
        {

            if (hit.collider != null)
            {

                if (Vector3.Distance(transform.position, hit.transform.position) >= 0.1f)
                {


                    Move();


                }


            }



        }


    }



}
