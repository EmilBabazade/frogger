namespace Frogger.Managers;
public static class ScoreManager
{
    private static int _score;
    public static int Score
    {
        get => _score;
        set
        {
            _score = value;
            if (_score > HighScore)
            {
                HighScore = _score;
            }
        }
    }

    public static int HighScore { get; private set; }
}
