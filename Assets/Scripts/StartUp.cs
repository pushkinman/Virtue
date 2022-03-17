using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    private IInputManager _inputManager;
    private IPlayer _player;
    private ICamera _camera;

    private void Awake()
    {
        _inputManager = CompositionRoot.GetInputManager();
        _player = CompositionRoot.GetPlayer();
        _camera = CompositionRoot.GetPlayerCamera();
    }

    private void Start()
    {
        _camera.SetFollowTarget(_player.Transform);
        _camera.SetLookAtTarget(_player.Transform);

        _player.CameraTransform = _camera.Transform; 
        
        _inputManager.InputProvider.PlayerMoved += _player.Move;
        _inputManager.InputProvider.PlayerMoved += _player.Move;
    }
}
