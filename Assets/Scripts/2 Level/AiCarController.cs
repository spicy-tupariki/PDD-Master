using Unity.VisualScripting;
using UnityEngine;

public class AiCarController : MonoBehaviour
{
    public WheelCollider RGreyFL;
    public WheelCollider RGreyFR;
    public WheelCollider RGreyRL;
    public WheelCollider RGreyRR;

    public Transform RGreyFLTr;
    public Transform RGreyFRTr;
    public Transform RGreyRLTr;
    public Transform RGreyRRTr;

    public WheelCollider RPurpleFL;
    public WheelCollider RPurpleFR;
    public WheelCollider RPurpleRL;
    public WheelCollider RPurpleRR;

    public Transform RPurpleFLTr;
    public Transform RPurpleFRTr;
    public Transform RPurpleRLTr;
    public Transform RPurpleRRTr;

    public WheelCollider RYellowFL;
    public WheelCollider RYellowFR;
    public WheelCollider RYellowRL;
    public WheelCollider RYellowRR;

    public Transform RYellowFLTr;
    public Transform RYellowFRTr;
    public Transform RYellowRLTr;
    public Transform RYellowRRTr;

    public WheelCollider LGreyFL;
    public WheelCollider LGreyFR;
    public WheelCollider LGreyRL;
    public WheelCollider LGreyRR;

    public Transform LGreyFLTr;
    public Transform LGreyFRTr;
    public Transform LGreyRLTr;
    public Transform LGreyRRTr;

    public WheelCollider LPurpleFL;
    public WheelCollider LPurpleFR;
    public WheelCollider LPurpleRL;
    public WheelCollider LPurpleRR;

    public Transform LPurpleFLTr;
    public Transform LPurpleFRTr;
    public Transform LPurpleRLTr;
    public Transform LPurpleRRTr;

    public WheelCollider LYellowFL;
    public WheelCollider LYellowFR;
    public WheelCollider LYellowRL;
    public WheelCollider LYellowRR;

    public Transform LYellowFLTr;
    public Transform LYellowFRTr;
    public Transform LYellowRLTr;
    public Transform LYellowRRTr;

    public GameObject RGrey;
    public GameObject RPurple;
    public GameObject RYellow;

    public GameObject LGrey;
    public GameObject LPurple;
    public GameObject LYellow;

    public int forse;
    private static bool CanMove = false;

    public Transform LStart;
    public Transform RStart;

    public static bool CanMoveBlock1 = false;
    public Transform Move1FLTr;
    public Transform Move1FRTr;
    public Transform Move1RLTr;
    public Transform Move1RRTr;

    public WheelCollider Move1FL;
    public WheelCollider Move1FR;
    public WheelCollider Move1RL;
    public WheelCollider Move1RR;

    private void Start()
    {
        CanMove = false;
    }
    public void FixedUpdate()
    {
        if (!CanMove)
        {
            RGreyFL.brakeTorque = 3000f;
            RPurpleFL.brakeTorque = 3000f;
            RYellowFL.brakeTorque = 3000f;

            LGreyFL.brakeTorque = 3000f;
            LPurpleFL.brakeTorque = 3000f;
            LYellowFL.brakeTorque = 3000f;

            RGreyFR.brakeTorque = 3000f;
            RPurpleFR.brakeTorque = 3000f;
            RYellowFR.brakeTorque = 3000f;

            LGreyFR.brakeTorque = 3000f;
            LPurpleFR.brakeTorque = 3000f;
            LYellowFR.brakeTorque = 3000f;
        }
        else
        {
            RGreyFL.brakeTorque = 0;
            RPurpleFL.brakeTorque = 0;
            RYellowFL.brakeTorque = 0;

            LGreyFL.brakeTorque = 0;
            LPurpleFL.brakeTorque = 0;
            LYellowFL.brakeTorque = 0;

            RGreyFR.brakeTorque = 0;
            RPurpleFR.brakeTorque = 0;
            RYellowFR.brakeTorque = 0;

            LGreyFR.brakeTorque = 0;
            LPurpleFR.brakeTorque = 0;
            LYellowFR.brakeTorque = 0;
        }
        MoveCar(RGreyFL, RGreyFR, RGreyRL, RGreyRR, RGreyFLTr, RGreyFRTr, RGreyRLTr, RGreyRRTr);
        MoveCar(RPurpleFL, RPurpleFR, RPurpleRL, RPurpleRR, RPurpleFLTr, RPurpleFRTr, RPurpleRLTr, RPurpleRRTr);
        MoveCar(RYellowFL, RYellowFR, RYellowRL, RYellowRR, RYellowFLTr, RYellowFRTr, RYellowRLTr, RYellowRRTr);

        MoveCar(LGreyFL, LGreyFR, LGreyRL, LGreyRR, LGreyFLTr, LGreyFRTr, LGreyRLTr, LGreyRRTr);
        MoveCar(LPurpleFL, LPurpleFR, LPurpleRL, LPurpleRR, LPurpleFLTr, LPurpleFRTr, LPurpleRLTr, LPurpleRRTr);
        MoveCar(LYellowFL, LYellowFR, LYellowRL, LYellowRR, LYellowFLTr, LYellowFRTr, LYellowRLTr, LYellowRRTr);

        if (CanMoveBlock1)
        {
            MoveCar(Move1FL, Move1FR, Move1RL, Move1RR, Move1FLTr, Move1FRTr, Move1RLTr, Move1RRTr, angle:15);
        }

    }
    
    private void MoveCar(WheelCollider FL, WheelCollider FR, WheelCollider RL, WheelCollider RR,
        Transform FLTr, Transform FRTr, Transform RLTr, Transform RRTr, int angle=0)
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

    public static void SwitchMove()
    {
        if (CanMove) CanMove = false;
        else CanMove = true;
    }

    private void RotateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        transform.rotation = rotation;
        transform.position = position;
    }

    public void ReturnRight(GameObject other)
    {
        other.transform.position = RStart.position;
    }

    public void ReturnLeft(GameObject other)
    {
        other.transform.position = LStart.position;
    }
}
