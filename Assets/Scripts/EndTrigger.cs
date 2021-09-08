using System.Collections;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] int NextLevelIndex;

    public SceneFader sceneFader;
    public GameObject WinPanal;
    public ParticleSystem CompleteParticle;
    public GameObject defaultParticles;
    Ball ball;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            WinEffects();
        }
    }

    void WinEffects()
    {
        GameManager.instance.WinLevel();


        FindObjectOfType<AudioManager>().PlaySound("Win");
        WinPanal.SetActive(true);


        ParticleSystem part = Instantiate(CompleteParticle,transform.position,transform.rotation);
        Destroy(part, 1f);


        defaultParticles.GetComponent<Animation>().Play();
        StartCoroutine(LoadNextLevel());


        ball.GetComponent<SpriteRenderer>().enabled = false;
        ball.GetComponent<TrailRenderer>().enabled = false;
        ball.GetComponent<Rigidbody2D>().simulated = false;
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1.3f);
        sceneFader.FadeTo(NextLevelIndex);
    }
}
