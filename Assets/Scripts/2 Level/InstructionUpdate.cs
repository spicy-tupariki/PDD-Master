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

            // Отслеживание времени удержания
            if (_isKeyPressed && Input.GetKey(KeyCode.K))
            {
                _pressTime += Time.deltaTime;

                // Проверка достижения 5 секунд
                if (_pressTime >= RequiredHoldTime)
                {
                    _isKeyPressed = false; // Сброс
                                           // Здесь вызывайте нужное действие
                    instructionText.text = "Молодец, теперь нажми на клавишу (1), чтобы включить первую скорость";
                    step++;
                }
            }
        }
        if (step == 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                instructionText.text = "Молодец, теперь начинай движение вперед клавишей (W), а также поворачивай влево на (A) и вправо на (D) при необходимочти. (Пробел) - тормоз";
                step++;
            }
        }
    }
}
