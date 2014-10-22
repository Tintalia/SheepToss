using UnityEngine;
using System.Collections;

public class MainMenuController : Menu
{
    public override void OnGUI()
    {
        GUI.Box(new Rect(0, 0, topBannerW, topBannerH), "Sheep Toss");

        if (GUI.Button(new Rect(0, buttonPos1, buttonSizeW, buttonSizeH), "Start"))
        {
            Application.LoadLevel(3);﻿
        }
		
        if (GUI.Button(new Rect(0, buttonPos2, buttonSizeW, buttonSizeH), "Heroes"))
        {
            Application.LoadLevel(1);﻿
        }
		
        if (GUI.Button(new Rect(0, buttonPos3, buttonSizeW, buttonSizeH), "Quit"))
        {
            Application.Quit();
        }
    }
}

