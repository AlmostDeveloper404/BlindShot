using UnityEngine;

public class BallCollision : MonoBehaviour
{
    Ball _ball;
    GameManager _gameManager;
    public GameObject Mask;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
    }
    private void Start()
    {
        _gameManager = GameManager.instance;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Danger") && _gameManager.isMaskLevel)
        {
            _ball.Dead();
            collision.collider.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            Instantiate(Mask,transform.position,Quaternion.identity);
        }
        if (collision.collider.CompareTag("DeathZone"))
        {
            _ball.Dead();     
        }
    }
}
