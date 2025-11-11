using Godot;

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

    public override void _Ready()
    {
        RegisterSignalHandlers();
        SetDirection();

        base._Ready();
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

    public override void _Process(double delta)
    {
        Position += _direction * _speed * (float)delta;

        base._Process(delta);
    }
}
