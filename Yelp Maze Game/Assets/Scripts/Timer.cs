// Builtins
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;
using UnityEngine.UI;


/*! Timer class for the player
* Toggle 'isTiming' in the script UI
* to pause the timer. When the player reaches
* Spongebob then the 'isTiming' bool is set to False.
*/
public class Timer : MonoBehaviour
{
    /*! On initialize */
	void Start ()
    {
        startTime = UnityEngine.Time.time;
        isTiming = true;
	}

    /*! Game loop */
	void Update ()
    {
        if (isTiming)
        {
            SetCurrentTime();
            SetMinutesOfCurrentTime();
            SetSecondsOfCurrentTime();
            SetTimerText();
        }
	}

    /*! Sets current time */
    private void SetCurrentTime()
    {
        currentTime = UnityEngine.Time.time - startTime;
    }

    /*! Sets the current seconds of timing
    * Uses the 'f2' string modifier to limit miliseconds to 2 digits
    */
    private void SetSecondsOfCurrentTime()
    {
        seconds = SeparateSecondsAndMiliseconds(
            (currentTime % 60).ToString("f2")
        );
    }

    /*! Sets the timer text in the UI Canvas
    * Note that seconds is a string array
    */
    private void SetTimerText()
    {
        timerText.text = minutes + ":" + int.Parse(seconds[0]).ToString("D2") + ":" + seconds[1];
    }

    /*! Sets the current minutes of timing */
    private void SetMinutesOfCurrentTime()
    {
        minutes = ((int)currentTime / 60).ToString("D2");
    }

    /*! Returns seconds and miliseconds in a string array.
    *  Purpose is to have seconds formatted as seconds : miliseconds
    *  with one padded zero.
    *  Example:
    *      02:32
    */
    private string[] SeparateSecondsAndMiliseconds(string seconds)
    {
        string[] secondsComponents = seconds.Split('.');
        return new string[]{ int.Parse(secondsComponents[0]).ToString("D2"),
                             secondsComponents[1]
                           };
    }

    public Text timerText;
    public bool isTiming;

    private float startTime;
    private float currentTime;
    private string minutes;
    private string[] seconds;
}
