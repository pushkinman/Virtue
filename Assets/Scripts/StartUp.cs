using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    private IInputManager _inputManager;
    private IPlayer _player;
    private IPlayerCamera _playerCamera;

    private void Awake()
    {
        _inputManager = CompositionRoot.GetInputManager();
        _player = CompositionRoot.GetPlayer();
        _playerCamera = CompositionRoot.GetPlayerCamera();
    }

    private void Start()
    {
        _playerCamera.SetFollowTarget(_player.Transform);
        _playerCamera.SetLookAtTarget(_player.Transform);

        _player.CameraTransform = _playerCamera.Transform; 
        
        _inputManager.InputProvider.PlayerMoved += _player.Move;
        _inputManager.InputProvider.PlayerMoved += _player.PlayerAnimator.PlayMoveAnimation;
        _inputManager.InputProvider.FreeLookEnabled += _player.SetFreeLookState;
        _inputManager.InputProvider.PlayerJumped += _player.TryJump;
    }

    private void OnDestroy()
    {
        
    }
}
