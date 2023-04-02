using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdmobManager : Singleton<AdmobManager>
{
    public bool isTestMode;

    List<string> testDeviceIds=new List<string>();
    
    void Start()
    {
        testDeviceIds.Add("33a2cb135b0e0a4e");
        testDeviceIds.Add("9d4f0bc9a0f1fc5b");


        var requestConfiguration = new RequestConfiguration
           .Builder()
           .SetTestDeviceIds(testDeviceIds) // test Device ID
           .build();

        MobileAds.SetRequestConfiguration(requestConfiguration);

        LoadBannerAd();

        bannerAd.Show();
    

    }

    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }


    #region ¹è³Ê ±¤°í
    const string bannerTestID = "ca-app-pub-3940256099942544/6300978111";
    const string bannerID = "ca-app-pub-7520415550513335/8290760194";
    BannerView bannerAd;

    public void BannerOn(bool result)
    {
        if (bannerAd == null)
            return;

        if(result)
        {
            bannerAd.Show();
        }else
        {
            bannerAd.Hide();

        }
    }

    void LoadBannerAd()
    {
        bannerAd = new BannerView(isTestMode ? bannerTestID : bannerID,
            AdSize.Banner, AdPosition.Bottom);
        bannerAd.LoadAd(GetAdRequest());
        ToggleBannerAd(false);
    }

    public void ToggleBannerAd(bool b)
    {
        if (b) bannerAd.Show();
        else bannerAd.Hide();
    }
    #endregion


}
