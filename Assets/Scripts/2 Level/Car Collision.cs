using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics;

public class CarCollision : MonoBehaviour
{
    private float cooldownTime = 0f;
    public static int damageCount = 0;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public Button restartButton;
    public Button menuButton;
    public GameObject car;
    public TMP_Text EndText;
    public Image EndBack;

    private void OnCollisionEnter(Collision collision)
    {
        if (cooldownTime > 2f && collision.gameObject.CompareTag("car"))
        {
            cooldownTime = 0f;
            damageCount++;
            if (damageCount == 1)
                star1.gameObject.SetActive(false);
            else if (damageCount == 2)
                star2.gameObject.SetActive(false);
            else
                star3.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("carL") || collision.gameObject.CompareTag("carR"))
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

    private void Start()
    {
        star1.gameObject.SetActive(true);
        star2.gameObject.SetActive(true);
        star3.gameObject.SetActive(true);
        damageCount = 0;
    }
    void FixedUpdate()
    {
        cooldownTime += Time.deltaTime;
    }

    public void GetDamage()
    {
        if (cooldownTime > 2f)
        {
            cooldownTime = 0f;
            damageCount++;
            if (damageCount == 1)
                star1.gameObject.SetActive(false);
            else if (damageCount == 2)
                star2.gameObject.SetActive(false);
            else
                star3.gameObject.SetActive(false);
        }
    }
}
