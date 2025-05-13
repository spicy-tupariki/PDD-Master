using UnityEngine;

public class LeftWallAI : MonoBehaviour
{
    public AiCarController AiCarController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("carR"))
        {
            AiCarController.ReturnRight(other.gameObject);
            Debug.Log("dsaasd");
        }
    }
}
