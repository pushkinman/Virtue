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
using Camera = Cameras.Camera;

public class CompositionRoot : MonoBehaviour
{
    private static IInputManager _inputManager;
    private static IPlayer _player;
    private static ICamera _camera;
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
    
    public static ICamera GetPlayerCamera()
    {
        var resourceManager = GetResourceManager();
        return _camera ??= resourceManager.LoadResource<Camera, ECamera>(ECamera.Camera);
    }

    private static IResourceManager GetResourceManager()
    {
        return _resourceManager ??= GameObjectExtensions.CreateGameObjectWithComponent<ResourceManager>();
    }
}
