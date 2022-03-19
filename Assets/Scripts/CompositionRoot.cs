using System;
using System.Collections;
using System.Collections.Generic;
using Cameras;
using Enums;
using Extensions;
using Input;
using Input;
using Interfaces;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CompositionRoot : MonoBehaviour
{
    private static IInputManager _inputManager;
    private static IPlayer _player;
    private static IPlayerCamera _playerCamera;
    private static IResourceManager _resourceManager;

    public static IInputManager GetInputManager()
    {
        return _inputManager ??= new InputManager();
    }

    public static IPlayer GetPlayer()
    {
        var resourceManager = GetResourceManager();
        return _player ??= resourceManager.LoadResource<Player.Player, EPlayer>(EPlayer.Player);
    }
    
    public static IPlayerCamera GetPlayerCamera()
    {
        var resourceManager = GetResourceManager();
        return _playerCamera ??= resourceManager.LoadResource<PlayerCamera, ECamera>(ECamera.PlayerCamera);
    }

    private static IResourceManager GetResourceManager()
    {
        return _resourceManager ??= GameObjectExtensions.CreateGameObjectWithComponent<ResourceManager>();
    }
}
