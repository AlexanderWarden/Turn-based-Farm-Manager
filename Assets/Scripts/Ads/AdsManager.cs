using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public InitializeAds initializeAds;
    public BannerAds bannerAds;
    public InterstitialAds interstitialAds;
    public RewardedAds rewardedAds;

    public static AdsManager Instance { get; private set;}

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        /*if(Instance == null)
            Instance = this;*/

        //interstitialAds.LoadInterstitialAd();
        bannerAds.LoadBannerAd();
        
        rewardedAds.LoadRewardedAd();
    }
}
