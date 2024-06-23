using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] public string androidGameId;
    [SerializeField] public string iosGameId;
    [SerializeField] public bool isTesting;

    [SerializeField] public InterstitialAds interstitialAds;

    private string gameId;

    private void Awake()
    {
        #if UNITY_IOS
            gameId = iosGameId;
        #elif UNITY_ANDROID
            gameId = androidGameId;
        #elif UNITY_EDITOR
            gameId = androidGameId;
        #endif

        if(!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTesting, this);
        }

    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads Initialization Complete");
        interstitialAds.LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Ads Initialization Failed");
    }
}
