// Built in
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        GameObject hut = GameObject.Find("Hut");
        hutDirector = hut.gameObject.GetComponent<PlayableDirector>();
        hutDirector.Play();
        hasPlayedIntro = true;
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        hasPlayedIntro = false;
    }

    public void Update()
    {
        if (hutDirector && hutDirector.state == PlayState.Playing)
            return;
        if (hasPlayedIntro)
            SceneManager.LoadScene("proceduralgentest");
    }

    private PlayableDirector hutDirector;
    private bool hasPlayedIntro;
}
