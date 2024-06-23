using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] public string androidAdUnitId;
    [SerializeField] public string iosAdUnitId;

    private string adUnitId;

    private void Awake()
    {
        #if UNITY_IOS
            adUnitId = iosAdUnitId;
        #elif UNITY_ANDROID
            adUnitId = androidAdUnitId;
        #endif
    }

    public void LoadRewardedAd()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowRewardedAd()
    {
        Advertisement.Show(adUnitId, this);
        LoadRewardedAd();
    }

    #region Load Interface

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Interstitial Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }

    #endregion

    #region Show Interface

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) {    }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if(placementId == adUnitId && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Ads fully watched!");
        }
        
    }
    #endregion
}
