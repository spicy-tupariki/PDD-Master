using System;
using TMPro;
using UnityEngine;
using VehiclePhysics;

public class Speed : MonoBehaviour
{
    public TMP_Text speedText;
    public VehicleBase carRB;
    public GameObject WaveCenter;

    void FixedUpdate()
    {
        speedText.text = Math.Abs((int)(carRB.speed * 3.6f)).ToString();
        var engineRPM = (int)carRB.data.Get(Channel.Vehicle, VehicleData.EngineRpm) / 1000;
        // псякюм, щрн пол, лш ядекюкх. ю реоепэ ъ онь╗к гю фхдйхл лшкнл : )
        WaveCenter.transform.eulerAngles = new Vector3(
            WaveCenter.transform.eulerAngles.x,
            WaveCenter.transform.eulerAngles.y,
            30f - 220 * engineRPM / 10000f);
    }
}
