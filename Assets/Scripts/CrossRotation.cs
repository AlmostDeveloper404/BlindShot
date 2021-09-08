using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossRotation : MonoBehaviour
{
    public float speedRotation;
    private void Update()
    {
        gameObject.transform.Rotate(Vector3.forward* speedRotation*Time.deltaTime);
    }
}
