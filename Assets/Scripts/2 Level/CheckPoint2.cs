using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint2 : MonoBehaviour
{
    public TMP_Text instructionText;
    public Button button;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            button.gameObject.SetActive(true);
            instructionText.text = "И последнее, припаркуйся справа МАКСИМАЛЬНО ровно! Используй боковое зрение (F3) и движение назад R при необходимости." +
                " Когда припаркуешься, нажми закончить.";
        }
    }
}
