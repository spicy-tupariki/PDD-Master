using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint2 : MonoBehaviour
{
    public TMP_Text instructionText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            instructionText.text = "И последнее, найди место, где можно припарковаться и сделай это. " +
                "Используй боковое зрение (F3) и движение назад R при необходимости.";
        }
    }
}
