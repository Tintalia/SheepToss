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
            GUI.backgroundColor = Color.clear;
            windowRectToothless = new Rect(0, 0, Screen.width - 20, Screen.height - 20);
            //GUI.Box(new Rect(0, 0, Screen.width - 20, Screen.height - 20), "Menu");
            windowRectToothless = GUI.Window(0, windowRectToothless, DoMyWindow, "Toothless");
        }

        if (hideWindowHookfang)
        {
            GUI.backgroundColor = Color.clear;
            windowRectHookfang = new Rect(0, 0, Screen.width - 20, Screen.height - 20);
            // GUI.Box(new Rect(0, 0, Screen.width - 20, Screen.height - 20), "Menu");
            windowRectHookfang = GUI.Window(1, windowRectHookfang, DoMyWindow, "Hookfang");
        }
    }

    private void DoMyWindow(int id)
    {
        GUI.backgroundColor = Color.clear;
        if (id == 0)
        {
            GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height), toothlessInfo);
            GUI.backgroundColor = Color.black;
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 100, 200, 50), "Start"))
            {
                Application.LoadLevel(3);
            }

        }
        else
        {
            GUI.backgroundColor = Color.clear;
            GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height), hookfangInfo);
            GUI.backgroundColor = Color.black;
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 100, 200, 50), "Start"))
            {
                Application.LoadLevel(3);
            }
        }
        
    }
}
