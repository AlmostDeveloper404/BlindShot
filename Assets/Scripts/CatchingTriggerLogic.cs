using UnityEngine;

public class CatchingTriggerLogic : MonoBehaviour
{
    public GameObject ActionObstacle;
    Animation _objectAnim;
    public GameObject ShotBall;

    public bool usedShotBall = false;

    private void Start()
    {
        _objectAnim = ActionObstacle.GetComponent<Animation>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<Ball>())
        {
            _objectAnim.Play();
            if (usedShotBall)
            {
                Invoke("EnableBall", 0.5f);
            }
        }
    }

    void EnableBall()
    {
        ShotBall.SetActive(true);
    }
}
