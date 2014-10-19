using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vendor : MonoBehaviour {

    private bool hideWindow = false;
    public Texture texture;
    public Rect windowRect;
    public Dragon dragon;
    void OnGUI()
    {
        GUI.backgroundColor = Color.clear;
        if (GUI.Button(new Rect(20, Screen.height - 40, 40, 40), texture))
        {
            //When button is pressed it toggles the hideWindow boolean
            if (hideWindow)
            {
                hideWindow = false;
                Time.timeScale = 1;
            }
            else
            {
                hideWindow = true;
                Time.timeScale = 0;
            }
        }

        if (hideWindow)
        {
            //Your window code here
            GUI.backgroundColor = Color.black;
            windowRect = new Rect(0, 0, Screen.width - 20, Screen.height - 20);
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "Shop");
        }
    }
    public void DoMyWindow(int windowID)
    {
        Debug.Log(dragon.Coins + "coins");
        // Dragon dragon = new NightFury();
       // List<int> numberCoins = new List<int>();
        int stone = 0;
        if (dragon.Coins > 0)
        {
            stone = dragon.Coins / 10;
            Debug.Log(stone + "stone");
        }

        //dragon.Coins = 0;
        //dragon.UpdateScore();
       // dragon.Exp += 1;
       // dragon.UpdateExp();
        Debug.Log(dragon.HP + "HP");
        string text = "" + stone;
        GUI.Label(new Rect(10, 10, Screen.width - 20, Screen.height - 20), text);
    }
}
