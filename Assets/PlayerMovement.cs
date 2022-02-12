using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    
    private CharacterController _controller;

    private FixedJoystick _fixedJoystick;
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        
        _fixedJoystick = FixedJoystick.instance;
    }
    private void Update()
    {
        _controller.Move(new Vector3(_fixedJoystick.Range.x, 0, _fixedJoystick.Range.y) * Speed);
        print(_fixedJoystick.Range);
    }
}
