using UnityEngine;

public class PatrolMover : MonoBehaviour
{
    [SerializeField] private Vector3 pointA = new(-6f, 0.6f, 0f);
    [SerializeField] private Vector3 pointB = new(6f, 0.6f, 0f);
    [SerializeField] private float moveSpeed = 3f;

    private Vector3 targetPoint;

    private void Start()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint,
            moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint) < 0.05f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
        }
    }
}
