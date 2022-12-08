
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Text scoreText;

    public GameObject playButton;

    public GameObject gameOver;

    public GameObject title;

    public Player player;

    public Text highScoreText;

    public GameObject highScoreLabel;

    private int score;
    private int highScore;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);
        title.SetActive(true);
        highScore = 0;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();

        title.SetActive(false);
        playButton.SetActive(false);
        gameOver.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        highScoreLabel.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Friend[] friends = FindObjectsOfType<Friend>();

        for (int i=0; i<enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }

        for (int i = 0; i < friends.Length; i++)
        {
            Destroy(friends[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        title.SetActive(false);
        playButton.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        highScoreLabel.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score >= highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString();
        }
    }



}
