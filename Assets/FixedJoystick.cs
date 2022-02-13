using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FixedJoystick : MonoBehaviour
{
    [SerializeField] private Transform Stick;
    [SerializeField] private Image Borders;
    [SerializeField] private float MaxRadius;
    
    public Vector2 Range;
    public float Horizontal => Range.x;
    public float Vertical => Range.y;
    
    public static FixedJoystick instance;

    private float NormalizedStickMagnitude => Stick.localPosition.magnitude / MaxRadius;

    public Vector2 mousePos;

    public RectTransform canvas;
    
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        MoveStick();
        
        Stick.localPosition = Vector3.ClampMagnitude(Stick.localPosition, MaxRadius);
        
        Range = Stick.transform.localPosition.normalized * NormalizedStickMagnitude;
    }
    private void MoveStick()
    {
        var mousePosition = Mouse.current.position.ReadValue();
        Vector2 mousePositionLocalPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, mousePosition, Camera.main, out mousePositionLocalPoint);
        mousePos = mousePosition;
        
        if (mousePositionLocalPoint != Vector2.zero)
        {
            Stick.position = mousePosition;
        }
        else
        {
            Stick.position = transform.position;
        }
    }
}
