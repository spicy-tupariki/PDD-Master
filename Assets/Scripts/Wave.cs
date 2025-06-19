using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    public Image WaveCenter;

    void FixedUpdate()
    {
        WaveCenter.transform.eulerAngles = new Vector3(
            WaveCenter.transform.eulerAngles.x,
            WaveCenter.transform.eulerAngles.y,
            WaveCenter.transform.eulerAngles.z);
    }
}
