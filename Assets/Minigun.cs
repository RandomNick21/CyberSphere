using UnityEngine;

public class Minigun : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    private Vector3 _offset;

    private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
        
        _offset = _lineRenderer.GetPosition(0) - transform.position;
    }
    private void LateUpdate()
    {
        
    }
}
