using Frogger.Helpers;
using Frogger.Managers;
using Frogger.scenes.CarScene;
using Godot;

namespace Frogger.scenes;
public partial class Game : Node2D
{
    [Export]
    private Timer _carSpawnTimer;
    private static readonly PackedScene _carScene = FileLoader.LoadSafe<PackedScene>("res://scenes/CarScene/car.tscn");
    [Export]
    private Node2D _carSpawns;
    [Export]
    private int _increaseGameTimeEverySeconds = 50;
    [Export]
    private float _decreaseCarSpawnTimeBy = 0.1f;
    [Export]
    private float _carSpawnTimeMin = 0.1f;

    [Export]
    private Label _gameTimeLabel;
    [Export]
    private Timer _gameTimeTimer;
    private int _gameTime = 0;
    private int _level = 0;

    [Export]
    private Area2D _playArea;

    public override void _Ready()
    {
        _gameTimeTimer.Stop();

        ConnectSignals();

        base._Ready();
    }
    private void ConnectSignals()
    {
        _carSpawnTimer.Timeout += HandleCarSpawnTimerTimeout;
        _gameTimeTimer.Timeout += HandleGameTimeIncrease;
        _playArea.BodyEntered += HandlePlayAreaEntered;
        _playArea.BodyExited += HandlePlayAreaExited;
    }

    public void HandleCarSpawnTimerTimeout()
    {
        var car = (Car)_carScene.Instantiate();
        var randomIdx = GD.RandRange(0, _carSpawns.GetChildCount() - 1);
        var spawn = (Marker2D)_carSpawns.GetChild(randomIdx);
        car.Position = spawn.Position;
        car.IncreaseSpeed(_decreaseCarSpawnTimeBy * _level);
        car.BodyEntered += GameOver;
        AddChild(car);
    }

    private void GameOver(Node2D _)
    {
        ScoreManager.Score = _gameTime;
        SceneManager.GoToScene(GetTree(), SceneEnum.Title);
    }

    public void HandleGameTimeIncrease()
    {
        _gameTime++;
        _gameTimeLabel.Text = _gameTime.ToString();

        if (_gameTime % _increaseGameTimeEverySeconds == 0 && _carSpawnTimer.WaitTime > _carSpawnTimeMin)
        {
            _carSpawnTimer.WaitTime -= _carSpawnTimer.WaitTime * _decreaseCarSpawnTimeBy;
            _level++;
        }
    }

    public void HandlePlayAreaEntered(Node2D body)
    {
        _gameTimeTimer.Start();
    }

    public void HandlePlayAreaExited(Node2D body)
    {
        _gameTimeTimer.Stop();
    }
}
