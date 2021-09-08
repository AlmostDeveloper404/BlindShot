using UnityEngine;

public class MovingObjectScript : MonoBehaviour
{
    Transform _target;

    public int pointIndex;
    public float speed;

    void Start()
    {
        _target = WayPoints.points[pointIndex];
    }
    void Update()
    {
        Vector2 dir = _target.position - transform.position;
        transform.position += (Vector3)dir.normalized * speed * Time.deltaTime;
        if (dir.magnitude <= .2f)
        {
            MoveNextPoint();
        }
    }
    void MoveNextPoint()
    {
        _target = WayPoints.points[pointIndex];
        pointIndex++;
        if (pointIndex > WayPoints.points.Length-1)
        {
            pointIndex = 0;
        }
    }
}
