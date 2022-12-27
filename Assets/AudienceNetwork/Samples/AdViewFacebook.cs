using UnityEngine;
using AudienceNetwork;
public class AdViewFacebook : MonoBehaviour
{
    private AdView adView;
    private int SeedIndex = 5;

    void Awake()
    {

        if (AdmobFB.load.Isactive)
        {
            bool isActive = PLayerInfo.MapPlayer.Level >= AdmobFB.SpecialNum;

            if (isActive)
            {
                System.Random r = new System.Random();
                int temp = r.Next(0, 100);

                if (temp < SeedIndex * 10)
                {
                    AdmobFB.load.isOnFb = false;
                }
                else
                {
                    AdmobFB.load.isOnFb = true;
                }
            }
            else
            {
                AdmobFB.load.isOnFb = false;
            }
        }
        else
        {
            AdmobFB.load.isOnFb = false;
        }

        if (AdmobFB.load.isOnFb)
        {
            try
            {
                AdView adView = new AdView(AdmobFB.BnId, AdmobFB.load.CurAdSize);
                this.adView = adView;
                this.adView.Register(this.gameObject);
                // Set delegates to get notified on changes or when the user interacts with the ad.
                this.adView.AdViewDidLoad = (delegate ()
                {
                    Debug.Log("Ad view loaded.");
                    this.adView.Show(AudienceNetwork.Utility.AdUtility.height() - 50);
                });
                adView.AdViewDidFailWithError = (delegate (string error)
                {
                    Debug.Log("Ad view failed to load with error: " + error);

                });
                adView.AdViewWillLogImpression = (delegate ()
                {
                    Debug.Log("Ad view logged impression.");
                });
                adView.AdViewDidClick = (delegate ()
                {
                    Debug.Log("Ad view clicked.");
                });

                // Initiate a request to load an ad.
                adView.LoadAd();

            }
            catch
            {

            }
        }
    }

    void OnDestroy()
    {
        // Dispose of banner ad when the scene is destroyed
        if (this.adView)
        {
            this.adView.Dispose();
        }
        Debug.Log("AdViewTest was destroyed!");
    }
}
