using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play(AudioSource audio)
    {
        audio.Play();
        SceneManager.LoadScene(0);
    }

    public void Quit(AudioSource audio)
    {
        Application.Quit();
    }
}
