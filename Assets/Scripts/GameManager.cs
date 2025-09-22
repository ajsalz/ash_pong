using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int scorePlayer1, scorePlayer2;
    public ScoreText ScoreTextLeft, ScoreTextRight;
    public ball ball; 

    // UPDATES SCORE
    public void OnScoreZoneReached(int id)
    {
        if (id == 1)
            scorePlayer1++;
        if (id == 2)
            scorePlayer2++;

        UpdateScores();
    }

    private void UpdateScores()
    {
        ScoreTextLeft.SetScore(scorePlayer1);
        ScoreTextRight.SetScore(scorePlayer2);
    }

    void Awake() { instance = this; }


}
