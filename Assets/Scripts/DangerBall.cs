using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerBall : MonoBehaviour
{
    public GameObject MainBall;
    Rigidbody2D _rigidbody2D;

    public float FollowSpeed = 30f;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Ball.isDead)
        {
            Debug.Log("yep");
            DangerCircleDisable();
        }
        if (enabled == true)
        {
            Vector2 ballPosition = MainBall.GetComponent<Rigidbody2D>().position;
            Vector2 dir = ballPosition - (Vector2)transform.position;
            _rigidbody2D.velocity = dir.normalized * FollowSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            DangerCircleDisable();
        }
       
    }

    void DangerCircleDisable()
    {
        _rigidbody2D.isKinematic = true;
        FollowSpeed = 0;
    }
}
