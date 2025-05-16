using TMPro;
using UnityEngine;
using VehiclePhysics;

public class Speed : MonoBehaviour
{
    public TMP_Text speedText;
    public VehicleBase carRB;

    void FixedUpdate()
    {
        speedText.text = ((int)(carRB.speed * 3.6f)).ToString();
        var engineRPM = (int)carRB.data.Get(Channel.Vehicle, VehicleData.EngineRpm) / 1000;
        // псякюм, щрн пол, лш ядекюкх. ю реоепэ ъ онь╗к гю фхдйхл лшкнл : )
    }
}
