using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TMP_Text highscoreText;

    private void Start()
    {
        highscoreText.text = "HIGHSCORE: " + ScoreManager.Instance.highscore.ToString();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }


}
