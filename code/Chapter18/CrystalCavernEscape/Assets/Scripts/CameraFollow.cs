using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new(0f, 8f, -10f);
    [SerializeField] private float followSpeed = 5f;

    private void LateUpdate()
    {
        if (target is null)
        {
            return;
        }

        Vector3 targetPosition = target.position + offset;

        transform.position = Vector3.Lerp(
          transform.position,
          targetPosition,
          followSpeed * Time.deltaTime);

        transform.LookAt(target);
    }
}
