using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public GameObject currentQuestion;

    public GameObject continueButton;
    public GameObject confirmButton;
    public GameObject quizResultsText;

    public int totalSumOfCorrectAnswers;

    public int currentQuestionCorrectAnswer;

    public Text quizDescription;
    public Text exit;
    public Text start;

    public Text questionRemainder;

    public GameObject quizQuestionsPanel;

    public Transform question;

    public int currentQuestionNumber;

    List<QuizQuestions> quizQuestions;

    void Start()
    {
        quizDescription.text = SingletonManager.instance.language.QuizQuestions[0].QuizDescription;
        exit.text = SingletonManager.instance.language.Exit;
        start.text = SingletonManager.instance.language.QuizQuestions[0].Start;
        quizQuestions = SingletonManager.instance.language.QuizQuestions;

    }

    public void QuizStart()
    {
        quizDescription.gameObject.SetActive(false);
        quizQuestionsPanel.SetActive(true);
        start.gameObject.SetActive(false);
        quizResultsText.SetActive(false);


        QuizQuestionInitialization();
    }

    public void ConfirmQuizQuestion()
    {
        Destroy(currentQuestion);
        QuizQuestionInitialization();
    }

    public void QuizQuestionInitialization()
    {

        continueButton.SetActive(false);
        confirmButton.SetActive(true);

        if (currentQuestionNumber < 10)
        {
            Transform x = Instantiate(question, new Vector3(0 * 2.0F, 0, 0), Quaternion.identity);

            x.SetParent(quizQuestionsPanel.transform);
            x.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

            System.Random r = new System.Random();
            int genRand = r.Next(0, 30);


            print(genRand);

            currentQuestion = x.gameObject;
            currentQuestionCorrectAnswer = quizQuestions[0].Questions[genRand].Correct_Answer;

            x.GetChild(0).GetComponentInChildren<Text>().text = quizQuestions[0].Questions[genRand].Answers[0].Answer;

            x.GetChild(1).GetComponentInChildren<Text>().text = quizQuestions[0].Questions[genRand].Answers[1].Answer;

            x.GetChild(2).GetComponentInChildren<Text>().text = quizQuestions[0].Questions[genRand].Answers[2].Answer;
            x.GetChild(3).GetComponent<Text>().text = quizQuestions[0].Questions[genRand].Question;

            currentQuestionNumber++;
            questionRemainder.text = currentQuestionNumber + "/10";
        }
        else
        {
            quizResultsText.SetActive(true);
            quizResultsText.GetComponent<Text>().text = quizQuestions[0].QuizResults + " " + totalSumOfCorrectAnswers + "/10";
    
            currentQuestionNumber = 0;
            start.gameObject.SetActive(true);
            quizQuestionsPanel.SetActive(false);
        }
    }


public void AnswerConfirm()
    {
        continueButton.SetActive(true);
        confirmButton.SetActive(false);

        if (currentQuestionCorrectAnswer == currentQuestion.GetComponent<QuizButtonLogic>().userAnswer)
        {
            var colors = currentQuestion.transform.GetChild(currentQuestionCorrectAnswer).GetComponent<Button>().colors;

            colors.normalColor = Color.green;
            currentQuestion.transform.GetChild(currentQuestionCorrectAnswer).GetComponent<Button>().colors = colors;
            totalSumOfCorrectAnswers++;

        }

        else
        {
            var colors = currentQuestion.transform.GetChild(currentQuestionCorrectAnswer).GetComponent<Button>().colors;

            colors.normalColor = Color.red;
            currentQuestion.transform.GetChild(currentQuestionCorrectAnswer).GetComponent<Button>().colors = colors;
        }

    }

    public void QuizExit()
    {
        quizQuestionsPanel.SetActive(false);

    }
}