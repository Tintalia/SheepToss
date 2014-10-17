using UnityEngine;
using System.Collections;

public class MenuHeroes : MainMenuController {
    //public Texture texture;
    public override void OnGUI()
    {
        // GUI.skin = customerSkin1;
        //if (!texture)
        //{
        //    Debug.LogError("Please assign a texture on the inspector");
        //    return;
        //}
        GUI.Box(new Rect(0, 0, topBannerW, topBannerH), "HEROES");

        if (GUI.Button(new Rect(0, buttonPos1, buttonSizeW, buttonSizeH), "TOOTHLESS"))
        {
            Debug.Log("toothless");
            Application.LoadLevel(2);﻿
        }

        if (GUI.Button(new Rect(0, buttonPos2, buttonSizeW, buttonSizeH), "HOOKFANG"))
        {
            Debug.Log("hookfang");
            // Application.LoadLevel(4);﻿
        }

        if (GUI.Button(new Rect(0, buttonPos3, buttonSizeW, buttonSizeH), "Back"))
        {
            Debug.Log("Back");
            Application.LoadLevel(0);﻿
        }
    }
}
