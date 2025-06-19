using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarSceneOne : MonoBehaviour
{
    private static bool grey = false;
    private static bool purple = false;
    private static bool yellow = false;

    public WheelCollider GreyFL;
    public WheelCollider GreyFR;
    public WheelCollider GreyRL;
    public WheelCollider GreyRR;

    public Transform GreyFLTr;
    public Transform GreyFRTr;
    public Transform GreyRLTr;
    public Transform GreyRRTr;

    public WheelCollider PurpleFL;
    public WheelCollider PurpleFR;
    public WheelCollider PurpleRL;
    public WheelCollider PurpleRR;

    public Transform PurpleFLTr;
    public Transform PurpleFRTr;
    public Transform PurpleRLTr;
    public Transform PurpleRRTr;

    public WheelCollider YellowFL;
    public WheelCollider YellowFR;
    public WheelCollider YellowRL;
    public WheelCollider YellowRR;

    public Transform YellowFLTr;
    public Transform YellowFRTr;
    public Transform YellowRLTr;
    public Transform YellowRRTr;

    public int forse;
    public int angleGrey;
    public int anglePurple;
    private float timeGrey = 0;
    private float timePurple = 0;
    public float timeGreyMax;
    public float timePurpleMax;

    public TMP_Text resultText;
    public GameObject EndScreen;

    private static bool complete = true;

    public void Start()
    {
        grey = false;
        purple = false;
        yellow = false;
        timeGrey = 0;
        timePurple = 0;
        complete = true;
    }
    public void ClickGrey()
    {
        if (!yellow)
        {
            complete = false;
            ClickYellow();
            this.Complete(complete);
        }
        grey = true;
    }

    public void ClickPurple()
    {
        if (!yellow && !grey)
        {
            ClickYellow();
            ClickGrey();
            complete = false;
        }
        if (!grey)
        {
            ClickGrey();
            complete = false;
        }
        purple = true;
        this.Complete(complete);
    }

    public static void ClickYellow()
    {
        yellow = true;
    }

    public void FixedUpdate()
    {
        if (grey)
        {
            timeGrey += Time.deltaTime;
            if (timeGrey > timeGreyMax)
                angleGrey = 0;
            MoveCar(GreyFL, GreyFR, GreyRL, GreyRR, GreyFLTr, GreyFRTr, GreyRLTr, GreyRRTr, -angleGrey);
        }
        if (purple)
        {
            timePurple += Time.deltaTime;
            if (timePurple > timePurpleMax)
                anglePurple = 0;
            MoveCar(PurpleFL, PurpleFR, PurpleRL, PurpleRR, PurpleFLTr, PurpleFRTr, PurpleRLTr, PurpleRRTr, anglePurple);
        }
        if (yellow)
            MoveCar(YellowFL, YellowFR, YellowRL, YellowRR, YellowFLTr, YellowFRTr, YellowRLTr, YellowRRTr, 0);
    }


    private void MoveCar(WheelCollider FL, WheelCollider FR, WheelCollider RL, WheelCollider RR,
        Transform FLTr, Transform FRTr, Transform RLTr, Transform RRTr, int angle)
    {
        FL.motorTorque = forse;
        FR.motorTorque = forse;
        FL.steerAngle = angle;
        FR.steerAngle = angle;
        RotateWheel(FL, FLTr);
        RotateWheel(FR, FRTr);
        RotateWheel(RL, RLTr);
        RotateWheel(RR, RRTr);
    }

    private void RotateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        transform.rotation = rotation;
        transform.position = position;
    }

    public void Complete(bool complete)
    {
        if (complete)
        {
            resultText.text = "Всё решено верно!";
        }
        else
        {
            resultText.text = "Не совсем, попробуй снова";
        }
        EndScreen.gameObject.SetActive(true);
    }
}
