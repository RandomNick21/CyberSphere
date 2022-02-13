using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private float SpeedRunAnimation = 1f;
    
    [SerializeField, Range(0, 1)] private float DurationAnimationChanges;
    [SerializeField, Range(0, 1)] private float DurationTimeOffset;
    [SerializeField, Range(0, 1)] private float DurationTransition;
    
    private readonly int _runAnimationHash = Animator.StringToHash("Run");
    private readonly int _idleAnimationHash = Animator.StringToHash("Idle");

    private PlayerMovement _playerMovement;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerMovement.OnSetState += Play;
    }
    private void Play(PlayerState state)
    {
        if (state == PlayerState.Run)
            _animator.speed = SpeedRunAnimation;
        
        _animator.CrossFade((state == PlayerState.Idle) ? _idleAnimationHash : _runAnimationHash, DurationAnimationChanges, 0,
            DurationTimeOffset, DurationTransition);
        
    }
}
