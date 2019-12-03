using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class DebugCheckbox : MonoBehaviour
{
    private Toggle tog;
    public int _debugRoundCounter;
    public bool _startDebug;

    void Start()
    {
        tog = GetComponent<Toggle>();
    }

    public void OnDebugCheckbox(bool val)
    {
        _startDebug = tog.isOn;
        _debugRoundCounter = 0;
    }

    private void Update()
    {
        Debug.Log(_debugRoundCounter);
    }
}
