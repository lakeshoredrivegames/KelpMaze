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
        if (!hut)
        {
            SceneManager.LoadScene("KelpForest");
            return;
        }
        hutSoundSource = hut.gameObject.GetComponent<AudioSource>();
        hutSoundSource.clip = buttonPress;
        hutSoundSource.Play();
        hutDirector = hut.gameObject.GetComponent<PlayableDirector>();
        hutDirector.Play();
        hasPlayedAnimation = true;
        hasPlayedSound = false;
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

    public void FixedUpdate()
    {
        if (hutDirector && hutDirector.state == PlayState.Playing || hutDirector && hutSoundSource.isPlaying)
            return;

        if (hasPlayedIntro && !hutSoundSource.isPlaying)
        {
            SceneManager.LoadScene("KelpForest");
        }

        if(hasPlayedAnimation && !hasPlayedSound)
        {
            hutSoundSource.clip = crashSound;
            hutSoundSource.Play();
            hasPlayedSound = true;
            hasPlayedIntro = true;
        }
    }

    public AudioClip buttonPress;
    public AudioClip crashSound;

    private PlayableDirector hutDirector;
    private AudioSource hutSoundSource;
    private bool hasPlayedAnimation;
    private bool hasPlayedSound;
    private bool hasPlayedIntro;
}
