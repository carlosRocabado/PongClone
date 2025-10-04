using UnityEngine;
using UnityEngine.SceneManagement;
using UI = UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public UI.Text highScoreText;

    void Start()
    {
        // Mostrar puntuación máxima
        if (SaveManager.Instance != null)
        {
            highScoreText.text = "Record: " + SaveManager.Instance.LoadHighScore().ToString();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        UnityEngine.Application.Quit();
    }
}