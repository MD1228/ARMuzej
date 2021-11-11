using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System;

public class SceneHandler:MonoBehaviour
{
    // load scene with animation length
    public async void LoadScene(int sceneIndex, Animation fadeAnimation)
    {
        await Task.Delay(TimeSpan.FromSeconds(fadeAnimation.clip.length));
        SceneManager.LoadScene(sceneIndex);
    }

    // load scene instantly
    public void LoadSceneInstant(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // exit application
    public void ExitApplication()
    {
        Application.Quit();   
    }

}
