using System;
using UnityEngine;

public class Crossroad : MonoBehaviour
{
    public Material green;
    public Material red;
    public Material yellow;
    public Material black;
    private float switchTime = 6f;
    private float currentTime = 0f;
    private static int currentWay = 1;

    public Renderer lightTopPlayer;
    public Renderer lightMiddlePlayer;
    public Renderer lightBottomPlayer;

    public Renderer lightTopEnemy1;
    public Renderer lightMiddleEnemy1;
    public Renderer lightBottomEnemy1;

    public Renderer lightTopEnemy2;
    public Renderer lightMiddleEnemy2;
    public Renderer lightBottomEnemy2;

    private void Start()
    {
        switchTime = 6f;
        currentTime = 0f;
        currentWay = 1;
}
    public void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime > switchTime + 1f)
        {
            MakeSwitchLight();
            currentTime = 0f;
        }
        else if (currentTime > switchTime)
        {
            MakeSwitchYellow();
            AiCarController.SwitchMove();
        }
    }  

    private void MakeSwitchYellow()
    {
        lightBottomEnemy1.material = black;
        lightBottomEnemy2.material = black;
        lightBottomPlayer.material = black;

        lightTopEnemy1.material = black;
        lightTopEnemy2.material = black;
        lightTopPlayer.material = black;


        lightMiddleEnemy1.material = yellow;
        lightMiddleEnemy2.material = yellow;
        lightMiddlePlayer.material = yellow;
    }

    private void MakeSwitchLight()
    {
        if (currentWay == 0)
        {
            lightBottomEnemy1.material = black;
            lightBottomEnemy2.material = black;
            lightBottomPlayer.material = green;

            lightTopEnemy1.material = red;
            lightTopEnemy2.material = red;
            lightTopPlayer.material = black;


            lightMiddleEnemy1.material = black;
            lightMiddleEnemy2.material = black;
            lightMiddlePlayer.material = black;
            currentWay = 1;
        }
        else if (currentWay == 1)
        {
            lightBottomEnemy1.material = green;
            lightBottomEnemy2.material = green;
            lightBottomPlayer.material = black;

            lightTopEnemy1.material = black;
            lightTopEnemy2.material = black;
            lightTopPlayer.material = red;


            lightMiddleEnemy1.material = black;
            lightMiddleEnemy2.material = black;
            lightMiddlePlayer.material = black;
            currentWay = 0;
        }
    }
}
