using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    void Start()
    {
        SetTime();
    }

    public void SetTime()
    {
        float currentTime = PlayerPrefs.GetFloat("lastPlayTime");
        string minutes = ((int)currentTime / 60).ToString("D2");
        string[] seconds = SeparateSecondsAndMiliseconds(
                (currentTime % 60).ToString("f2")
            );
        winTime.text = minutes + ":" + int.Parse(seconds[0]).ToString("D2") + ":" + seconds[1];
    }

    private string[] SeparateSecondsAndMiliseconds(string seconds)
    {
        string[] secondsComponents = seconds.Split('.');
        return new string[]{ int.Parse(secondsComponents[0]).ToString("D2"),
                             secondsComponents[1]
                           };
    }

    public Text winTime;
}
