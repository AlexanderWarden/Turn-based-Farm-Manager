using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HensScr : MonoBehaviour
{

    #region variables

    [Header("Scripts Objects:")]
    public BarnScr barnScr;
    public FarmScr farmScr;
    public SellLeftovers sellLeftovers;

    public WorkerLivestock WL;

    //public HasNewsScr newsScr;

    [HideInInspector] public int HatchAmount = 0;

    [Header("Leftovers")]

    //public int EggsLeftoversNumber;
    public int HensLeftoversNumber;

    //public GameObject SellEggsLeftovers;
    public GameObject SellHensLeftovers;
    public GameObject SellHensLeftoversInBarn;

    [Header("Food For Hens:")]
    [HideInInspector] public int FoodAmountForHens;
    public int FoodNeededForHens;
    public TextMeshProUGUI FoodForHensText;

    public int FedHens; // how many hens are fed

    public int UnFeedHens;
    public TextMeshProUGUI HungryHensTxt;

    [Header("Eggs to Have:")]

    [HideInInspector] public int eggsToHave;
    public TextMeshProUGUI eggsToHaveText;

    public TextMeshProUGUI hensToHaveText;

    public int eggsMult;

    [Header("Hens/Eggs Field Texts:")]

    public TextMeshProUGUI HensCurrentTxt;
    public TextMeshProUGUI HensCapTxt;

    public TextMeshProUGUI EggsCurrentTxt;
    public TextMeshProUGUI EggsCapTxt;

    [Header("Top Info Texts:")]

    public TextMeshProUGUI HensHaveTxt;
    public TextMeshProUGUI EggsHaveTxt;
    public TextMeshProUGUI WheetsHaveTxt;

    [HideInInspector] public int hensEgging;
    [HideInInspector] public int hensHatching;
    //[HideInInspector] public int hensMissing;

    [Header("Hatching Logic")]

    public int HalfOfFedHens;
    public int PrimalAmount;
    public int HensToBeBorn;

    public TextMeshProUGUI HensToBeBornText;

    public bool PrimalIsOn;
    public int AddCount;
    public int WheetCostForAdd;

    public GameObject BreedButton;
    public GameObject AddButton;
    public GameObject FullBreed;
    public GameObject WheetCostForAddObject;

    public TextMeshProUGUI WheetCostForAddText;
    public TextMeshProUGUI MaxSheepsAmountToBeBornText;

    public GameObject ExtraAlarm;
    public int ExtraHensNumber;
    public TextMeshProUGUI ExtraHensText;
    public int fullAmountOfNewBorns;

    [Header("Show turn before hatch")]

    public TextMeshProUGUI TurnsUntilHens;
    public int TurnsNeeded = 3;
    public int ShowTurns = 0;
    public int HensBarnTurn = 0;
    public int HensHatchingTurn = 0;
    private bool TurnShownInJournal = false;

    // Multiplications

    public int EggsBoost = 0;

    public bool HensAreActive;

    #endregion

    #region Start & Update

    private void Start()
    {
        HensHungerLogic();

    }

    private void Update()
    {
        if(HensAreActive)
        {
            HensGivingEggs();
            CountFoodForHens();

            HensHungerLogic();
        
            LeftoversCheck();

            ShowLogic();

            if(PrimalIsOn)
                CheckForAdd();


            MaxSheepsAmountToBeBornText.text = GameManager.Instance.CountText(HalfOfFedHens);
            WheetCostForAddText.text = GameManager.Instance.CountText(WheetCostForAdd);

            HungryHensTxt.text = "Hungry:" + GameManager.Instance.CountText(UnFeedHens);
            FoodForHensText.text = GameManager.Instance.CountText(FoodAmountForHens);

            HensToBeBornText.text = GameManager.Instance.CountText(HensToBeBorn);
        }

    }

    #endregion
    
    #region ShowLogic

    public void ShowLogic()
    {
        ShowTopInfo();
        ShowHensField();
        ShowEggsField();
        ShowTurnsBeforeHens();
    }

    public void ShowTopInfo()
    {
        GameManager.Instance.CapCheck(barnScr.hens, barnScr.HensCapAmount, HensHaveTxt, false);
        //GameManager.Instance.CapCheck(barnScr.eggs, barnScr.EggsCapAmount, EggsHaveTxt, true);

        HensHaveTxt.text = GameManager.Instance.CountText(barnScr.hens);
        EggsHaveTxt.text = GameManager.Instance.CountText(barnScr.eggs);
        WheetsHaveTxt.text = GameManager.Instance.CountText(farmScr.wheets);
    }

    public void ShowHensField()
    {
        GameManager.Instance.CapCheck(barnScr.hens, barnScr.HensCapAmount, HensCurrentTxt, false);
        HensCurrentTxt.text = GameManager.Instance.CountText(barnScr.hens);
        HensCapTxt.text = GameManager.Instance.CountText(barnScr.HensCapAmount);

        if(HensToBeBorn > 0)
        {
            hensToHaveText.text = "+" + GameManager.Instance.CountText(HensToBeBorn);
            hensToHaveText.color = new Color(0, 255, 0, 255);
        }    
        else if (HensToBeBorn <= 0)
        {
            int hensShow = hensEgging * eggsMult;
            hensToHaveText.text = GameManager.Instance.CountText(HensToBeBorn);
            hensToHaveText.color = new Color(255, 255, 255, 255);
        }
        else
        {
            hensToHaveText.text = "";
        }
    }

    public void ShowEggsField()
    {
        //GameManager.Instance.CapCheck(barnScr.eggs, barnScr.EggsCapAmount, EggsCurrentTxt, true);
        EggsCurrentTxt.text = GameManager.Instance.CountText(barnScr.eggs);
        //EggsCapTxt.text = GameManager.Instance.CountText(barnScr.EggsCapAmount);

        if(hensEgging > 0)
        {
            int eggsShow = hensEgging * eggsMult;
            eggsToHaveText.text = "+" + GameManager.Instance.CountText(eggsShow);
            eggsToHaveText.color = new Color(0, 255, 0, 255);
        }    
        else
        {
            int eggsShow = hensEgging * eggsMult;
            eggsToHaveText.text = GameManager.Instance.CountText(eggsShow);
            eggsToHaveText.color = new Color(255, 255, 255, 255);
        }
    }

    public void ShowTurnsBeforeHens()
    {
        if(HensToBeBorn > 0)
        {
            ShowTurns = TurnsNeeded - HensBarnTurn;
            TurnsUntilHens.text = "in " + ShowTurns.ToString() + " turns";
            if(!TurnShownInJournal)
            {
                TurnRecap.Instance.GetTextStrings("Hens turns left: "+ ShowTurns.ToString());
                TurnShownInJournal = true;
            }
                
        }
    }

    #endregion

    #region Hens Turn Logic

    public void HensTurnLogic()
    {
        LeftoversDisappear();
        HensBirthByTurn();
        TurnEarnEggs();
        
        TurnClearFunc();
    }

    public void TurnEarnEggs()
    {
        if(hensEgging > 0)
        {
            int eggsCount = hensEgging * eggsMult;
            barnScr.eggs += eggsCount;
        }
        
    }

    public void HensGivingEggs()
    {
        if(FedHens > 0)
        {
            if(hensHatching <= 0)
                hensEgging = barnScr.hens;
            else
                hensEgging = barnScr.hens - HensToBeBorn;
 
        }        
    }

    public void TurnClearFunc()
    {
        FedHens = 0;
        UnFeedHens = barnScr.hens;
        
        hensEgging = 0;

        TurnShownInJournal = false;
    }

    #endregion

    #region Leftoverf

    public void LeftoversCheck()
    {
        /*if(barnScr.eggs > barnScr.EggsCapAmount)
        {
            EggsLeftoversNumber = barnScr.eggs - barnScr.EggsCapAmount;
            SellEggsLeftovers.SetActive(true);
        }
        else
        {
            SellEggsLeftovers.SetActive(false);
        }*/

        if(barnScr.hens > barnScr.HensCapAmount)
        {
            HensLeftoversNumber = barnScr.hens - barnScr.HensCapAmount;
            SellHensLeftovers.SetActive(true);
            SellHensLeftoversInBarn.SetActive(true);
        }
        else
        {
            SellHensLeftovers.SetActive(false);
            SellHensLeftoversInBarn.SetActive(false);
        }
    }

    /*public void SellEggsLeftoversFunc()
    {
        sellLeftovers.LeftoversTransfer(EggsLeftoversNumber, 1);
        EggsLeftoversNumber = 0;
    }*/
    public void SellHensLeftoversFunc()
    {
        sellLeftovers.LeftoversTransfer(HensLeftoversNumber, 4);
        HensLeftoversNumber = 0;
    }

    public void LeftoversDisappear()
    {
        /*if(EggsLeftoversNumber > 0)
        {
            barnScr.eggs -= EggsLeftoversNumber;
            TurnRecap.Instance.GetTextStrings("Lost: " + EggsLeftoversNumber + " eggs!");
            EggsLeftoversNumber = 0;
        }*/

        if(HensLeftoversNumber > 0)
        {
            barnScr.hens -= HensLeftoversNumber;
            TurnRecap.Instance.GetTextStrings("Lost: " + HensLeftoversNumber + " hens!");
            HensLeftoversNumber = 0;
        }
    }

    #endregion

    #region Food Logic

    public void HensHungerLogic()
    {
        if(FedHens > 0)
        {
            UnFeedHens = barnScr.hens - FedHens;
        }
        else
        {
            UnFeedHens = barnScr.hens;
        }

        if(UnFeedHens > barnScr.HensCapAmount)
            UnFeedHens = barnScr.HensCapAmount;

        if(UnFeedHens < 0)
            UnFeedHens = 0;
    }

    public void CountFoodForHens()
    {
        FoodAmountForHens = UnFeedHens * FoodNeededForHens;
    }

    public void FeedTheHens()
    {
        WheetCostForAdd = FoodAmountForHens;
        if(farmScr.wheets >= FoodAmountForHens && FoodAmountForHens > 0)
        {
            FedHens = barnScr.hens;
            farmScr.wheets -= FoodAmountForHens;
            UnFeedHens = UnFeedHens - FedHens;
            if(UnFeedHens < 0)
                UnFeedHens = 0;

            CountFoodForHens();

        }
        else if(farmScr.wheets < FoodAmountForHens && FoodAmountForHens > 0)
        {
            //int canAffordFood = farmScr.wheets - FoodAmountForHens;
            int canFeedHens = farmScr.wheets / FoodNeededForHens;
            int neededAmountOfWheet = canFeedHens * FoodNeededForHens;

            FedHens += canFeedHens;
            
            farmScr.wheets -= neededAmountOfWheet;
            UnFeedHens = UnFeedHens - canFeedHens;
            if(UnFeedHens < 0)
                UnFeedHens = 0;
        }

    }

    /*public void CheckUnFeedHens()
    {
        if(barnScr.hens > FedHens)
        {
            UnFeedHens = barnScr.hens - FedHens;

            if(UnFeedHens > barnScr.HensCapAmount)
                UnFeedHens = barnScr.HensCapAmount;
            
            hensEgging = hensEgging - UnFeedHens;
            
            if(hensEgging < 0)
                hensEgging = 0;

        }
    }*/

    #endregion

    #region Hatch Logic 

    public void HensBirthByTurn()
    {
        if(HensHatchingTurn > 0)
        {
            HensBarnTurn++;

            if(HensBarnTurn >= 2)
            {
                barnScr.hens += HensToBeBorn;    
                TurnRecap.Instance.GetTextStrings(HensToBeBorn + " hens was born!");

                //HasNewsScr.BarnNewsObj.SetActive(true);

                WL.HensIsPlanted = false;

                //Disable

                TurnsUntilHens.text = "";
                HensBarnTurn = 0;
                HensToBeBorn = 0;
                FullBreed.SetActive(false);
                BreedButton.SetActive(true);
                AddCount = 0;
                ExtraHensNumber = 0;
                fullAmountOfNewBorns = 0;
                ExtraAlarm.SetActive(false);
                hensHatching = 0;

                
                
            }  
        }
    }

    public void PrimalHensToBorn()
    {
        if(FedHens > 0)
        {
            HalfOfFedHens = FedHens;
            if(HalfOfFedHens > barnScr.HensCapAmount)
                HalfOfFedHens = barnScr.HensCapAmount;

            PrimalAmount = HalfOfFedHens / 2;

            int RandomNumberOfHens = Random.Range(1, PrimalAmount);

            if(RandomNumberOfHens < 0)
                RandomNumberOfHens = 0;
            else if(RandomNumberOfHens >= HalfOfFedHens)
                RandomNumberOfHens = HalfOfFedHens;

            HensToBeBorn = RandomNumberOfHens;
            barnScr.eggs -= HensToBeBorn;
            BreedButton.SetActive(false);
            PrimalIsOn = true;
            HensHatchingTurn = 1;

            WheetCostForAddObject.SetActive(true);

            TurnsUntilHens.text = "in " + ShowTurns.ToString() + " turns";

            EventsScr.Instance.EventPopText("You breeded: " + HensToBeBorn + "!");
            TurnRecap.Instance.GetTextStrings("You have breeded hens!");
        }
    }

    public void CheckForAdd()
    {
        HalfOfFedHens = FedHens;
        if(HalfOfFedHens > barnScr.HensCapAmount)
            HalfOfFedHens = barnScr.HensCapAmount;

        if(HensToBeBorn >= HalfOfFedHens && HensToBeBorn > 0)
        {
            AddButton.SetActive(false);
            FullBreed.SetActive(true);
            WheetCostForAddObject.SetActive(false);
        }
        else if(HensToBeBorn < HalfOfFedHens && HensToBeBorn > 0)
        {
            AddButton.SetActive(true);
            FullBreed.SetActive(false);
        }

        if(AddCount > 3 && HensToBeBorn > 0)
        {
            AddButton.SetActive(false);
            FullBreed.SetActive(true);
            WheetCostForAddObject.SetActive(false);
        }

        if(HensToBeBorn > 0)
            fullAmountOfNewBorns = barnScr.hens + HensToBeBorn;

        if(fullAmountOfNewBorns > barnScr.HensCapAmount)
        {
            ExtraAlarm.SetActive(true);

            ExtraHensNumber = fullAmountOfNewBorns - barnScr.HensCapAmount;
            ExtraHensText.text = GameManager.Instance.CountText(ExtraHensNumber);
        }
        else
        {
            ExtraAlarm.SetActive(false);
        }
        
    }

    public void AddToHensBorn()
    {
        if(AddCount == 0)
        {
            if(HensToBeBorn < HalfOfFedHens && farmScr.wheets >= WheetCostForAdd)
            {
                int RandomNumber = Random.Range(1, PrimalAmount + 1);
                int CheckNumber = HensToBeBorn + RandomNumber;
                
                int AddNumber = RandomNumber;

                if(CheckNumber > HalfOfFedHens)
                    AddNumber = HalfOfFedHens - HensToBeBorn;

                if(barnScr.eggs < AddNumber)
                    AddNumber = barnScr.eggs;

                if(barnScr.eggs >= AddNumber)
                {
                    HensToBeBorn += AddNumber;
                    hensHatching = HensToBeBorn;

                    barnScr.eggs -= AddNumber;

                    farmScr.wheets -= WheetCostForAdd;
                    WheetCostForAdd = WheetCostForAdd * 2;
                    AddCount ++;
                    EventsScr.Instance.EventPopText(AddNumber + " is added to your breed!");
                    Debug.Log("AddCount: " + AddCount);
                } 
            }
            else
            {
                EventsScr.Instance.EventPopText("Not Enough Wheet!");
            } 
        }
        else if(AddCount == 1)
        {
            if(HensToBeBorn < HalfOfFedHens && farmScr.wheets >= WheetCostForAdd)
            {
                int RandomNumber = Random.Range(1, PrimalAmount + 1);
                int CheckNumber = HensToBeBorn + RandomNumber;
                int AddNumber = RandomNumber;

                if(CheckNumber > HalfOfFedHens)
                    AddNumber = HalfOfFedHens - HensToBeBorn;

                if(barnScr.eggs < AddNumber)
                    AddNumber = barnScr.eggs;

                if(barnScr.eggs >= AddNumber)
                {
                    HensToBeBorn += AddNumber;
                    hensHatching = HensToBeBorn;

                    barnScr.eggs -= AddNumber;

                    farmScr.wheets -= WheetCostForAdd;
                    WheetCostForAdd = WheetCostForAdd * 2;
                    AddCount ++;
                    EventsScr.Instance.EventPopText(AddNumber + " is added to your breed!");
                    Debug.Log("AddCount: " + AddCount);
                } 
            }
            else
            {
                EventsScr.Instance.EventPopText("Not Enough Wheet!");
            }   
        }
        else if(AddCount == 2)
        {
            if(HensToBeBorn < HalfOfFedHens && farmScr.wheets >= WheetCostForAdd)
            {
                int RandomNumber = Random.Range(1, PrimalAmount + 1);
                int CheckNumber = HensToBeBorn + RandomNumber;
                int AddNumber = RandomNumber;

                if(CheckNumber > HalfOfFedHens)
                    AddNumber = HalfOfFedHens - HensToBeBorn;

                if(barnScr.eggs < AddNumber)
                    AddNumber = barnScr.eggs;

                if(barnScr.eggs >= AddNumber)
                {
                    HensToBeBorn += AddNumber;
                    hensHatching = HensToBeBorn;

                    barnScr.eggs -= AddNumber;

                    farmScr.wheets -= WheetCostForAdd;
                    WheetCostForAdd = WheetCostForAdd * 2;
                    AddCount ++;
                    EventsScr.Instance.EventPopText(AddNumber + " is added to your breed!");
                    Debug.Log("AddCount: " + AddCount);
                } 
            }
            else
            {
                EventsScr.Instance.EventPopText("Not Enough Wheet!");
            }     
        }
        else if(AddCount == 3)
        {
            if(HensToBeBorn < HalfOfFedHens && farmScr.wheets >= WheetCostForAdd)
            {
                int LastCheck = HalfOfFedHens - HensToBeBorn;

                if(barnScr.eggs < LastCheck)
                    LastCheck = barnScr.eggs;
                
                if(barnScr.eggs > LastCheck)
                {
                    
                    barnScr.eggs -= LastCheck;
                    HensToBeBorn = HalfOfFedHens;
                    hensHatching = HensToBeBorn;

                    FullBreed.SetActive(true);

                    farmScr.wheets -= WheetCostForAdd;
                    AddCount ++;
                    EventsScr.Instance.EventPopText("You will breed: " + HensToBeBorn);
                    Debug.Log("AddCount: " + AddCount);
                }
                
            }
            else
            {
                EventsScr.Instance.EventPopText("Not Enough Wheet!");
            }     
        }  
  
    }

    #endregion

}
