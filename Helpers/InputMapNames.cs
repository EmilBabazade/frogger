using Godot;

namespace Frogger.Helpers;

/// <summary>
/// Direction names defined in input map
/// </summary>
public static class InputMapNames
{
    public static StringName Left { get; } = "left";
    public static StringName Right { get; } = "right";
    public static StringName Down { get; } = "down";
    public static StringName Up { get; } = "up";
    public static StringName Confirm { get; } = "confirm";
}
