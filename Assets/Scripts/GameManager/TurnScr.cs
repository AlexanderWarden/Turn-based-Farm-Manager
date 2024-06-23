using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnScr : MonoBehaviour
{

    public FarmScr farm;
    public BarnScr barn;

    public HensScr hensScr;
    public SheepsScr sheepsScr;
    public CowsScr cowsScr;

    public ShopPrices shopPrices;
    public StoreShow storeShow;
    public StoreScr storeScr;
    public TurnRecap turnRecap;
    public WorkerFarmers farmers;
    public WorkerLivestock livestokers;

    public ContractsScr contract;

    public int turnCount = 1;
    public TextMeshProUGUI turnCountText;
    public AudioClip AcceptSound;

    public int AdTurns = 0;
    public int AdNeededTurns;

    private void Update()
    {
        turnCountText.text = "Turn: " + GameManager.Instance.CountText(turnCount);

        if(AdTurns > AdNeededTurns)
        {
            StartCoroutine(ShowAds());
            AdTurns = 0;
        }
        
    }

    private IEnumerator ShowAds()
    {
        //yield return new WaitForSeconds(1);
        AdsManager.Instance.interstitialAds.ShowAd();
        yield return new WaitForSeconds(6);
        AdsManager.Instance.interstitialAds.LoadAd();
        yield return new WaitForSeconds(3);
        StopCoroutine(ShowAds());
    }

    public void TurnButton()
    {
        turnRecap.ClearAllStrings();

        farm.FarmTurnLogic();

        if(hensScr.HensAreActive)
            hensScr.HensTurnLogic();
        if(sheepsScr.SheepsAreActive)
            sheepsScr.SheepsTurnLogic();
        if(cowsScr.CowsAreActive)
            cowsScr.CowsTurnLogic();
        
        farmers.Field1AutoPlant();
        farmers.Field2AutoPlant();
        farmers.Field3AutoPlant();
        
        livestokers.LivestockersFeedByTurn();
        livestokers.LivestockersBreedByTurn();

        contract.ContractByTurn();

        storeScr.BuyLockReset();
        shopPrices.SetPricesForTurn();
        storeShow.SelectedObjectOnWithTurn();

        GameManager.Instance.techByTurn();
        GameManager.Instance.fameByTurn();
        
        turnCount++;
        AdTurns++;
        turnCountText.text = "Turn:" + turnCount.ToString();
        SoundManager.Instance.PlaySound(AcceptSound);

    }
}
