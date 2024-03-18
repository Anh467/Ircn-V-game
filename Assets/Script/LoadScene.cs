using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int sceneIndex;
    public void Play(AudioSource audio)
    {
        audio.Play();
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit(AudioSource audio)
    {
        audio.Play();
        Application.Quit();
    }
}
