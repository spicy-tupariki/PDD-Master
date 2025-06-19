using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics;

public class RrealWin : MonoBehaviour
{
    public Button restartButton;
    public Button menuButton;
    public GameObject car;
    public TMP_Text EndText;
    public VehicleBase carRB;
    public Image EndBack;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player") && (int)(carRB.speed * 3.6f) == 0 && car.transform.eulerAngles.y > 240 && car.transform.eulerAngles.y < 300)
        {
            restartButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            EndBack.gameObject.SetActive(true);
            Input.ResetInputAxes();
            car.GetComponent<VPStandardInput>().enabled = false;
            EndText.color = Color.green;
            EndText.text = $"Молодец, практика пройдена! \n Ты получил {3 - CarCollision.damageCount} звезды из 3";
            EndText.gameObject.SetActive(true);
        }
    }
}
