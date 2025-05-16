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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && (int)(carRB.speed * 3.6f) < 4)
        {
            restartButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            Input.ResetInputAxes();
            car.GetComponent<VPStandardInput>().enabled = false;
            EndText.color = Color.green;
            EndText.text = $"Молодец, практика пройдена на {3 - CarCollision.damageCount} из 3";
            EndText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player") && (int)(carRB.speed * 3.6f) < 4)
        {
            restartButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            Input.ResetInputAxes();
            car.GetComponent<VPStandardInput>().enabled = false;
            EndText.color = Color.green;
            EndText.text = $"Молодец, практика пройдена на {3 - CarCollision.damageCount} из 3";
            EndText.gameObject.SetActive(true);
        }
    }
}
