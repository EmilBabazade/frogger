using Frogger.Managers;
using Godot;

namespace Frogger.scenes.UIScenes;
public partial class Title : Control
{
    [Export]
    private Button _playButton;

    [Export]
    private Label _scoreLabel;

    public override void _Ready()
    {
        SetScore();
        _playButton.ButtonUp += GoToMain;

        base._Ready();
    }

    private void SetScore()
    {
        _scoreLabel.Text = $"HIGH SCORE: {ScoreManager.HighScore}";
    }

    private void GoToMain()
    {
        ScoreManager.Score = 0;
        SceneManager.GoToScene(GetTree(), SceneEnum.Game);
    }
}
