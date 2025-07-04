using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public static ScoreManager Instance { get; private set; }

    public int score = 0;
    public int highscore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        scoreText.text = "SCORE: " + score.ToString();

    }

    public void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        scoreText = GameObject.Find("Score")?.GetComponent<TMP_Text>();
        UpdateScoreText();
    }

    public void AddPoint()
    {
        score += 10;
        UpdateScoreText();

        if (highscore < score)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }

    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "SCORE: " + score.ToString();
        }
    }

}
