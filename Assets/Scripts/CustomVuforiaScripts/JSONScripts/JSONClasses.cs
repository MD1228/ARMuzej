using System.Collections;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;

// classes for JSON parser
[Serializable]
public class Root
{
    public Languages[] Languages;
}

[Serializable]
public class Answers
{
    public string Answer; 
}

[Serializable]
public class Questions
{
    public string Question;
    public Answers[] Answers;
    public int Correct_Answer;
}

[Serializable]
public class QuizQuestions
{
    public string QuizDescription;
    public string Start;
    public string StartAgain;
    public string QuizResults;

    public Questions[] Questions;
}

[Serializable]
public class BasicInfoText
{
    public string AnimalName;
    public string OrderName;
    public string Lifespan;
}

[Serializable]
public class ARData 
{
    public string TrackerName;

    public string CardURL;
    public BasicInfoText[] BasicInfoText;
    public string DescriptionText;
}

[Serializable]
public class ARDataKeys 
{
    public string TrackerName;

    public string AnimalName;
    public string OrderName;
    public string Lifespan;

}

[Serializable]
public class ARApplication
{
    public string BasicInfo;
    public string Description;
    public string Card;
    public ARData[] ARData;
    public ARDataKeys[] ARDataKeys;

}

[Serializable]
public class Languages
{
    public string LanguageName;
    public string ApplicationName;
    public string Quiz;
    public string Exit;
    public List<ARApplication> ARApplication;
    public List<QuizQuestions> QuizQuestions;
}