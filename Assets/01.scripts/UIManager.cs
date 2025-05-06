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

    public static UIManager m_instance;

    private void Start()
    {
        isStop = false;
    }
    public void UpdateScoreText(int newScore)
    {
      
        scoreText.text ="Score: "+ newScore;


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
}
