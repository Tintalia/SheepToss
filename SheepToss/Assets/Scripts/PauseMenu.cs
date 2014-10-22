using UnityEngine;
using System.Collections;

public class PauseMenu : Menu
{
	public bool paused = false;
    public Texture2D pause;
	
    public override void OnGUI()
    {
        GUI.backgroundColor = Color.clear;
		
        if (GUI.Button(new Rect(70, Screen.height - 40, 50, 40), pause))
        {
            paused = true;
            Time.timeScale = 0;
        }
		
        if (Input.GetKey("p"))
        {
            paused = true;
            Time.timeScale = 0;
        }
		
        if (paused == true)
        {
            GUI.backgroundColor = Color.black;
            GUI.Box(new Rect(0, buttonPos1, buttonSizeW, buttonSizeH), "Menu");

            if (GUI.Button(new Rect(0, buttonPos2, buttonSizeW, buttonSizeH), "Resume"))
            {
                paused = false;
                Time.timeScale = 1f;

            }

            if (GUI.Button(new Rect(0, buttonPos3, buttonSizeW, buttonSizeH), "Main Menu"))
            {
                Application.LoadLevel(0);
            }

            if (GUI.Button(new Rect(0, buttonPos4, buttonSizeW, buttonSizeH), "Quit"))
            {
                Application.Quit();
            }
        }

        //if (paused == true)
        //{
        //    Time.timeScale = 0;
        //}
        //if (paused == false)
        //{
        //    Time.timeScale = 1;
        //}
    }
}
