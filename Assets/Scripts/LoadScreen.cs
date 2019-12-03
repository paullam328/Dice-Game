using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    public void OnStart()
    {
        SceneManager.LoadScene(sceneName);
    }
}
