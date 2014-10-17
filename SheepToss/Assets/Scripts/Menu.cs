using UnityEngine;
using System.Collections;

public abstract class Menu : MonoBehaviour
{
    protected float topBannerH;
    protected float topBannerW;

    protected float buttonSizeH;
    protected float buttonSizeW;
    protected float buttonPos1;
    protected float buttonPos2;
    protected float buttonPos3;
    protected float buttonPos4;
    protected float buttonPos5;

    protected float buttonBannerH;
    protected float buttomBannerW;
    protected float buttombannerPos;

    private void Awake()
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

    public abstract void OnGUI();
}