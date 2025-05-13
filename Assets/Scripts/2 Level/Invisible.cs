using TMPro;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    public TMP_Text instructionText;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            instructionText.text = "Супер, теперь сделай плавный поворот налево, будь аккуратнее!";
        }
    }
}
