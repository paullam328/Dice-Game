using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private GameObject _newHighScoreText;

    private int _prevHighScore;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Your Score: " + _gameManager._score.ToString();

        StreamReader reader = new StreamReader("./Json/highscore.json");
        string json = reader.ReadToEnd();
        HighScore hs = JsonUtility.FromJson<HighScore>(json);
        _prevHighScore = hs.highscore;
        reader.Close();

        if (_gameManager._score > _prevHighScore)
        {
            //Set Active:
            _newHighScoreText.SetActive(true);

            //store high score:
            HighScore newHs = new HighScore();
            newHs.highscore = _gameManager._score;
            string highscoreStr = JsonUtility.ToJson(newHs);
            Debug.Log(Application.persistentDataPath + "./Json/highscore.json");
            StreamWriter writer = new StreamWriter("./Json/highscore.json");
            writer.Write(highscoreStr);
            writer.Close();
        }
    }
}
