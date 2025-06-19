using TMPro;
using UnityEngine;

public class InstructionUpdate : MonoBehaviour
{
    private float _pressTime = 0f;
    private bool _isKeyPressed = false;
    private const float RequiredHoldTime = 2f;
    public TMP_Text instructionText;
    private int step = 0;

    void Update()
    {
        if (step == 0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                _isKeyPressed = true;
                _pressTime = 0f;
            }

            // ������������ ������� ���������
            if (_isKeyPressed && Input.GetKey(KeyCode.K))
            {
                _pressTime += Time.deltaTime;

                // �������� ���������� 5 ������
                if (_pressTime >= RequiredHoldTime)
                {
                    _isKeyPressed = false; // �����
                                           // ����� ��������� ������ ��������
                    instructionText.text = "�������, ������ ����� �� ������� (1), ����� �������� ������ ��������";
                    step++;
                }
            }
        }
        if (step == 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                instructionText.text = "�������, ������ ������� �������� ������ �������� (W), � ����� ����������� ����� �� (A) � ������ �� (D) ��� �������������. (������) - ������";
                step++;
            }
        }
    }
}
