using UnityEngine;
using UnityEngine.SceneManagement;
using UI = UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UI.Text player1ScoreText;
    public UI.Text player2ScoreText;
    public UI.Text winText;
    public GameObject winPanel;

    private int player1Score = 0;
    private int player2Score = 0;
    public int winScore = 5;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
        winPanel.SetActive(false);
    }

    public void AddScore(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Score++;
        }
        else if (playerNumber == 2)
        {
            player2Score++;
        }

        UpdateScoreText();
        CheckWinCondition();
    }

    void UpdateScoreText()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    void CheckWinCondition()
    {
        if (player1Score >= winScore)
        {
            WinGame("Jugador 1 Gana!");
        }
        else if (player2Score >= winScore)
        {
            WinGame("Jugador 2 Gana!");
        }
    }

    void WinGame(string winner)
    {
        winText.text = winner;
        winPanel.SetActive(true);

        // Guardar record si es necesario
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.SaveHighScore(Mathf.Max(player1Score, player2Score));
        }

        Invoke("BackToMenu", 3f);
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateScoreText();
        winPanel.SetActive(false);
    }
}