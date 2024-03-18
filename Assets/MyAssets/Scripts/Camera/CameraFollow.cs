using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private float _smooth = .125f;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _playerTransform.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _playerTransform.position + _offset, _smooth); ;
    }
}
