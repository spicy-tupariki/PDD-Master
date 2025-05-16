using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public QuestionData[] categories;
    private QuestionData selectedCategory;
    private int currentQuestionIndex = 0;
    public TMP_Text questionText;
    public Image questionImage;
    public Button[] replyButtons;
    public TMP_Text answerText;
    public Button acceptButton;
    public Button GoNextButton;
    public TMP_Text scoreTrueText;
    public TMP_Text scoreFalseText;
    private int previosCorrect;
    private int previosSelect;
    private bool alreadySelected = false;

    public void Start()
    {
        SelectCategory(0);
    }

    public void SelectCategory(int categoryIndex)
    {
        selectedCategory = categories[categoryIndex];
        currentQuestionIndex = 0;
        DisplayQuestion();
    }

    public void DisplayQuestion()
    {
        if (selectedCategory == null) return;
        var question = selectedCategory.questions[currentQuestionIndex];
        question.correctPeplyIndex = 2;
        questionText.text = question.questionText;
        questionImage.sprite = question.questionImage;
        var correctIndex = Random.Range(1, replyButtons.Length + 1);
        var alreadyAdded = new List<int>();
        for (int i = 0; i < replyButtons.Length; i++)
        {
            if (i == correctIndex - 1)
            {
                TMP_Text buttonText = replyButtons[correctIndex - 1].GetComponentInChildren<TMP_Text>();
                buttonText.text = question.replies[question.correctPeplyIndex - 1];
            }
            else
            {
                var j = Random.Range(0, replyButtons.Length);
                while (j == question.correctPeplyIndex - 1 || alreadyAdded.Contains(j))
                {
                    j++;
                    if (j > 3)
                    {
                        j = 0;
                    }
                }
                alreadyAdded.Add(j);
                TMP_Text buttonText = replyButtons[i].GetComponentInChildren<TMP_Text>();
                buttonText.text = question.replies[j];
            }
        }
        question.correctPeplyIndex = correctIndex;
    }

    public void OnReplySelected(int replyIndex)
    {
        if (!alreadySelected)
        {
            var question = selectedCategory.questions[currentQuestionIndex];
            if (question.correctPeplyIndex == replyIndex)
            {
                replyButtons[replyIndex - 1].GetComponent<Image>().color = Color.green;
                scoreTrueText.text = (int.Parse(scoreTrueText.text) + 1).ToString();
                //NextQuestion();
            }
            else
            {
                replyButtons[replyIndex - 1].GetComponent<Image>().color = Color.red;
                replyButtons[question.correctPeplyIndex - 1].GetComponent<Image>().color = Color.green;
                scoreFalseText.text = (int.Parse(scoreFalseText.text) + 1).ToString();
                //for (int i = 0; i < replyButtons.Length; i++)
                //{
                //    replyButtons[i].gameObject.SetActive(false);
                //}
            }
            Debug.Log("sdsr");
            answerText.text = question.answerText;
            answerText.gameObject.SetActive(true);
            acceptButton.gameObject.SetActive(true);
            previosCorrect = question.correctPeplyIndex;
            previosSelect = replyIndex;
            alreadySelected = true;
        }
    }

    public void NextQuestion()
    {
        replyButtons[previosSelect -1].GetComponent<Image>().color = new Color(0.97f, 0.92f, 0.77f);
        replyButtons[previosCorrect - 1].GetComponent<Image>().color = new Color(0.97f, 0.92f, 0.77f);
        //for (int i = 0; i < replyButtons.Length; i++)
        //{
        //    replyButtons[i].gameObject.SetActive(true);
        //}
        answerText.gameObject.SetActive(false);
        acceptButton.gameObject.SetActive(false);
        currentQuestionIndex++;
        if (currentQuestionIndex < selectedCategory.questions.Length)
            DisplayQuestion();
        else
        {
            for (int i = 0; i < replyButtons.Length; i++)
            {
                replyButtons[i].gameObject.SetActive(false);
            }
            answerText.text = "Молодец, а теперь пройди практику        ";
            answerText.gameObject.SetActive(true);
            GoNextButton.gameObject.SetActive(true);
            questionImage.gameObject.SetActive(false);
            questionText.gameObject.SetActive(false);
        }
        alreadySelected = false;
    }
}
