using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Scroll;
    public GameObject Description;
    public Button PlayButton;
    public Text LevelNameText;
    public Text LevelDescriptionText;
    public Image LevelImage;
    public GameObject AboutScreen;
    private int CurrentLevel;

    public void ShowLevel()
    {
        SceneManager.LoadScene(CurrentLevel);
    }

    public void ShowLevelFromIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {
        Scroll.SetActive(false);
        Application.Quit();
    }

    public void ShowAbout()
    {
        Scroll.SetActive(false);
        AboutScreen.SetActive(true);
        Description.SetActive(false);
    }
    public void ShowScroll()
    {
        AboutScreen.SetActive(false);
        Scroll.SetActive(true);
    }

    public void TakeLevel(int levelIndex)
    {
        CurrentLevel = levelIndex;
        Description.SetActive(true);
        LoadLevelData();
    }

    private void LoadLevelData()
    {
        switch (CurrentLevel)
        {
            case 2:
                LevelNameText.text = "Общие положения";
                LevelDescriptionText.text = "Разбираем дорогу и её элементы";
                LevelImage.sprite = Resources.Load<Sprite>("logo1");
                break;
            case 4:
                LevelNameText.text = "Дорожные знаки";
                LevelDescriptionText.text = "Разбираем знаки ПДД";
                LevelImage.sprite = Resources.Load<Sprite>("logo2");
                break;

        }
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene(0);
    }
}
