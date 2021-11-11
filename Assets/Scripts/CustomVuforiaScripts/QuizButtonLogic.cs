using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizButtonLogic : MonoBehaviour
{
    public int userAnswer;

    public void QuizButtonPress (int answerNumber)
    {
        userAnswer = answerNumber;
    }
}
