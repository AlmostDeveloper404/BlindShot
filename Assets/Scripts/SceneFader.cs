using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;
    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(int scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    IEnumerator FadeIn()
    {
        float t = 1f;
        while (t > 0)
        {
            t -= Time.deltaTime;
            float alpha = curve.Evaluate(t);
            img.color = new Color(0f,0f,0f,alpha);
            yield return 0;
        }
    }
    IEnumerator FadeOut(int scene)
    {
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime;
            float alpha = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}
