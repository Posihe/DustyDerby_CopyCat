using UnityEngine;

public class Box : MonoBehaviour,IItem
{
    bool isFireReady;
   public bool isHit;
   Rigidbody rb;
    Collider col;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        isFireReady = false;
        isHit = false;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    public void Use(GameObject target)
    {

        PlayerMovement player = target.GetComponent<PlayerMovement>();

        if(player!=null)
        {

           Transform itemPoint = target.transform.Find("ItemPoint");
            if(itemPoint!=null)
            {


                transform.position = itemPoint.position;
                // 아이템을 소켓의 자식으로 설정
                transform.SetParent(itemPoint);
                

                // 필요하면 로컬 위치 초기화 (소켓 기준으로 정확히 붙이기 위함)
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                isFireReady = true;
                rb.useGravity = false;
                rb.isKinematic = true;
                col.enabled = false;


            }
            else { return; }

        }


    }

    public void Fire()
    {
        if(isFireReady)
        {
            if(Input.GetMouseButton(0))
            {
               
                transform.SetParent(null); // 부모에서 분리
               
                rb.isKinematic = false;
                rb.useGravity = true;
                col.enabled = true;

                // 예: 앞 방향으로 힘을 줘서 던지기
                rb.AddForce(transform.forward * 10f + transform.up * 1f, ForceMode.Impulse);
                isHit = true;
                Debug.Log("발사");

                isFireReady = false;



            }


        }


    }

}
