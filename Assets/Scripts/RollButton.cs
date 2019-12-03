using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollButton : MonoBehaviour
{ 
    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private DebugCheckbox _debugCheckbox;

    private bool _isCheckboxChecked = false;

    public void RollDice()
    {
        if (_gameManager._roundTimer > _gameManager._roundTime + 0.5f)
        {
            if (_debugCheckbox._startDebug)
            {
                _debugCheckbox._debugRoundCounter++;
            }
            if (_debugCheckbox._debugRoundCounter >= 5)
            {
                _gameManager.CreateDiceRoll(1);
            }
            else
            {
                _gameManager.CreateDiceRoll(-1);
            }
        }
    }
}
