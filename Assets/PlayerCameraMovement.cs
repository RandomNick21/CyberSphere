using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 0.1f;
    [SerializeField] private float SpeedRotate = 1f;
    [SerializeField] private float Sensivity = 1f;
    private Transform _camera;
    private Vector3 _offset;

    private void Start()
    {
        _camera = Camera.main.transform;
        _offset = _camera.position - transform.position;
    }
    private void LateUpdate()
    {
        //_camera.position = Vector3.Slerp(_camera.position, transform.position + _offset, Speed);
        //_offset = _camera.position - transform.position;

        if (Mouse.current.leftButton.isPressed)
        {
            var rotY = Input.GetAxis("Mouse X") * Sensivity * Mathf.Deg2Rad;
            transform.RotateAround(transform.up, rotY);
        }
    }
}
