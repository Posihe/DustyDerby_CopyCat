using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    public int score = 1;
    private bool isUsed = false;
    private AudioSource audio;
    public AudioClip audioClip;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = audioClip;
    }

    public void Update()
    {
        transform.Rotate(0, 1, 0);
    }
    public void Use(GameObject target)
    {
        
        if (isUsed) return; // 이미 사용된 경우 실행되지 않도록 함
        isUsed = true;
         audio.Play();
        GameManager.instance.AddScore(score);
    
        Destroy(gameObject,audioClip.length);



    }

}
