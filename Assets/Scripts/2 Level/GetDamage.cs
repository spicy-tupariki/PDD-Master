using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public GameObject car;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player"))
        {
            car.GetComponent<CarCollision>().GetDamage();
        }
    }
}
