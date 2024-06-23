using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarnScr : MonoBehaviour
{
    public HensScr hensScr;
    public SheepsScr sheepsScr;
    public CowsScr cowsScr;

    //public HasNewsScr newsScr;

    public int eggs;
    public int wool;
    public int milk;

    public int hens;
    public int sheeps;
    public int cows;

    public TextMeshProUGUI eggsInfoText;
    public TextMeshProUGUI woolInfoText;
    public TextMeshProUGUI milkInfoText;

    public TextMeshProUGUI hensInfoText;
    public TextMeshProUGUI sheepsInfoText;
    public TextMeshProUGUI cowsInfoText;

    public TextMeshProUGUI hensHungryText;
    public TextMeshProUGUI sheepsHungryText;
    public TextMeshProUGUI cowsHungryText;
    
    public int HensBarnTurn = 0;
    
    public int hensMissing;

    //public int EggsCapAmount = 500;
    public int HensCapAmount;

    //public int WoolCapAmount;
    public int SheepsCapAmount;

    //public int MilkCapAmount;
    public int CowsCapAmount;

    public int AnimalsCapBoost = 0;

    //public GameObject HensUnlockObj;
    public GameObject HensShowTopInfo;

    //public GameObject SheepsUnlockObj;
    public GameObject SheepsShowTopInfo;

    //public GameObject CowsUnlockObj;
    public GameObject CowsShowTopInfo;

    public GameObject ShowThatHungryObj;
    public GameObject ShowThatOverCapObj;

    public bool BarnIsActivated = false;

    private void Update()
    {
        BarnTopInfo();

        BarnCapCheck();
        ShowHungryAnimals();

        //HasNewsScr.BarnNewsObj.SetActive(false);
    }

    public void HensUnlock()
    {
        //HensUnlockObj.SetActive(false);
        HensShowTopInfo.SetActive(true);
        hensScr.HensAreActive = true;

        //HasNewsScr.Instance.BarnNewsObj.SetActive(true);
        TurnRecap.Instance.GetTextStrings("Hens are unlocked!");
        EventsScr.Instance.EventPopText("You have unlocked Barn and Hens & Eggs!");
    }

    public void CowsUnlock()
    {
        //CowsUnlockObj.SetActive(false);
        CowsShowTopInfo.SetActive(true);
        cowsScr.CowsAreActive = true;

        //HasNewsScr.BarnNewsObj.SetActive(true);
        TurnRecap.Instance.GetTextStrings("Cows are unlocked!");
        EventsScr.Instance.EventPopText("You have unlocked Cows & Milk!");
    }

    public void SheepsUnlock()
    {
        //SheepsUnlockObj.SetActive(false);
        SheepsShowTopInfo.SetActive(true);
        sheepsScr.SheepsAreActive = true;

        //HasNewsScr.BarnNewsObj.SetActive(true);
        TurnRecap.Instance.GetTextStrings("Sheeps are unlocked!");
        EventsScr.Instance.EventPopText("You have unlocked Sheeps & Wool!");
    }

    public void BarnTopInfo()
    {
        eggsInfoText.text = GameManager.Instance.CountText(eggs);
        woolInfoText.text = GameManager.Instance.CountText(wool);
        milkInfoText.text = GameManager.Instance.CountText(milk);

        hensInfoText.text = GameManager.Instance.CountText(hens);
        sheepsInfoText.text = GameManager.Instance.CountText(sheeps);
        cowsInfoText.text = GameManager.Instance.CountText(cows);

    }

    public void BarnCapCheck()
    {
        //GameManager.Instance.CapCheck(eggs, EggsCapAmount, eggsInfoText, true);
        //GameManager.Instance.CapCheck(wool, WoolCapAmount, woolInfoText, true);
        //GameManager.Instance.CapCheck(milk, MilkCapAmount, milkInfoText, true);

        GameManager.Instance.CapCheck(hens, HensCapAmount, hensInfoText, false);
        GameManager.Instance.CapCheck(sheeps, SheepsCapAmount, sheepsInfoText, false);
        GameManager.Instance.CapCheck(cows, CowsCapAmount, cowsInfoText, false);

        if(BarnIsActivated)
        {
            if(hensScr.HensLeftoversNumber > 0 || sheepsScr.SheepsLeftoversNumber > 0 || cowsScr.CowsLeftoversNumber > 0)
                ShowThatOverCapObj.SetActive(true);
            else
                ShowThatOverCapObj.SetActive(false);
        }
        
    }

    public void ShowHungryAnimals()
    {
        //hensScr.HensHungerLogic();
        hensHungryText.text = GameManager.Instance.CountText(hensScr.UnFeedHens);
        sheepsHungryText.text = GameManager.Instance.CountText(sheepsScr.UnFeedSheeps);
        cowsHungryText.text = GameManager.Instance.CountText(cowsScr.UnFeedCows);

        if(BarnIsActivated)
        {
            if(hensScr.UnFeedHens > 0 || sheepsScr.UnFeedSheeps > 0 || cowsScr.UnFeedCows > 0)
                ShowThatHungryObj.SetActive(true);
            else
                ShowThatHungryObj.SetActive(false);
        }
        
    }

}
