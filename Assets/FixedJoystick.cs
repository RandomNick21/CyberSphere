using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class FixedJoystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform Stick;
    [SerializeField] private float MaxRadius;
    [Space] public Vector2 Range;
    
    public float Horizontal => Range.x;
    public float Vertical => Range.y;
    private float NormalizedStickMagnitude => Stick.localPosition.magnitude / MaxRadius;

    public void OnDrag(PointerEventData eventData)
    {
        Stick.position = Mouse.current.position.ReadValue();
        
        Stick.localPosition = Vector3.ClampMagnitude(Stick.localPosition, MaxRadius);
        
        Range = Stick.transform.localPosition.normalized * NormalizedStickMagnitude;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Stick.position = transform.position;
        Range = Vector2.zero;
    }
}
