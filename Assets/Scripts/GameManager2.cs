using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameManager2 : MonoBehaviour
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
    public Image EndImage;
    public Sprite WinSprite;
    public Sprite LoseSprite;
    private int previosCorrect;
    private int previosSelect;
    private bool alreadySelected = false;
    private int scoreTrue;
    private int[] QuestionsAnswers;
    private List<GameObject> PreviosQuestionCubes = new List<GameObject>();

    public Texture2D textureFalse;
    public Texture2D textureTrue;
    public Texture2D textureCurrrent;
    public Texture2D textureNew;

    public Canvas canvas;

    public void Start()
    {
        SelectCategory(0);
    }

    public void SelectCategory(int categoryIndex)
    {
        selectedCategory = categories[categoryIndex];
        currentQuestionIndex = 0;
        QuestionsAnswers = new int[selectedCategory.questions.Length];
        QuestionsAnswers[0] = 2;
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
                    if (j > 2)
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
        DrawQuestionsCubes();
    }

    public void OnReplySelected(int replyIndex)
    {
        if (!alreadySelected)
        {
            var question = selectedCategory.questions[currentQuestionIndex];
            if (question.correctPeplyIndex == replyIndex)
            {
                replyButtons[replyIndex - 1].GetComponent<Image>().color = new Color(0.23f, 0.72f, 0.45f);
                //NextQuestion();
                QuestionsAnswers[currentQuestionIndex] = 1;
                scoreTrue++;
            }
            else
            {
                replyButtons[replyIndex - 1].GetComponent<Image>().color = new Color(0.93f, 0.26f, 0.22f);
                replyButtons[question.correctPeplyIndex - 1].GetComponent<Image>().color = new Color(0.23f, 0.72f, 0.45f);
                QuestionsAnswers[currentQuestionIndex] = -1;
                //for (int i = 0; i < replyButtons.Length; i++)
                //{
                //    replyButtons[i].gameObject.SetActive(false);
                //}
            }
            answerText.text = question.answerText;
            answerText.gameObject.SetActive(true);
            acceptButton.gameObject.SetActive(true);
            previosCorrect = question.correctPeplyIndex;
            previosSelect = replyIndex;
            alreadySelected = true;
        }
        DrawQuestionsCubes();
    }

    public void NextQuestion()
    {
        replyButtons[previosSelect - 1].GetComponent<Image>().color = new Color(0.13f, 0.13f, 0.13f);
        replyButtons[previosCorrect - 1].GetComponent<Image>().color = new Color(0.13f, 0.13f, 0.13f);
        //for (int i = 0; i < replyButtons.Length; i++)
        //{
        //    replyButtons[i].gameObject.SetActive(true);
        //}
        answerText.gameObject.SetActive(false);
        acceptButton.gameObject.SetActive(false);
        currentQuestionIndex++;
        if (currentQuestionIndex < selectedCategory.questions.Length)
            QuestionsAnswers[currentQuestionIndex] = 2;
        if (currentQuestionIndex < selectedCategory.questions.Length)
            DisplayQuestion();
        else
        {
            for (int i = 0; i < replyButtons.Length; i++)
            {
                replyButtons[i].gameObject.SetActive(false);
            }
            answerText.gameObject.SetActive(true);
            GoNextButton.gameObject.SetActive(true);
            questionImage.gameObject.SetActive(false);
            questionText.gameObject.SetActive(false);
            if (scoreTrue > selectedCategory.questions.Length / 2)
            {
                answerText.text = "Молодец, а теперь пройди практику!";
                EndImage.sprite = WinSprite;
            }
            else
            {
                answerText.text = "Не расстраивайся! В следующий раз у тебя точно получится! А теперь пройди практику";
                EndImage.sprite = LoseSprite;
            }
            EndImage.gameObject.SetActive(true);
        }
        alreadySelected = false;
        DrawQuestionsCubes();
    }

    private void DrawQuestionsCubes()
    {
        foreach (var obj in PreviosQuestionCubes.ToArray())
        {
            Destroy(obj);
            PreviosQuestionCubes.Remove(obj);
        }

        for (var i = 0;i < QuestionsAnswers.Length;i++)
        {
            GameObject spriteObj = new GameObject("2DSprite");
            spriteObj.transform.SetParent(canvas.transform, false);
            Image image = spriteObj.AddComponent<Image>();
            Texture2D texture;
            if (QuestionsAnswers[i] == 1)
                texture = textureTrue;
            else if (QuestionsAnswers[i] == -1)
                texture = textureFalse;
            else if (QuestionsAnswers[i] == 0)
                texture = textureNew;
            else
                texture = textureCurrrent;
            Sprite sprite = Sprite.Create(
                    texture,
                    new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f)
                );

            image.sprite = sprite;
            RectTransform rectTransform = spriteObj.gameObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0, 1);
            rectTransform.anchorMax = new Vector2(0, 1);
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.anchoredPosition3D = new Vector3(100 + 70 * i, -60, 0);
            rectTransform.sizeDelta = new Vector2(40, 40);
            PreviosQuestionCubes.Add(spriteObj);
        }
    }
}
