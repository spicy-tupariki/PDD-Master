using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics;

public class LastTask : MonoBehaviour
{
    public TMP_Text InstructionText;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player"))
        {
            InstructionText.text = "����������� ����� �� ��������� ����� �� ��������. ��������� (R) ��� �������� �����" +
                "� ������ � �������.";
        }
    }
}
