using UnityEngine;

public class RightWallAI : MonoBehaviour
{
    public AiCarController AiCarController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("carL"))
        {
            AiCarController.ReturnLeft(other.gameObject);
            Debug.Log("hui");
        }
    }
}
