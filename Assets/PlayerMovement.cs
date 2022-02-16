using System;
using UnityEngine;

public enum PlayerState : byte
{
    Idle,
    RunForward,
    RunDown,
    RunRight,
    RunLeft
}
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float SpeedMove = 1f;
    [SerializeField] private float SpeedRotate = 1f;
    
    private CharacterController _controller;

    [SerializeField] private FixedJoystick _joystick;

    private PlayerState _currentState = PlayerState.Idle;
    public Action<PlayerState> OnSetState;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        DefineState();

        _controller.Move(transform.TransformDirection(new Vector3(_joystick.Range.x, 0, _joystick.Range.y)) * (SpeedMove * Time.deltaTime) );
        
        /*var angel = Mathf.Atan2(_joystick.Horizontal, _joystick.Vertical) * Mathf.Rad2Deg;
        if (angel == 0)
            angel = transform.eulerAngles.y;
        
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angel, 0), SpeedRotate * Time.deltaTime);*/
    }
    private void DefineState()
    {
        if (_joystick.Range == Vector2.zero)
        {
            SetState(PlayerState.Idle);
            return;
        }
        
        var angel = Mathf.Atan2(_joystick.Horizontal, _joystick.Vertical) * Mathf.Rad2Deg;
        
        if(angel > -45 && angel < 45)
            SetState(PlayerState.RunForward);
        else if(angel > 45 && angel < 135)
            SetState(PlayerState.RunRight);
        else if(angel > 135 && angel < 225)
            SetState(PlayerState.RunDown);
        else if(angel < -45 && angel > -135)
            SetState(PlayerState.RunLeft);
    }
    private void SetState(PlayerState state)
    {
        if(state == _currentState)
            return;
        
        _currentState = state;
        OnSetState?.Invoke(_currentState);
    }
}
