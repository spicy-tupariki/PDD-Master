using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics;

public class Lose : MonoBehaviour
{
    public Button restartButton;
    public Button menuButton;
    public GameObject car;
    public TMP_Text EndText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            restartButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            Input.ResetInputAxes();
            car.GetComponent<VPStandardInput>().enabled = false;
            EndText.color = Color.red;
            EndText.text = "Ты допустил серьезную ошибку, попробуй пройти заново";
            EndText.gameObject.SetActive(true);
        }
    }
}
