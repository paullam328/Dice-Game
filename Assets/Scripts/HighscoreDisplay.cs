using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreDisplay : MonoBehaviour
{
    private int highscore = -1;
    void Start()
    {
        StreamReader reader = new StreamReader("./Json/highscore.json");
        string json = reader.ReadToEnd();
        HighScore hs = JsonUtility.FromJson<HighScore>(json);
        GetComponent<Text>().text = "High Score: " + hs.highscore;
        reader.Close(); //need to close the reader/writer or else there would be a violation error as these processes run at the same time
    }
}
