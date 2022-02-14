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

    public static FixedJoystick instance;

    private void Awake()
    {
        instance = this;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Stick.position = Mouse.current.position.ReadValue();
        
        Stick.localPosition = Vector3.ClampMagnitude(Stick.localPosition, MaxRadius);

#if UNITY_EDITOR
        Vector2 to = default;
        
        if(Input.GetKeyDown(KeyCode.W))
            to += Vector2.right;
        else if(Input.GetKeyDown(KeyCode.S))
            to += Vector2.left;
        else if(Input.GetKeyDown(KeyCode.A))
            to += Vector2.up;
        else if (Input.GetKeyDown(KeyCode.D))
            to += Vector2.down;

        Stick.position = to;
#endif
        
        Range = Stick.transform.localPosition.normalized * NormalizedStickMagnitude;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Stick.position = transform.position;
        Range = Vector2.zero;
    }
}
