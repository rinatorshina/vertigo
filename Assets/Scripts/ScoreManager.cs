using TMPro;
using UnityEngine;

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
        }

        scoreText.text = "SCORE: " + score.ToString();

    }

    public void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void AddPoint()
    {
        score += 10;
        scoreText.text = "SCORE: " + score.ToString();

        if (highscore < score)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }

    }

}
