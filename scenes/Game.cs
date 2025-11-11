using Frogger.Helpers;
using Frogger.scenes.CarScene;
using Frogger.scenes.PlayerScene;
using Godot;

namespace Frogger.scenes;
public partial class Game : Node2D
{
    [Export] private Timer _carSpawnTimer;
    private static readonly PackedScene _carScene = FileLoader.LoadSafe<PackedScene>("res://scenes/CarScene/car.tscn");
    [Export] private Node2D _carSpawns;

    [Export] private Area2D _area2D;

    public override void _Ready()
    {
        ConnectSignals();

        base._Ready();
    }
    private void ConnectSignals()
    {
        _carSpawnTimer.Timeout += HandleCarSpawnTimerTimeout;
        _area2D.BodyEntered += HandleArea2dBodyEntered;
    }

    public void HandleCarSpawnTimerTimeout()
    {
        var car = (Car)_carScene.Instantiate();
        var randomIdx = GD.RandRange(0, _carSpawns.GetChildCount() - 1);
        var spawn = (Marker2D)_carSpawns.GetChild(randomIdx);
        car.Position = spawn.Position;
        car.BodyEntered += body =>
        {
            if (body is Player)
            {
                GD.Print(body);
                GD.Print("Car collision");
            }
        };
        AddChild(car);
    }

    public void HandleArea2dBodyEntered(Node2D _)
    {
        //GD.Print("Player entered");
    }
}
