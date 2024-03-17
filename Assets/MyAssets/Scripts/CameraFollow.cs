using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset;
    public float smooth = .125f;
    private void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        var desiredPos = playerTransform.position + offset;

        var smoothPos = Vector3.Lerp(transform.position, desiredPos, smooth);

        transform.position = smoothPos;
    }
}
