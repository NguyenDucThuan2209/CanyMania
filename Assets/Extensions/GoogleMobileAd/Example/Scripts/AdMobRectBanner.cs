////////////////////////////////////////////////////////////////////////////////
//  
// @module Google Ads Unity SDK 
// @author Osipov Stanislav (Stan's Assets) 
// @support stans.assets@gmail.com 
//
////////////////////////////////////////////////////////////////////////////////


using UnityEngine;
using System.Collections;
using System.Collections.Generic;


#if UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 
#else
using UnityEngine.SceneManagement;
#endif



//Attach the script to the empty gameobject on your sceneS
public class AdMobRectBanner : MonoBehaviour
{

    public static AdMobRectBanner load;     // instance of this class

    public GADBannerSize size = GADBannerSize.SMART_BANNER;
    public TextAnchor anchor = TextAnchor.LowerCenter;

    private static Dictionary<string, GoogleMobileAdBanner> _registerdBanners = null;


    // --------------------------------------
    // Unity Events
    // --------------------------------------

    void OnDestroy()
    {
            HideRectBanner();
    }


    // --------------------------------------
    // PUBLIC METHODS
    // --------------------------------------

    public void ShowRectBanner()
    {
        GoogleMobileAdBanner banner;
        if (registerdBanners.ContainsKey(Loading))
        {
            banner = registerdBanners[Loading];
        }
        else
        {
            banner = GoogleMobileAd.CreateAdBanner(anchor, size);
            registerdBanners.Add(Loading, banner);
        }

        if (banner.IsLoaded && !banner.IsOnScreen)
        {
            banner.Show();
        }
    }

    public void HideRectBanner()
    {
        if (registerdBanners.ContainsKey(Loading))
        {
            GoogleMobileAdBanner banner = registerdBanners[Loading];
            if (banner.IsLoaded)
            {
                if (banner.IsOnScreen)
                {
                    banner.Hide();
                }
            }
            else
            {
                banner.ShowOnLoad = false;
            }
        }
    }

    // --------------------------------------
    // GET / SET
    // --------------------------------------


    public static Dictionary<string, GoogleMobileAdBanner> registerdBanners
    {
        get
        {
            if (_registerdBanners == null)
            {
                _registerdBanners = new Dictionary<string, GoogleMobileAdBanner>();
            }

            return _registerdBanners;
        }
    }

    public string sceneBannerId
    {
        get
        {
#if UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2
            return Application.loadedLevelName + "_" + this.gameObject.name;
#else
			return SceneManager.GetActiveScene().name + "_" + this.gameObject.name;
#endif
        }
    }

    private string Loading = "Loading";
}
