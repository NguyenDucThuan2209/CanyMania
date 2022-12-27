using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using AudienceNetwork;

public class InterstitialAdFacebook : MonoBehaviour
{

    private InterstitialAdFacebook advertise;      // instance of  GoogleMobileAdsScript

    private InterstitialAd interstitialAd;
    public bool isLoaded;

    public void LoadInterstitial()
    {
        try
        {
            InterstitialAd interstitialAd = new InterstitialAd(AdmobFB.ItId);
            this.interstitialAd = interstitialAd;
            this.interstitialAd.Register(this.gameObject);

            // Set delegates to get notified on changes or when the user interacts with the ad.
            this.interstitialAd.InterstitialAdDidLoad = (delegate ()
            {
                Debug.Log("Interstitial ad loaded.");
                this.isLoaded = true;
                ShowInterstitial();
            });
            interstitialAd.InterstitialAdDidFailWithError = (delegate (string error)
            {
                Debug.Log("Interstitial ad failed to load with error: " + error);
            });
            interstitialAd.InterstitialAdWillLogImpression = (delegate ()
            {
                Debug.Log("Interstitial ad logged impression.");
            });
            interstitialAd.InterstitialAdDidClick = (delegate ()
            {
                Debug.Log("Interstitial ad clicked.");
            });

            // Initiate the request to load the ad.
            this.interstitialAd.LoadAd();
        }
        catch
        {

        }
    }

    // Show button
    public void ShowInterstitial ()
    {
        if (this.isLoaded) {
            this.interstitialAd.Show ();
            this.isLoaded = false;
        }
    }

    void OnDestroy ()
    {
        // Dispose of interstitial ad when the scene is destroyed
        if (this.interstitialAd != null) {
            this.interstitialAd.Dispose ();
        }
        Debug.Log ("InterstitialAdTest was destroyed!");
    }
}
