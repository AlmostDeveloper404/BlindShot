using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSurfaceCollider : MonoBehaviour
{
    [SerializeField] GameObject trailRenderer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            trailRenderer.SetActive(true);
        }
        else
        {
            trailRenderer.SetActive(false);
        }
    }
}
