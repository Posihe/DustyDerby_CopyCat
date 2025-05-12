using UnityEngine;

public class Wall : MonoBehaviour
{
    private float collisionStartTime;
    private bool isColliding = false;

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isColliding)
            {
                // 충돌 시작 시점 기록
                collisionStartTime = Time.time;
                isColliding = true;
            }

            // 경과 시간 확인
            if (Time.time - collisionStartTime >= 1.5f)
            {
                collision.transform.position = new Vector3(0, 1, 0);
                isColliding = false; // 다시 충돌되었을 때를 위해 초기화
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // 충돌이 끝나면 초기화
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }
}
