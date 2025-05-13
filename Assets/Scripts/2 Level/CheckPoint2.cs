using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint2 : MonoBehaviour
{
    public TMP_Text instructionText;
    public Button button;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            button.gameObject.SetActive(true);
            instructionText.text = "� ���������, ����������� ������ ����������� �����! ��������� ������� ������ (F3) � �������� ����� R ��� �������������." +
                " ����� �������������, ����� ���������.";
        }
    }
}
