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
            instructionText.text = "Теперь, найди место, где можно припарковаться и сделай это. " +
                "Используй движение назад (R) при необходимости.";
        }
    }
}
