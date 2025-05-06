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
                // �������� ������ �ڽ����� ����
                transform.SetParent(itemPoint);
                

                // �ʿ��ϸ� ���� ��ġ �ʱ�ȭ (���� �������� ��Ȯ�� ���̱� ����)
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
               
                transform.SetParent(null); // �θ𿡼� �и�
               
                rb.isKinematic = false;
                rb.useGravity = true;
                col.enabled = true;

                // ��: �� �������� ���� �༭ ������
                rb.AddForce(transform.forward * 10f + transform.up * 1f, ForceMode.Impulse);
                isHit = true;
                Debug.Log("�߻�");

                isFireReady = false;



            }


        }


    }

}
