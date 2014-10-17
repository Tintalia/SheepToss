using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
    // Top banner
    public float topBannerH;
    public float topBannerW;
    // Button
    public float buttonSizeH;
    public float buttonSizeW;
    public float buttonPos1;
    public float buttonPos2;
    public float buttonPos3;
    public float buttonPos4;
    public float buttonPos5;
    // bottom Bnner
    public float buttonBannerH;
    public float buttomBannerW;
    public float buttombannerPos;
    //public GUISkin customerSkin1;

    public void Awake()
    {
        topBannerH = Screen.height / 4;
        topBannerW = Screen.width;
        buttonSizeH = Screen.height / 10;
        buttonSizeW = Screen.width;
        buttonPos1 = topBannerH;
        buttonPos2 = topBannerH + buttonSizeH;
        buttonPos3 = topBannerH + buttonSizeH * 2;
        buttonPos4 = topBannerH + buttonSizeH * 3;
        buttonPos5 = topBannerH + buttonSizeH * 4;
        buttonBannerH = Screen.height / 4;
        buttomBannerW = Screen.width;
        buttombannerPos = topBannerH + buttonSizeH * 5;
    }
        public virtual void OnGUI() 
        {
            // GUI.skin = customerSkin1;
            GUI.Box(new Rect(0, 0, topBannerW, topBannerH), "Sheep Toss");

            if (GUI.Button(new Rect(0, buttonPos1, buttonSizeW, buttonSizeH), "Start"))
            {
                Debug.Log("Start");
                Application.LoadLevel(3);﻿
            }
             if (GUI.Button(new Rect(0, buttonPos2, buttonSizeW, buttonSizeH), "Options"))
            {
                Debug.Log("Option");
            }
             if (GUI.Button(new Rect(0, buttonPos3, buttonSizeW, buttonSizeH), "Level"))
            {
                Debug.Log("level");
            }
             if (GUI.Button(new Rect(0, buttonPos4, buttonSizeW, buttonSizeH), "Heroes"))
            {
                Debug.Log("Heroes");
                Application.LoadLevel(1);﻿
            }
             if (GUI.Button(new Rect(0, buttonPos5, buttonSizeW, buttonSizeH), "Quit"))
            {
                Debug.Log("Quit");
                Application.Quit();
            }

        }
}

