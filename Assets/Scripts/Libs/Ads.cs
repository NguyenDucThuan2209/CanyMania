﻿using UnityEngine;
using System.Collections;
public class Ads : MonoBehaviour
{

    string ModeName;        // mode of game - Arcede or classic
    void Start()
    {

        if (PLayerInfo.MODE == 1)
            ModeName = "ARCADE ";
        else
            ModeName = "CLASSIC ";
        MusicController.Music.BG_play();

        // check show admob interstitial or no
        if (!Timer.timer.isreq)
        {
            Timer.timer.isreq = true;
        }

        // request Google Analytics
        AdmobGA.Instance.GA.LogScreen(ModeName + "Level: " + PLayerInfo.MapPlayer.Level);

    }

}
