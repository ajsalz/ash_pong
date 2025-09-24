using UnityEngine;

public class GameUI : MonoBehaviour
{
    public ScoreText ScoreTextPlayer1, ScoreTextPlayer2;
    public GameObject menuObject;
    public TMPro.TextMeshProUGUI winText;

    public System.Action onStartGame;


    // UPDATES SCORE TEXT
    public void UpdateScores(int scorePlayer1, int scorePlayer2)
    {
        ScoreTextPlayer1.SetScore(scorePlayer1);
        ScoreTextPlayer2.SetScore(scorePlayer2);
    }

    public void HighlightScore(int id)
    {
        if (id == 1)
            ScoreTextPlayer1.Highlight();
        else
            ScoreTextPlayer2.Highlight();
    }

    public void OnStartGameButtonClicked()
    {
        menuObject.SetActive(false);
        onStartGame?.Invoke();
    }

    public void OnGameEnds(int winnerID)
    {
        menuObject.SetActive(true);
        if(winnerID == 1)
        {
            winText.text = $"You lost!";
        }
        else
        {
            winText.text = $"You won!";

        }
    }
}
