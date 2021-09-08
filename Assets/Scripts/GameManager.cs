using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject menuIntoGame;


    public int nextLevelindex;
    public int maxLevelindex;


    public bool isMaskLevel;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one GameManager!");
            return;
        }
        instance = this;
    }
    private void Start()
    {
        maxLevelindex = PlayerPrefs.GetInt("MaxLevel");
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void WinLevel()
    {
        if (nextLevelindex<maxLevelindex)
        {
            PlayerPrefs.SetInt("reachedLevel",maxLevelindex);
        }
        else
        {
            PlayerPrefs.SetInt("reachedLevel",nextLevelindex);
            PlayerPrefs.SetInt("MaxLevel",nextLevelindex);
        }
    }
    public void Quit()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
