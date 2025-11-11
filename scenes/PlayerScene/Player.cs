using Frogger.Helpers;
using Godot;

namespace Frogger.scenes.PlayerScene;
public partial class Player : CharacterBody2D
{
    [Export]
    private int _speed = 200;
    [Export]
    private AnimatedSprite2D _animatedSprite;

    private Vector2 _direction = Vector2.Zero;
    //hi
    public override void _PhysicsProcess(double delta)
    {
        Movement(delta);
        Animation();
        DoSomething();

        MoveAndSlide();
        base._Process(delta);
    }

    private void Movement(double delta)
    {
        _direction = Input.GetVector(InputMapNames.Left, InputMapNames.Right, InputMapNames.Up, InputMapNames.Down);
        Velocity = _direction * _speed * (float)delta;
    }

    private void Animation()
    {
        if (_direction == Vector2.Zero)
        {
            _animatedSprite.Frame = 0;
            return;
        }

        if (_direction.Y != 0)
        {
            _animatedSprite.Animation = _direction.Y > 0 ? "down" : "up";
        }
        else
        {
            _animatedSprite.Play("horizontal");
            _animatedSprite.FlipH = _direction.X > 0;
        }
    }

    private static void DoSomething()
    {
        if (Input.IsActionJustPressed(InputMapNames.Confirm)) GD.Print("you pressed space");
    }
}