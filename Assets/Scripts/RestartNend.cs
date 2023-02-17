using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RestartNend : MonoBehaviour
{
    public void backtoMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

}
