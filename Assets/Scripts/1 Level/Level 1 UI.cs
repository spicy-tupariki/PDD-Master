using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level1UI : MonoBehaviour
{
    public static TMP_Text resultText;
    public static Button againButton;
    public static Button menuButton;

    public static void ShowResult(bool complete)
    {
        if (complete)
        {
            resultText.text = "�������, �� �����!";
        }
        else
        {
            resultText.text = "�� ������, �������� �����";
        }
        resultText.gameObject.SetActive(true);
        againButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
    }
}
