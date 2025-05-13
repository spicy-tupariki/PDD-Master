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
            resultText.text = "Молодец, всё верно!";
        }
        else
        {
            resultText.text = "Не совсем, попробуй снова";
        }
        resultText.gameObject.SetActive(true);
        againButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
    }
}
