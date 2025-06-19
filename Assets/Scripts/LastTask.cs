using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics;

public class LastTask : MonoBehaviour
{
    public TMP_Text InstructionText;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player"))
        {
            InstructionText.text = "Припаркуйся ЗАДОМ на свободном месте на парковке. Используй (R) для движения назад" +
                "и смотри в зеркала.";
        }
    }
}
