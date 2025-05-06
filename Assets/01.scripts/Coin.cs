using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    public int score = 200;
    private bool isUsed = false;

    public void Use(GameObject target)
    {
        if (isUsed) return; // �̹� ���� ��� ������� �ʵ��� ��
        isUsed = true;

        GameManager.instance.AddScore(score);
        Destroy(gameObject);



    }

}
