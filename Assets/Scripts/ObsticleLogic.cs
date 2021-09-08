using UnityEngine;

public class ObsticleLogic : MonoBehaviour
{

    [SerializeField] ParticleSystem hitParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            CircleCollider2D _circleCollider = collision.gameObject.GetComponent<CircleCollider2D>();

            if (ball.GetComponent<Rigidbody2D>().velocity.magnitude > 4f)
            {
                
                 ParticleSystem part= Instantiate(hitParticle, collision.collider.ClosestPoint(_circleCollider.transform.position),Quaternion.LookRotation(collision.transform.position));
                 Destroy(part.gameObject, 1f);

                 Interactable();
            }
        }
    }
    public void Interactable()
    {
        FindObjectOfType<AudioManager>().PlaySound("ObstacleHit");
    }
}
