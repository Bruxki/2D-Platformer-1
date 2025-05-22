using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    Vector3 velocity = Vector3.zero;

    public Vector3 positionOffset;

    //[Header ("Axis Limitation")]
    //public Vector2 xLimit;
    // public Vector2 yLimit;

    [Range(0, 1)]
    public float smoothTime;


    private void LateUpdate()
    {
        Vector3 targetPosition = target.transform.position + positionOffset;
    //   targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
