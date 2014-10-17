using UnityEngine;
using System.Collections;

public class MenuHeroes : Menu
{
    public override void OnGUI()
    {
        GUI.Box(new Rect(0, 0, topBannerW, topBannerH), "HEROES");

        if (GUI.Button(new Rect(0, buttonPos1, buttonSizeW, buttonSizeH), "TOOTHLESS"))
        {
            Application.LoadLevel(2);﻿
        }

        if (GUI.Button(new Rect(0, buttonPos2, buttonSizeW, buttonSizeH), "HOOKFANG"))
        {
        }

        if (GUI.Button(new Rect(0, buttonPos3, buttonSizeW, buttonSizeH), "Back"))
        {
            Application.LoadLevel(0);﻿
        }
    }
}
