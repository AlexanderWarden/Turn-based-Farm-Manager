using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FieldScr : MonoBehaviour
{
    #region Variables

    [Header("Scripts Refs: ")]
    public FarmScr Farm;

    public FameShow fameShow;

    [Header("FieldIsActive")]

    public bool FieldIsActive;
    

    [Header("Field CAP")]
    
    public int FieldCap;
    public TextMeshProUGUI FieldCapText;

    [Header("Prod Settings")]

    public int ChoosenProd = 0;
    public int ProdAmount = 0;

    [Header("Screens: ")]
    public GameObject ProdChooseScreen;
    public GameObject SeedsAmountScreen;

    [Header("Field Is On")]

    public GameObject FieldIsOn;
    public GameObject ClickBtn;

    public GameObject WheetIconIsOn;
    public GameObject VegsIconIsOn;
    public GameObject GrapesIconIsOn;

    [Header("Fertility: ")]

    public int fertility;
    public TextMeshProUGUI FertilityText;

    [Header("Turns Left")]

    public int FieldTurn;
    public int ShowTurns;
    public TextMeshProUGUI TurnsLeftText;

    [Header("Seeds")]

    public int SeedsAmount = 0;

    public TextMeshProUGUI SeedsAmountText;
    public TextMeshProUGUI FieldSeedsTxt;

    public GameObject WheetIconOnSeeds;
    public GameObject VegsIconOnSeeds;
    public GameObject GrapesIconOnSeeds;
    
    [Header("Havrest")]

    public int HarvestAmount = 0;
    public GameObject HarvestBtn;
    public GameObject HarvestAlert;

    public bool HarvestReady;

    [Header("FameUnlock")]
    public GameObject fameUnlock;

    public GameObject VegsUnlockObj;
    public GameObject GrapesUnlockObj;

    public TextMeshProUGUI VegsUnlockFameText;
    public TextMeshProUGUI GrapesUnlockFameText;

    public bool FieldIsPlanted = false;

    public AudioClip AcceptSound;

    #endregion

    #region Update

    private void Update()
    {
        FieldCapText.text = GameManager.Instance.CountText(FieldCap);

        /*switch(ChoosenProd)
        {
            case 1:
                ProdAmount = Farm.wheets;
                break;
            case 2:
                ProdAmount = Farm.vegetables;
                break;
            case 3:
                ProdAmount = Farm.grapes;
                break;
            default:
                break;
        }*/

        //UnlockWithFame();
    }

    #endregion

    /*private void UnlockWithFame()
    {
        VegsUnlockFameText.text = fameShow.fameLock6.ToString();
        GrapesUnlockFameText.text = fameShow.fameLock15.ToString();

        if(GameManager.Instance.fame >= fameShow.fameLock6)
        {
            SoundManager.Instance.PlaySound(AcceptSound);
        }
            VegsUnlockObj.SetActive(false);
        
        if(GameManager.Instance.fame >= fameShow.fameLock15)
        {
            SoundManager.Instance.PlaySound(AcceptSound);
            GrapesUnlockObj.SetActive(false);
        }
            
    }*/

    //public bool WheetIsPlanted = false;

    

    #region TurnLogic

    public void FieldTurnLogic()
    {
        if(SeedsAmount > 0)
        {
            switch(ChoosenProd)
            {
                case 1:
                    if(FieldTurn >= Farm.WheetTurnsNeeded)
                    {
                        HarvestBtn.SetActive(true);
                        //FieldHarvestAmount.SetActive(true);
                        HarvestAlert.SetActive(true);
                        HarvestReady = true;
                
                        //HarvestAmountText.text = GameManager.Instance.CountText(ShowHarvestAmount);
                        TurnsLeftText.text = "";
                        FertilityText.text = "";
                        TurnRecap.Instance.GetTextStrings("Wheet are ready!");
                        //WheetHarvestReady = true;
                        //newsScr.FarmNewsObj.SetActive(true);
                    }
                    else
                    {
                        ShowTurns = Farm.WheetTurnsNeeded - FieldTurn;
                        TurnsLeftText.text = "Turns: " + ShowTurns.ToString();
                        TurnRecap.Instance.GetTextStrings("Wheet(Turns left: " + ShowTurns.ToString() + ")");
                        FieldTurn++;

                    }
                    break;
                case 2:
                    if(FieldTurn >= Farm.VegetablesTurnsNeeded)
                    {
                        HarvestBtn.SetActive(true);
                        //FieldHarvestAmount.SetActive(true);
                        HarvestAlert.SetActive(true);
                        HarvestReady = true;
                
                        //HarvestAmountText.text = GameManager.Instance.CountText(ShowHarvestAmount);
                        TurnsLeftText.text = "";
                        FertilityText.text = "";
                        TurnRecap.Instance.GetTextStrings("Vegs are ready!");
                        //VegetablesHarvestReady = true;
                        //newsScr.FarmNewsObj.SetActive(true);
                    }
                    else
                    {
                        ShowTurns = Farm.VegetablesTurnsNeeded - FieldTurn;
                        TurnsLeftText.text = "Turns: " + ShowTurns.ToString();
                        TurnRecap.Instance.GetTextStrings("Vegs(Turns left: " + ShowTurns.ToString() + ")");
                        FieldTurn++;

                        FertilityText.text = "Fertility: " + fertility.ToString();
                    }
                    break;
                case 3:
                    if(FieldTurn >= Farm.GrapesTurnsNeeded)
                    {
                        HarvestBtn.SetActive(true);
                        //FieldHarvestAmount.SetActive(true);
                        HarvestAlert.SetActive(true);
                        HarvestReady = true;
                
                        //HarvestAmountText.text = GameManager.Instance.CountText(ShowHarvestAmount);
                        TurnsLeftText.text = "";
                        FertilityText.text = "";
                        TurnRecap.Instance.GetTextStrings("Grapes are ready!");
                        //GrapesHarvestReady = true;
                        //newsScr.FarmNewsObj.SetActive(true);
                    }
                    else
                    {
                        ShowTurns = Farm.GrapesTurnsNeeded - FieldTurn;
                        TurnsLeftText.text = "Turns: " + ShowTurns.ToString();
                        TurnRecap.Instance.GetTextStrings("Vegs(Turns left: " + ShowTurns.ToString() + ")");
                        FieldTurn++;

                        FertilityText.text = "Fertility: " + fertility.ToString();
                    }
                    break;
                default:
                    break;
            
            }
        }
        
    }

    #endregion

    #region ChooseProd

    public void FieldClickTrigger()
    {
        ProdChooseScreen.SetActive(true);
        SoundManager.Instance.PlaySound(AcceptSound);
        //EventsScr.Instance.EventPopText("Choose Product you want to plant!"); // может в подсказки добавить
    }

    public void WheetChoosen()
    {
        ChoosenProd = 1;
        ProdAmount = Farm.wheets;
        SeedsAmountScreen.SetActive(true);
        ProdChooseScreen.SetActive(false);
        
        WheetIconOnSeeds.SetActive(true);
        VegsIconOnSeeds.SetActive(false);
        GrapesIconOnSeeds.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void VegsChoosen()
    {
        ChoosenProd = 2;
        ProdAmount = Farm.vegetables;
        SeedsAmountScreen.SetActive(true);
        ProdChooseScreen.SetActive(false);

        WheetIconOnSeeds.SetActive(false);
        VegsIconOnSeeds.SetActive(true);
        GrapesIconOnSeeds.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void GrapesChoosen()
    {
        ChoosenProd = 3;
        ProdAmount = Farm.grapes;
        SeedsAmountScreen.SetActive(true);
        ProdChooseScreen.SetActive(false);

        WheetIconOnSeeds.SetActive(false);
        VegsIconOnSeeds.SetActive(false);
        GrapesIconOnSeeds.SetActive(true);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void BackChoosen()
    {
        ProdChooseScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region SeedsAmount

    public void SeedsAmountPlant()
    {
        if(SeedsAmount > 0)
        {
            switch(ChoosenProd)
            {
                case 1:
                    Farm.wheets -= SeedsAmount;
                    //Farm.SelectedCulture = 1;
                    HarvestAmount = SeedsAmount * FertilityByRandom(ChoosenProd);
                    WheetIconIsOn.SetActive(true);
                    ShowTurns = Farm.WheetTurnsNeeded;
                    EventsScr.Instance.EventPopText("You have planted: " + SeedsAmount + " wheet!");
                    break;
                case 2:
                    Farm.vegetables -= SeedsAmount;
                    //Farm.SelectedCulture = 2;
                    HarvestAmount = SeedsAmount * FertilityByRandom(ChoosenProd);
                    VegsIconIsOn.SetActive(true);
                    ShowTurns = Farm.VegetablesTurnsNeeded;
                    EventsScr.Instance.EventPopText("You have planted: " + SeedsAmount + " veges!");
                    break;
                case 3:
                    Farm.grapes -= SeedsAmount;
                    //Farm.SelectedCulture = 3;
                    HarvestAmount = SeedsAmount * FertilityByRandom(ChoosenProd);
                    GrapesIconIsOn.SetActive(true);
                    ShowTurns = Farm.GrapesTurnsNeeded;
                    EventsScr.Instance.EventPopText("You have planted: " + SeedsAmount + " grapes!");
                    break;
                default:
                    break;
                
            }

            FieldIsOn.SetActive(true);

            SeedsAmountScreen.SetActive(false);
            ClickBtn.SetActive(false);

            FieldSeedsTxt.text = GameManager.Instance.CountText(SeedsAmount);

            //Farm.TurnsUntilHarvest.text = "Turns: " + Farm.WheetTurnsNeeded.ToString();

            //Farm.ShowHarvestAmount = HarvestAmount;

            FertilityText.text = "Fertility: " + fertility.ToString();
            TurnsLeftText.text = "Turns: " + ShowTurns.ToString();
            FieldTurn++;
            SeedsAmountText.text = "";

            
            //TurnRecap.Instance.GetTextStrings("You planted Wheet!");

            //WheetIsPlanted = true;
        }

        SoundManager.Instance.PlaySound(AcceptSound);

    }

    public void SeedsAmountCancel()
    {
        SeedsAmountScreen.SetActive(false);
        SeedsAmountText.text = "";
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void SeedsAmountQuater()
    {
        if(ProdAmount >= FieldCap)
            SeedsAmount = (FieldCap / 100) * 25;
        else
            SeedsAmount = (ProdAmount / 100) * 25;
        
        SeedsAmountText.text = GameManager.Instance.CountText(SeedsAmount);
        //EventsScr.Instance.EventPopText("You will plant: " + SeedsAmount + " wheet!");
        SoundManager.Instance.PlaySound(AcceptSound);
        
    }

    public void SeedsAmountHalf()
    {
        if(ProdAmount >= FieldCap)
            SeedsAmount = FieldCap / 2;
        else
            SeedsAmount = ProdAmount / 2;   

        SeedsAmountText.text = GameManager.Instance.CountText(SeedsAmount);
        //EventsScr.Instance.EventPopText("You will plant: " + SeedsAmount + " wheet!");
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void SeedsAmountFull()
    {
        if(ProdAmount >= FieldCap)
            SeedsAmount = FieldCap;
        else
            SeedsAmount = ProdAmount;  

        SeedsAmountText.text = GameManager.Instance.CountText(SeedsAmount); 
        //EventsScr.Instance.EventPopText("You will plant: " + SeedsAmount + " wheet!");
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region Fertility

    public int FertilityByRandom(int prod)
    {
        switch(prod)
        {
            case 1:
                int wheetFertilityByRandom = Random.Range(Farm.wheetFertilityInput - Farm.wheetFertilityRange,
                                        Farm.wheetFertilityInput + Farm.wheetFertilityRange);
                fertility = wheetFertilityByRandom;
                break;
            case 2:
                int vegsFertilityByRandom = Random.Range(Farm.vegsFertilityInput - Farm.vegsFertilityRange,
                                        Farm.vegsFertilityInput + Farm.vegsFertilityRange);
                fertility = vegsFertilityByRandom;
                break;
            case 3:
                int grapesFertilityByRandom = Random.Range(Farm.wheetFertilityInput - Farm.wheetFertilityRange,
                                        Farm.wheetFertilityInput + Farm.wheetFertilityRange);
                fertility = grapesFertilityByRandom;
                break;
            default:
                Debug.Log("FertilityByRange Switch Default Exception!");
                break;
        }

        FertilityText.text = "Fertility : " + fertility;
        return fertility;
    }

    #endregion

    #region Harvest

    public void HarvestButton()
    {
        switch(ChoosenProd)
        {
            case 1:
                Farm.wheets += HarvestAmount;

                SeedsAmount = 0;
                HarvestReady = false;
                FieldIsPlanted = false;
                WheetIconIsOn.SetActive(false);
                WheetIconOnSeeds.SetActive(false);

                FieldSeedsTxt.text = GameManager.Instance.CountText(SeedsAmount);
                FieldIsOn.SetActive(false);
                

                //OpenAllFields();
                FieldResetAfterHarvest();
                EventsScr.Instance.EventPopText("You have harvested: " + HarvestAmount + " wheet!");
                SoundManager.Instance.PlaySound(AcceptSound);
                break;
            case 2:
                Farm.vegetables += HarvestAmount;

                SeedsAmount = 0;
                HarvestReady = false;
                VegsIconIsOn.SetActive(false);
                VegsIconOnSeeds.SetActive(false);

                FieldSeedsTxt.text = GameManager.Instance.CountText(SeedsAmount);
                FieldIsOn.SetActive(false);

                //OpenAllFields();
                FieldResetAfterHarvest();
                EventsScr.Instance.EventPopText("You have harvested: " + HarvestAmount + " vegetables!");
                SoundManager.Instance.PlaySound(AcceptSound);
                break;
            case 3:
                Farm.grapes += HarvestAmount;

                SeedsAmount = 0;
                HarvestReady = false;
                GrapesIconIsOn.SetActive(false);
                GrapesIconOnSeeds.SetActive(false);

                FieldSeedsTxt.text = GameManager.Instance.CountText(SeedsAmount);
                FieldIsOn.SetActive(false);

                //OpenAllFields();
                FieldResetAfterHarvest();
                EventsScr.Instance.EventPopText("You have harvested: " + HarvestAmount + " grapes!");
                SoundManager.Instance.PlaySound(AcceptSound);
                break;
            default:
                Debug.Log("Nothing to harvest!");
                break;

        }
    }

    #endregion

    #region FieldReset

    public void FieldResetAfterHarvest()
    {
        ChoosenProd = 0;
        FieldTurn = 1;

        ClickBtn.SetActive(true);

        HarvestBtn.SetActive(false);
        //FieldHarvestAmount.SetActive(false);
        HarvestAlert.SetActive(false);
    }

    #endregion
}
