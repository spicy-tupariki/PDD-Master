using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics;

public class Win : MonoBehaviour
{
    public Button restartButton;
    public Button menuButton;
    public GameObject car;
    public TMP_Text EndText;
    public VehicleBase carRB;
    public TMP_Text InstructionText;
    public GameObject LoseWallBroke;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player") && (int)(carRB.speed * 3.6f) < 4)
        {
            InstructionText.text = "Теперь развернись и едь прямо до конца. Припаркуйся на свободном месте на парковке";
            LoseWallBroke.gameObject.SetActive(false);
        }
    }
}
