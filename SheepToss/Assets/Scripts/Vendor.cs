using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vendor : MonoBehaviour
{

    private bool hideWindow = false;
    public Texture texture;
    public Rect windowRect;
    public Dragon dragon;
    private string text;
    private bool hasPurchased = false;

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
            if (!hasPurchased)
            {
                Debug.Log("Has purchased!");
            }
            GUI.backgroundColor = Color.black;
            windowRect = new Rect(0, 0, Screen.width - 20, Screen.height - 20);
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "Shop");
        }
    }
    public void DoMyWindow(int windowID)
    {
        Dragon dragon = UnityEngine.GameObject.FindGameObjectWithTag("Player").GetComponent<NightFury>();
        int stone = 0;
        if (dragon.Coins > 0)
        {
            if (!hasPurchased)
            {
                stone = dragon.Coins / 10;
                hasPurchased = true;
                dragon.Coins -= stone * 10;
                dragon.Stones = stone;
                dragon.UpdateScore();
                text = "You purchased " + stone + " stones!!!";
            }
        }
        GUI.Label(new Rect(10, 10, Screen.width - 20, Screen.height - 20), text);
    }
}
