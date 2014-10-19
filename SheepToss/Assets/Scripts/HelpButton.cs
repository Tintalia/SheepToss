using UnityEngine;
using System.Collections;

public class HelpButton : MonoBehaviour
{

    private bool hideWindow = false;
    public Texture texture;
    public Texture coinStar;
    public float x = 120f;
    public float y = 120f;
    public float width = 20f;
    public float height = 20f;
    public Rect windowRect;

    public void OnGUI()
    {
        GUI.backgroundColor = Color.clear;
        GUI.Button(new Rect(Screen.width / 2 + 80, 5, 40, 40), coinStar);

        if (GUI.Button(new Rect(Screen.width - 40, Screen.height - 40, 40, 40), texture))
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
            GUI.backgroundColor = Color.black;
            windowRect = new Rect(0, 0, Screen.width - 20, Screen.height - 20);
           // GUI.Box(new Rect(0, 0, Screen.width - 20, Screen.height - 20), "Menu");
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "Help");

        }
    }
    public void DoMyWindow(int windowID)
    {
        GUI.Label(new Rect(10, 10, Screen.width - 20, Screen.height - 20), "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
        "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown " +
        "printer took a galley of type and scrambled it to make a type specimen book. It has survived" +
            "not only five centuries, but also the leap into electronic typesetting, remaining essentially " +
        "unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
           " Ipsum passages, and more recently with " +
        "desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");

    }
}

