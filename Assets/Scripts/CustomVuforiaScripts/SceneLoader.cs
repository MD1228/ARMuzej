using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System;

// class to load scene without delay
public class SceneLoader : MonoBehaviour
{
    public int sceneIndex;
    public Animation transitionAnimation;

    void Start() 
    {
        SceneHandler sceneManagement = new SceneHandler();
        sceneManagement.LoadScene(sceneIndex, transitionAnimation);
    }

}
