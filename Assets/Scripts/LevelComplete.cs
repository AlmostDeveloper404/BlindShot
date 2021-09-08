using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject LevelCompleteAnim;
    public GameObject Ball;
    private void OnTriggerEnter2D()
    {
        Debug.Log("LevelComplete");
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(Ball.gameObject);
    }
}
