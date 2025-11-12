using Frogger.Helpers;
using Godot;
using System;

namespace Frogger.scenes.CarScene;
public partial class Car : Area2D
{
    [Export]
    private Sprite2D _sprite;

    [Export]
    private VisibleOnScreenNotifier2D _visibleOnScreenNotifier;

    [Export]
    private float _speed = 100;
    private Vector2 _direction = Vector2.Left;

    private static readonly Texture2D[] _carSprites = FileLoader.LoadSafe<Texture2D>(
        "res://graphics/cars/green.png",
        "res://graphics/cars/red.png",
        "res://graphics/cars/yellow.png"
    );
    private static readonly Random _rand = new();

    public override void _Ready()
    {
        RegisterSignalHandlers();
        SetDirection();
        SetSprite();

        base._Ready();
    }
    public override void _Process(double delta)
    {
        Position += _direction * _speed * (float)delta;

        base._Process(delta);
    }

    public void IncreaseSpeed(float by)
    {
        _speed += _speed * by;
    }

    private void SetSprite()
    {
        _sprite.Texture = _carSprites[_rand.Next(_carSprites.Length)];
    }

    private void SetDirection()
    {
        if (Position.X < 0)
        {
            _direction = Vector2.Right;
            _sprite.FlipH = true;
        }
    }

    private void RegisterSignalHandlers()
    {
        _visibleOnScreenNotifier.ScreenExited += HandleCarNotVisible;
    }

    private void HandleCarNotVisible()
    {
        QueueFree();
    }

}
