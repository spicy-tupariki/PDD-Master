using UnityEngine;

public class CarCollision : MonoBehaviour
{
    private float cooldownTime = 0f;
    private int damageCount = 0;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

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
    }

    void FixedUpdate()
    {
        cooldownTime += Time.deltaTime;
    }
}
