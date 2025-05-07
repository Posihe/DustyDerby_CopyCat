using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    public int score = 1;
    private bool isUsed = false;

    public void Update()
    {
        transform.Rotate(0, 1, 0);
    }
    public void Use(GameObject target)
    {
        
        if (isUsed) return; // �̹� ���� ��� ������� �ʵ��� ��
        isUsed = true;

        GameManager.instance.AddScore(score);
        Destroy(gameObject);



    }

}
