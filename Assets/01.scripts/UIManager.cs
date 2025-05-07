using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get 
        {
          if(m_instance==null)
            {

                m_instance = FindAnyObjectByType<UIManager>(0);
            }
          return m_instance;
        }
    }

    public Text scoreText;
    public Text TimeText;
    public GameObject menuPanel;
    public Image continueText;
    bool isStop;
    public GameObject ClearPanel;
    public static UIManager m_instance;

    private void Start()
    {
        isStop = false;
    }
    public void UpdateScoreText(int newScore)
    {

        // scoreText.text ="Score: "+ newScore;
        scoreText.text = newScore + "/10";

    }

    


    public void Menu()
    {

        isStop = !isStop;
        if(isStop)
        {
            menuPanel.SetActive(true);
            Time.timeScale = 0;
            
        }
       

    }
   
    public void Continue()
    {

        menuPanel.SetActive(false);
        Time.timeScale = 1;
        isStop = false;


    }

    public void Quit()
    {

        Application.Quit();

    }

    public void Clear()
    {


        ClearPanel.SetActive(true);
    }
}
