using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenSetup : MonoBehaviour
{
    public Text applicationName; 

    void Start()
    {
       applicationName.text = SingletonManager.instance.language.ApplicationName;
    }
}
