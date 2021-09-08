using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{
    public Transform Target;

    private void Update()
    {
        Vector2 distance = Target.position - transform.position;
        Debug.Log ("The distance from object " + transform.name+  "is "+   distance.magnitude);
    }
}
