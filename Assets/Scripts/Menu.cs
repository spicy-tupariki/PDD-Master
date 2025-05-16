using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{
    public GameObject Scroll;
    public GameObject Description;
    public Button PlayButton;
    public TMP_Text LevelNameText;
    public TMP_Text LevelDescriptionText;
    public Image LevelImage;
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
    }
    public void ShowScroll()
    {
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
            case 3:
                LevelNameText.text = "Общие положения";
                LevelDescriptionText.text = "Первый базовый урок";
                break;
            case 5:
                LevelNameText.text = "Второй уровень название";
                LevelDescriptionText.text = "Второй урок";
                break;

        }
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene(0);
    }
}
