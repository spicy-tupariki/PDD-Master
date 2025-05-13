using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button start;
    public Button about;
    public Button exit;

    void Start()
    {
        ColorBlock colors = start.colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = Color.blue;
        colors.pressedColor = Color.grey;
        start.colors = colors;

        colors = about.colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = Color.blue;
        colors.pressedColor = Color.grey;
        about.colors = colors;

        colors = exit.colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = Color.blue;
        colors.pressedColor = Color.grey;
        exit.colors = colors;
    }
}
