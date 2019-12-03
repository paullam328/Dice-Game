using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject _currentDice1;
    private GameObject _currentDice2;
    [SerializeField]
    private GameObject _diceObj1;
    [SerializeField]
    private GameObject _diceObj2;
    [SerializeField]
    private GameObject _spawnPoint1;
    [SerializeField]
    private GameObject _spawnPoint2;
    
    public int _score = 0;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private GameObject _roundScoreText;

    public float _roundTimer = 100000;
    public float _roundTime = 0;

    private bool _isScoreCalculated = false;
    private bool _firstGameStarted = false;

    //Game Over:
    private bool _isGameOver = false;

    [SerializeField]
    private GameObject _gameOverMenu;
    [SerializeField]
    private GameObject _rollButton;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //For debugging purpose:
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            RollOne();
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            RollTwo();
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            RollThree();
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            RollFour();
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            RollFive();
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            RollSix();
        }

        if (_roundTimer > _roundTime)
        {
            if (_currentDice1 && _currentDice2)
            {
                if (!_isScoreCalculated)
                {
                    int roundScore = _currentDice1.GetComponent<Dice>()._finalResult + _currentDice2.GetComponent<Dice>()._finalResult;
                    _score += roundScore;
                    _scoreText.text = "Score: " + _score;
                    if (!_roundScoreText.activeSelf)
                    {
                        _roundScoreText.GetComponent<Text>().text = roundScore.ToString();
                        _roundScoreText.SetActive(true);
                    }
                    _isScoreCalculated = true;

                    if (_currentDice1.GetComponent<Dice>()._finalResult == _currentDice2.GetComponent<Dice>()._finalResult)
                    {
                        _isGameOver = true;
                    }

                }
            }
        }
        
        _roundTimer += Time.deltaTime;

        if (_isGameOver && _roundTimer > _roundTime + 0.5f)
        {
            if (!_gameOverMenu.activeSelf)
            {
                _gameOverMenu.SetActive(true);
                _rollButton.SetActive(false);

            }
        }
    }

    public void CreateDiceRoll(int num)
    {

        if (_roundTimer > _roundTime + 0.5f && !_isGameOver)
        {
            //Reset timer:
            _roundScoreText.SetActive(false);
            _isScoreCalculated = false;
            _roundTimer = 0;

            if (_currentDice1 != null && _currentDice2 != null)
            {
                GameObject oldDice1 = _currentDice1;
                _currentDice1 = null;
                Destroy(oldDice1);

                GameObject oldDice2 = _currentDice2;
                _currentDice2 = null;
                Destroy(oldDice2);
            }

            _currentDice1 = GameObject.Instantiate(_diceObj1, _spawnPoint1.transform.position, Quaternion.identity, null);
            _currentDice1.GetComponent<Dice>().Roll(num);

            _currentDice2 = GameObject.Instantiate(_diceObj2, _spawnPoint2.transform.position, Quaternion.identity, null);
            _currentDice2.GetComponent<Dice>().Roll(num);
        }
    }

    //Rolling Dice:
    void RollOne()
    {
        CreateDiceRoll(1);
    }
    void RollTwo()
    {
        CreateDiceRoll(2);
    }
    void RollThree()
    {
        CreateDiceRoll(3);
    }
    void RollFour()
    {
        CreateDiceRoll(4);
    }
    void RollFive()
    {
        CreateDiceRoll(5);
    }
    void RollSix()
    {
        CreateDiceRoll(6);
    }
}
