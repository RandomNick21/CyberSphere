using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FixedJoystick : MonoBehaviour
{
    [SerializeField] private Transform Centre;
    [SerializeField] private float RangeLimit;
    [SerializeField] private Image _borders;

    public static FixedJoystick instance;
    
    private float _normalizedMagnitude;

    [HideInInspector] public Vector2 Range;
    
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Mouse.current.position.ReadValue().x < _borders.rectTransform.position.x + _borders.rectTransform.sizeDelta.x * 0.5f &&
            Mouse.current.position.ReadValue().y < _borders.rectTransform.position.y + _borders.rectTransform.sizeDelta.y * 0.5f)
        {
            Centre.position = Mouse.current.position.ReadValue();
        }
        else
        {
            Centre.position = transform.position;
        }
        
        if (Centre.localPosition.magnitude > RangeLimit)
            Centre.localPosition = Vector3.ClampMagnitude(Centre.localPosition, RangeLimit);
        
        _normalizedMagnitude = Centre.localPosition.magnitude / RangeLimit;
        Range = Centre.transform.localPosition.normalized * _normalizedMagnitude;
    }
    
}
