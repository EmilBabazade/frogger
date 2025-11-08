using Godot;

namespace Frogger.scenes.FunScene;
public partial class FunScene : Node2D
{
    [Export]
    private Vector2 _scaleUpBy = new Vector2(0.1f, 0.1f);

    public override void _Process(double delta)
    {
        Scale += Scale * _scaleUpBy * (float)delta;

        base._Process(delta);
    }
}
