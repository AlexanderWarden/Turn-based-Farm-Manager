using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesScr : MonoBehaviour
{
    public static ScenesScr Instance;

    //public HasNewsScr newsScr;

    public GameObject FarmScreen;
    public GameObject BarnScreen;
    public GameObject StoreScreen;
    public GameObject HouseScreen;
    public GameObject HouseWorkshopScreen;
    public GameObject HouseOfficeScreen;

    public GameObject HensScreen;
    public GameObject SheepsScreen;
    public GameObject CowsScreen;

    public GameObject JournalScreen;
    public GameObject WorkersScreen;
    public GameObject ContractsScreen;

    public GameObject InfoWorkshopScreen;
    public GameObject InfoBarnScreen;

    public GameObject InfoWorkersScreen;
    public GameObject InfoHensScreen;
    public GameObject InfoCowsScreen;
    public GameObject InfoContractsScreen;

    public AudioClip DoorSound;
    public AudioClip AcceptSound;

    public void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    #region Farm

    public void ToFarmScreen()
    {
        FarmScreen.SetActive(true);
        //HasNewsScr.FarmNewsObj.SetActive(false);
        SoundManager.Instance.PlaySound(DoorSound);
        //AdsManager.Instance.bannerAds.ShowBannerAd();
    }

    public void FarmScreenBack()
    {
        FarmScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
        //AdsManager.Instance.bannerAds.HideBannerAd();
    }

    #endregion

    #region Barn

    public void ToBarnScreen()
    {
        BarnScreen.SetActive(true);
        SoundManager.Instance.PlaySound(DoorSound);
        //AdsManager.Instance.bannerAds.ShowBannerAd();
    }

    public void BarnScreenBack()
    {
        BarnScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
        //AdsManager.Instance.bannerAds.HideBannerAd();
    }

    #endregion

    #region Store

    public void ToStoreScreen()
    {
        StoreScreen.SetActive(true);
        SoundManager.Instance.PlaySound(DoorSound);
    }

    public void StoreScreenBack()
    {
        StoreScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region House

    public void ToHouseScreen()
    {
        HouseScreen.SetActive(true);
        SoundManager.Instance.PlaySound(DoorSound);
        //AdsManager.Instance.bannerAds.ShowBannerAd();
    }

    public void ToHouseScreenBack()
    {
        HouseScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
        //AdsManager.Instance.bannerAds.HideBannerAd();
    }

    #endregion

    #region Workshop
    public void ToHouseWorkshopScreen()
    {
        HouseWorkshopScreen.SetActive(true);
        //AlertsScr.Instance.HouseNewsObj.SetActive(false);
        SoundManager.Instance.PlaySound(DoorSound);
        //AdsManager.Instance.bannerAds.ShowBannerAd();
    }

    public void ToHouseWorkshopScreenBack()
    {
        HouseWorkshopScreen.SetActive(false);
        //SoundManager.Instance.PlaySound(AcceptSound);
        //AdsManager.Instance.bannerAds.HideBannerAd();
    }

    #endregion

    #region Office

    public void ToHouseOfficeScreen()
    {
        HouseOfficeScreen.SetActive(true);
        //HasNewsScr.HouseNewsObj.SetActive(false);
        SoundManager.Instance.PlaySound(DoorSound);
        //AdsManager.Instance.bannerAds.ShowBannerAd();
    }

    public void ToHouseOfficeScreenBack()
    {
        HouseOfficeScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
        //AdsManager.Instance.bannerAds.HideBannerAd();
    }

    #endregion

    #region Hens

    public void ToHensScreen()
    {
        HensScreen.SetActive(true);
        //HasNewsScr.BarnNewsObj.SetActive(false);
        SoundManager.Instance.PlaySound(DoorSound);
        //AdsManager.Instance.bannerAds.HideBannerAd();
    }

    public void HensScreenBack()
    {
        HensScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
        //AdsManager.Instance.bannerAds.ShowBannerAd();
    }

    #endregion

    #region Sheeps

    public void ToSheepsScreen()
    {
        SheepsScreen.SetActive(true);
        SoundManager.Instance.PlaySound(DoorSound);
        //HasNewsScr.BarnNewsObj.SetActive(false);
        //AdsManager.Instance.bannerAds.HideBannerAd();
    }

    public void SheepsScreenBack()
    {
        SheepsScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
        //AdsManager.Instance.bannerAds.ShowBannerAd();
    }

    #endregion

    #region Cows

    public void ToCowsScreen()
    {
        CowsScreen.SetActive(true);
        SoundManager.Instance.PlaySound(DoorSound);
        //HasNewsScr.BarnNewsObj.SetActive(false);
        //AdsManager.Instance.bannerAds.HideBannerAd();
    }

    public void CowsScreenBack()
    {
        CowsScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
        //AdsManager.Instance.bannerAds.ShowBannerAd();
    }

    #endregion

    #region Journal

    public void ToJournalScreen()
    {
        JournalScreen.SetActive(true);
        SoundManager.Instance.PlaySound(AcceptSound);
        //SoundManager.Instance.PlaySound(DoorSound);
    }

    public void JournalScreenBack()
    {
        JournalScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region Contracts

    public void ToContractsScreen()
    {
        ContractsScreen.SetActive(true);
        SoundManager.Instance.PlaySound(DoorSound);
    }

    public void BackContractsScreen()
    {
        ContractsScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region Workers

    public void ToWorkersScreen()
    {
        WorkersScreen.SetActive(true);
        SoundManager.Instance.PlaySound(DoorSound);
    }

    public void BackWorkersScreen()
    {
        WorkersScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region InfoWorkshpScreen

    public void InfoWorkshopScreenTo()
    {
        InfoWorkshopScreen.SetActive(true);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void InfoWorkshopScreenBack()
    {
        InfoWorkshopScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region InfoBarnScreen

    public void InfoBarnScreenTo()
    {
        InfoBarnScreen.SetActive(true);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void InfoBarnScreenBack()
    {
        InfoBarnScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region InfoWorkersScreen

    public void InfoWorkersScreenTo()
    {
        InfoWorkersScreen.SetActive(true);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void InfoWorkersScreenBack()
    {
        InfoWorkersScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region InfoContractsScreen

    public void InfoContractsScreenTo()
    {
        InfoContractsScreen.SetActive(true);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void InfoContractsScreenBack()
    {
        InfoContractsScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region InfoHensScreen

    public void InfoHensScreenTo()
    {
        InfoHensScreen.SetActive(true);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void InfoHensScreenBack()
    {
        InfoHensScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region InfoCowsScreen

    public void InfoCowsScreenTo()
    {
        InfoCowsScreen.SetActive(true);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void InfoCowsScreenBack()
    {
        InfoCowsScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion
}
