using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {

        get
        {
            if (m_instance == null)

            {
                m_instance = FindAnyObjectByType<GameManager>();
            }
           return m_instance;
        }
    }

    private static GameManager m_instance;

    public int score = 0;
    public bool isGameover { get; private set; }

    private GameObject player;


    public void Update()
    {
        if (score >= 10)
        {
            GameClear();
        }
    }

    public void AddScore(int newScore)
    {

        if(!isGameover)
        {

            score += newScore;

            UIManager.instance.UpdateScoreText(score);
        }
    }


    public void GameClear()
    {
        UIManager.instance.Clear();

    



    }


    public void Title()
    {

        SceneManager.LoadScene("Title");
    }
}
