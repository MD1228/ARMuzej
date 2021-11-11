using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuLocalisation : MonoBehaviour
{

    public Text applicationName;

    public Text quiz;
    public Text exit;


    void Start()
    {
       applicationName.text = SingletonManager.instance.language.ApplicationName;

       quiz.text = SingletonManager.instance.language.Quiz;
       exit.text = SingletonManager.instance.language.Exit;

    }
}
