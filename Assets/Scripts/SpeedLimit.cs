using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics;

public class SpeedLimit : MonoBehaviour
{
    public Button restartButton;
    public Button menuButton;
    public GameObject car;
    public VehicleBase carRB;
    public TMP_Text EndText;
    public Image EndBack;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player") && (int)(carRB.speed * 3.6f) > 40)
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
    }
}
