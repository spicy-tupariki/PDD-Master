using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections.Generic;

public class TeorySceneManager : MonoBehaviour
{
    public string LevelPracticeName;

    public void ShowLevel()
    {
        SceneManager.LoadScene(LevelPracticeName);
    }
}
