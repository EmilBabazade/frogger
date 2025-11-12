using Frogger.Helpers;
using Godot;
using System.Collections.Generic;

namespace Frogger.Managers;
public static class SceneManager
{
    private static readonly Dictionary<SceneEnum, PackedScene> _scenes = new()
    {
        [SceneEnum.Game] = FileLoader.LoadSafe<PackedScene>("res://scenes/game.tscn"),
        [SceneEnum.Title] = FileLoader.LoadSafe<PackedScene>("res://scenes/UIScenes/title.tscn"),
    };

    public static void GoToScene(SceneTree sceneTree, SceneEnum scene)
    {
        sceneTree.CallDeferred(SceneTree.MethodName.ChangeSceneToPacked, _scenes[scene]);
    }
}
