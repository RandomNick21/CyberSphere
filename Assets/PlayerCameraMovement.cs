using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 0.1f;
    private Transform _camera;
    private Vector3 _offset;

    private void Start()
    {
        _camera = Camera.main.transform;
        _offset = _camera.position - transform.position;
    }
    private void LateUpdate()
    {
        _camera.position = Vector3.Lerp(_camera.position, transform.position + _offset, Speed);
    }
}
