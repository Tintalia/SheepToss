using UnityEngine;
using System.Collections;

public class MenuHeroes : Menu
{
    //public override void OnGUI()
    //{
    //    GUI.Box(new Rect(0, 0, topBannerW, topBannerH), "HEROES");

    //    if (GUI.Button(new Rect(0, buttonPos1, buttonSizeW, buttonSizeH), "TOOTHLESS"))
    //    {
    //        Application.LoadLevel(2);﻿
    //    }

    //    if (GUI.Button(new Rect(0, buttonPos2, buttonSizeW, buttonSizeH), "HOOKFANG"))
    //    {
    //    }

    //    if (GUI.Button(new Rect(0, buttonPos3, buttonSizeW, buttonSizeH), "Back"))
    //    {
    //        Application.LoadLevel(0);﻿
    //    }
    //}

    private bool hideWindowToothless = false;
    private bool hideWindowHookfang = false;
    private float widthWindowRect = Screen.width - 20;
    private float heightWindowRect = Screen.height -20;
    private float widthTexture = Screen.width / 2;
    private float heightTexture = Screen.height;
    private float xStartButton = Screen.width / 2;
    private float yStartButton = Screen.height / 2 + 100;
    private float widthStartButton = 200;
    private float heightStartButton = 50;
    public Rect windowRectToothless;
    public Rect windowRectHookfang;
    public Texture2D toothlessInfo;
    public Texture2D hookfangInfo;
            

    public override void OnGUI()
    {
       // GUI.Box(new Rect(0, 0, topBannerW, topBannerH), "Characters");

        if (GUI.Button(new Rect(0, buttonPos1, buttonSizeW, buttonSizeH), "TOOTHLESS"))
        {
            if (hideWindowToothless)
            {
                hideWindowToothless = false;
            }
            else
            {
                hideWindowToothless = true;
            }
        }

        if (GUI.Button(new Rect(0, buttonPos2, buttonSizeW, buttonSizeH), "HOOKFANG"))
        {
            if (hideWindowHookfang)
            {
                hideWindowHookfang = false;
            }
            else 
            {
                hideWindowHookfang = true;
            }
        }

        if (GUI.Button(new Rect(0, buttonPos3, buttonSizeW, buttonSizeH), "Back"))
        {
            Application.LoadLevel(0);﻿
        }

        GUI.backgroundColor = Color.clear;
        if (hideWindowToothless)
        {
            windowRectToothless = new Rect(0, 0, widthWindowRect, heightWindowRect);
            windowRectToothless = GUI.Window(0, windowRectToothless, DoMyWindow, "Toothless");
        }

        if (hideWindowHookfang)
        {
            windowRectHookfang = new Rect(0, 0, widthWindowRect, heightWindowRect);
            windowRectHookfang = GUI.Window(1, windowRectHookfang, DoMyWindow, "Hookfang");
        }
    }

    private void DoMyWindow(int id)
    {
        GUI.backgroundColor = Color.clear;
        if (id == 0)
        {
            GUI.Button(new Rect(0, 0, widthTexture, heightTexture), toothlessInfo);
            Loadleve(3);
        }
        else
        {
            GUI.Button(new Rect(0, 0, widthTexture, heightTexture), hookfangInfo);
            Loadleve(3);
        }
    }

    private void Loadleve(int numberScene)
    {
        GUI.backgroundColor = Color.black;
        if (GUI.Button(new Rect(xStartButton, yStartButton, widthStartButton, heightStartButton), "Start"))
        {
            Application.LoadLevel(numberScene);
        }
    }
}
