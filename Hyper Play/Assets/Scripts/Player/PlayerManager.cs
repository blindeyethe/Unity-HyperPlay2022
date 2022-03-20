using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }
    private void Start() => DisableController();

    private void OnEnable()
    {
        UiStartGame.OnGameStart += PlayerRun;
        PlatformFinish.OnLvlFinish += PlayerCelebrate;
    }

    private void OnDisable()
    {
        UiStartGame.OnGameStart -= PlayerRun;
        PlatformFinish.OnLvlFinish -= PlayerCelebrate;
    }
    
    private void DisableController() => _controller.enabled = false;

    private void PlayerRun()
    {
        _controller.enabled = true;
        _animator.SetBool("Running", true);
    }

    private void PlayerCelebrate()
    {
        DisableController();
        _animator.SetBool("Win", true);
    }
}
