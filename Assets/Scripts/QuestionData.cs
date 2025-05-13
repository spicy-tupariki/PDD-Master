using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] replies;
    public int correctPeplyIndex;
    public Sprite questionImage;
    public string answerText;
}

[CreateAssetMenu(fileName = "New Category", menuName = "Quiz/Question Data")]
public class QuestionData : ScriptableObject
{
    public string category;
    public Question[] questions;
}
