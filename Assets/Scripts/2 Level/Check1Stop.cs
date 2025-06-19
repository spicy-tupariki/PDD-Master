using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics;

public class Check1Stop : MonoBehaviour
{
    public Button restartButton;
    public Button menuButton;
    public GameObject car;
    public TMP_Text EndText;
    public VehicleBase carRB;
    public Image EndBack;

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player") && (int)(carRB.speed * 3.6f) > 10)
        {
            restartButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            EndBack.gameObject.SetActive(true);
            Input.ResetInputAxes();
            car.GetComponent<VPStandardInput>().enabled = false;
            EndText.color = Color.red;
            EndText.text = "Ты допустил серьезную ошибку! \n Попробуй пройти заново.";
            EndText.gameObject.SetActive(true);
        }
        AiCarController.CanMoveBlock1 = true;
    }

    private void Start()
    {
        AiCarController.CanMoveBlock1 = false;
    }
}
