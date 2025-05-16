using UnityEngine;
using System.Collections;

public class ScreenShot : MonoBehaviour
{
    public string Name;
	void Start () {
	ScreenCapture.CaptureScreenshot(@"D:\Screens"+Name+".png");
	}
}
