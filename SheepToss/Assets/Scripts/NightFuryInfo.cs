using UnityEngine;
using System.Collections;

public class NightFuryInfo : Menu
{
    public override void OnGUI()
    {
        if (GUI.Button(new Rect(0, 1, buttonSizeW, buttonSizeH), "Back"))
        {
            Application.LoadLevel(1);﻿
        }

        if (GUI.Button(new Rect(0, buttonPos1, buttonSizeW, buttonSizeH), "Start"))
        {
            Application.LoadLevel(3);
        }
    }
}
