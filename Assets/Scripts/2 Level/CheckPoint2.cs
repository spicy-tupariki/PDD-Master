using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint2 : MonoBehaviour
{
    public TMP_Text instructionText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            instructionText.text = "� ���������, ����� �����, ��� ����� �������������� � ������ ���. " +
                "��������� ������� ������ (F3) � �������� ����� R ��� �������������.";
        }
    }
}
