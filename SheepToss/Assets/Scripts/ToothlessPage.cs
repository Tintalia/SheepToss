using UnityEngine;
using System.Collections;

public class ToothlessPage : MainMenuController {
    public override void OnGUI()
    {
        if (GUI.Button(new Rect(0, 1, buttonSizeW, buttonSizeH), "Back"))
        {
            Debug.Log("Back");
            Application.LoadLevel(1);﻿
        }

        if (GUI.Button(new Rect(0, buttonPos1, buttonSizeW, buttonSizeH), "Start"))
        {
            Debug.Log("Start");
            Application.LoadLevel(3);
        }
    }
}
