using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFader;
    public Button[] buttons;


    private void Start()
    {
        int reachedLevel = PlayerPrefs.GetInt("reachedLevel",1);


        for (int i = 0; i < buttons.Length; i++)
        {
            if (i+1 > reachedLevel)
            {
                buttons[i].interactable = false;
            }
        }
    }
    public void Select(int levelIndex)
    {
        sceneFader.FadeTo(levelIndex);
    }
}
