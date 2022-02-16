using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private float SpeedRunAnimation = 1f;
    [SerializeField] private Animator _animator;
    
    [SerializeField, Range(0, 1)] private float DurationAnimationChanges;
    [SerializeField, Range(0, 1)] private float DurationTimeOffset;
    [SerializeField, Range(0, 1)] private float DurationTransition;
    
    private readonly int _idleAnimationHash = Animator.StringToHash("Idle");
    private readonly int _runForwardAnimationHash = Animator.StringToHash("RunForward");
    private readonly int _runDownAnimationHash = Animator.StringToHash("RunDown");
    private readonly int _runRightAnimationHash = Animator.StringToHash("RunRight");
    private readonly int _runLeftAnimationHash = Animator.StringToHash("RunLeft");

    private PlayerMovement _playerMovement;

    private void OnEnable()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerMovement.OnSetState += Play;
    }
    private void Play(PlayerState state)
    {
        _animator.speed = state == PlayerState.RunForward ? SpeedRunAnimation : 1f;

        switch (state)
        {
            case PlayerState.Idle:
                StartCrossFade(_idleAnimationHash);
                return;
            case PlayerState.RunForward:
                StartCrossFade(_runForwardAnimationHash);
                _animator.speed = SpeedRunAnimation;
                return;
            case PlayerState.RunDown:
                StartCrossFade(_runDownAnimationHash);
                return;
            case PlayerState.RunRight:
                StartCrossFade(_runRightAnimationHash);
                return;
            case PlayerState.RunLeft:
                StartCrossFade(_runLeftAnimationHash);
                return;
        }
    }
    private void StartCrossFade(int hashName)
    {
        _animator.CrossFade(hashName, DurationAnimationChanges, 0,
            DurationTimeOffset, DurationTransition);
    }
}
