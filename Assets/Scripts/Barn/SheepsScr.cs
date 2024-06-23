using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepsScr : MonoBehaviour
{
    #region Inspector Variables

    [Header("Scripts Objects:")]
    public BarnScr barnScr;
    public FarmScr farmScr;
    public SellLeftovers sellLeftovers;

    public WorkerLivestock WL;

    //public HasNewsScr newsScr;

    [Header("Food For Sheeps:")]
    [HideInInspector] public int FoodAmountForSheeps;
    public int FoodNeededForSheeps;
    public TextMeshProUGUI FoodForSheepsText;

    public int FedSheeps; // how many Sheeps are fed

    public int UnFeedSheeps;
    public TextMeshProUGUI HungrySheepsTxt;

    public GameObject HungrySheepsAlert;
    public GameObject FedSheepsAlert;

    [Header("Birth Mechanics")]

    public int HalfOfFedSheeps;
    public int HalfOfSheeps;
    public int AddCount;

    public GameObject BreedButton;
    public GameObject AddButton;
    public GameObject FullBreed;
    public bool PrimalIsOn = false;
    public int PrimalAmount;

    public int WheetCostForAdd = 0;

    public GameObject WheetCostForAddObject;
    public TextMeshProUGUI WheetCostForAddText;
    public TextMeshProUGUI MaxSheepsAmountToBeBornText;

    [Header("Extra Birth")]
    public GameObject ExtraAlarm;
    public TextMeshProUGUI ExtraSheepsText;
    public int ExtraSheepsNumber;

    [Header("Leftovers")]

    //public int WoolLeftoversNumber;
    public int SheepsLeftoversNumber;

    //public GameObject SellWoolLeftovers;
    public GameObject SellSheepsLeftovers;
    public GameObject SellSheepsLeftoversInBarn;

    [Header("Wool to Have:")]

    [HideInInspector] public int WoolToHave;
    public TextMeshProUGUI WoolToHaveText;

    public TextMeshProUGUI SheepsToHaveText;
    public int woolMult;

    [Header("Sheeps/Wool Field Texts:")]

    public TextMeshProUGUI SheepsCurrentTxt;
    public TextMeshProUGUI SheepsCapTxt;

    public TextMeshProUGUI WoolCurrentTxt;
    public TextMeshProUGUI WoolCapTxt;

    [Header("Top Info Texts:")]

    public TextMeshProUGUI SheepsHaveTxt;
    public TextMeshProUGUI WoolHaveTxt;
    public TextMeshProUGUI WheetsHaveTxt;

    [HideInInspector] public int SheepsWooling;
    //[HideInInspector] public int SheepsMissing;

    [Header("Sheeps to be Born:")]

    [HideInInspector] public int SheepsToBeBorn;
    public TextMeshProUGUI SheepsToBeBornText;
    public int PlusRandomToSheepBorn;

    public bool SheepsBreedingTurned;
    public int SheepsBarnTurn;

    public bool SheepsAreActive;

    #endregion

    #region Start and Update

    private void Update()
    {
        if(SheepsAreActive)
        {
            SheepsHungerLogic();
        
            CountFoodForSheeps();
            HungrySheepsAlarm();

            SheepsToHaveField();
            WoolToHaveField();
            WoolToHaveByTurn();
            ShowTopInfo();
            LeftoversCheck();

            if(PrimalIsOn)
                CheckForAdd();

            SheepsToHaveText.text = GameManager.Instance.CountText(SheepsToBeBorn);

            SheepsToBeBornText.text = GameManager.Instance.CountText(SheepsToBeBorn);
            MaxSheepsAmountToBeBornText.text = GameManager.Instance.CountText(HalfOfFedSheeps);

            HungrySheepsTxt.text = GameManager.Instance.CountText(UnFeedSheeps);
            FoodForSheepsText.text = GameManager.Instance.CountText(FoodAmountForSheeps);

            WheetCostForAddText.text = GameManager.Instance.CountText(WheetCostForAdd);

        }
        
    }

    public void ShowTopInfo()
    {
        SheepsHaveTxt.text = GameManager.Instance.CountText(barnScr.sheeps);
        WoolHaveTxt.text = GameManager.Instance.CountText(barnScr.wool);
        WheetsHaveTxt.text = GameManager.Instance.CountText(farmScr.wheets);

        GameManager.Instance.CapCheck(barnScr.sheeps, barnScr.SheepsCapAmount, SheepsHaveTxt, false);
        //GameManager.Instance.CapCheck(barnScr.wool, barnScr.WoolCapAmount, WoolHaveTxt, true);
    }  

    #endregion

    #region Leftovers

    public void LeftoversCheck()
    {
        /*if(barnScr.wool > barnScr.WoolCapAmount)
        {
            WoolLeftoversNumber = barnScr.wool - barnScr.WoolCapAmount;
            SellWoolLeftovers.SetActive(true);
        }
        else
        {
            SellWoolLeftovers.SetActive(false);
        }*/

        if(barnScr.sheeps > barnScr.SheepsCapAmount)
        {
            SheepsLeftoversNumber = barnScr.sheeps - barnScr.SheepsCapAmount;
            SellSheepsLeftovers.SetActive(true);
            SellSheepsLeftoversInBarn.SetActive(true);
        }
        else
        {
            SellSheepsLeftovers.SetActive(false);
            SellSheepsLeftoversInBarn.SetActive(false);
        }
    }

    /*public void SellWoolLeftoversFunc()
    {
        sellLeftovers.LeftoversTransfer(WoolLeftoversNumber, 2);
        WoolLeftoversNumber = 0;
    }*/
    public void SellSheepsLeftoversFunc()
    {
        sellLeftovers.LeftoversTransfer(SheepsLeftoversNumber, 5);
        SheepsLeftoversNumber = 0;
    }

    public void LeftoversDisappear()
    {
        /*if(WoolLeftoversNumber > 0)
        {
            barnScr.wool -= WoolLeftoversNumber;
            TurnRecap.Instance.GetTextStrings("Lost: " + WoolLeftoversNumber + " wool!");
            WoolLeftoversNumber = 0;
            
        }*/

        if(SheepsLeftoversNumber > 0)
        {
            barnScr.sheeps -= SheepsLeftoversNumber;
            TurnRecap.Instance.GetTextStrings("Lost: " + SheepsLeftoversNumber + " sheeps!");
            SheepsLeftoversNumber = 0;
        }
    }

    #endregion

    #region Turn Logic

    public void SheepsTurnLogic()
    {
        LeftoversDisappear();
        SheepsBirthByTurn();
        TurnEarnWool();

        ClearByTurn();
    }

    public void WoolToHaveByTurn()
    {
        SheepsWooling = FedSheeps;
        WoolToHave = SheepsWooling;        
    }

    public void TurnEarnWool()
    {
        if(SheepsWooling > 0)
        {
            int woolCount = SheepsWooling * woolMult;
            barnScr.wool += woolCount;
        }
    }

    public void ClearByTurn()
    {

        FedSheeps = 0;
        UnFeedSheeps = barnScr.sheeps;

        WoolToHave = 0;
        SheepsWooling = 0;
        
    }

    #endregion

    #region Sheeps Birth

    public void SheepsBirthByTurn()
    {
        if(SheepsBreedingTurned)
        {
            SheepsBarnTurn ++;

            if(SheepsBarnTurn >= 3)
            {
                barnScr.sheeps += SheepsToBeBorn;
                TurnRecap.Instance.GetTextStrings(SheepsToBeBorn + " sheeps was born!");

                //HasNewsScr.BarnNewsObj.SetActive(true);

                WL.SheepsIsPlanted = false;
                Debug.Log("SheepsPlanted: " + WL.SheepsIsPlanted);
                SheepsToBeBorn = 0;
                

                BreedButton.SetActive(true);
                PrimalIsOn = false;
        
                AddButton.SetActive(false);
                FullBreed.SetActive(false);
                WheetCostForAddObject.SetActive(false);
                AddCount = 0;
                HalfOfFedSheeps = 0;
                PrimalAmount = 0;
                WheetCostForAdd = 0;
                ExtraSheepsNumber = 0;
                ExtraAlarm.SetActive(false);
                SheepsBreedingTurned = false;

                

            }
        }
        
    }

    public void PrimalSheepsToBorn()
    {
        if(FedSheeps > 0)
        {
            HalfOfFedSheeps = FedSheeps / 2;
            PrimalAmount = HalfOfFedSheeps / 2;

            int RandomNumberOfSheeps = Random.Range(1, PrimalAmount);

            if(RandomNumberOfSheeps < 0)
                RandomNumberOfSheeps = 0;
            else if(RandomNumberOfSheeps >= HalfOfFedSheeps)
                RandomNumberOfSheeps = HalfOfFedSheeps;

            SheepsToBeBorn = RandomNumberOfSheeps;
            BreedButton.SetActive(false);
            PrimalIsOn = true;
            SheepsBreedingTurned = true;

            WheetCostForAddObject.SetActive(true);
            EventsScr.Instance.EventPopText("You have breed " + SheepsToBeBorn + " sheeps! They will be born in 2 turns!");
        }
    }

    public void CheckForAdd()
    {
        HalfOfFedSheeps = FedSheeps / 2;

        if(SheepsToBeBorn >= HalfOfFedSheeps && SheepsToBeBorn > 0)
        {
            AddButton.SetActive(false);
            FullBreed.SetActive(true);
            WheetCostForAddObject.SetActive(false);
        }
        else if(SheepsToBeBorn < HalfOfFedSheeps && SheepsToBeBorn > 0)
        {
            AddButton.SetActive(true);
            FullBreed.SetActive(false);
        }

        if(AddCount > 3 && SheepsToBeBorn > 0)
        {
            AddButton.SetActive(false);
            FullBreed.SetActive(true);
            WheetCostForAddObject.SetActive(false);
        }

        int fullAmountOfNewBorns = barnScr.sheeps + SheepsToBeBorn;

        if(fullAmountOfNewBorns > barnScr.SheepsCapAmount)
        {
            ExtraAlarm.SetActive(true);

            ExtraSheepsNumber = fullAmountOfNewBorns - barnScr.SheepsCapAmount;
            ExtraSheepsText.text = GameManager.Instance.CountText(ExtraSheepsNumber);
        }
        else
        {
            ExtraAlarm.SetActive(false);
        }
        
    }

    public void AddToSheepBorn()
    {
        if(AddCount == 0)
        {
            if(SheepsToBeBorn < HalfOfFedSheeps && farmScr.wheets >= WheetCostForAdd)
            {
                int RandomNumber = Random.Range(1, PrimalAmount + 1);
                int AddNumber = SheepsToBeBorn + RandomNumber;

                if(AddNumber > HalfOfFedSheeps)
                    SheepsToBeBorn = HalfOfFedSheeps;
                else
                    SheepsToBeBorn = AddNumber;

                EventsScr.Instance.EventPopText("You increased chance with " + RandomNumber + " sheeps! (total "+SheepsToBeBorn+") For " + WheetCostForAdd + " wheet!");

                farmScr.wheets -= WheetCostForAdd;
                WheetCostForAdd = WheetCostForAdd * 2;
                AddCount ++;
                
            }
        }
        else if(AddCount == 1)
        {
            if(SheepsToBeBorn < HalfOfFedSheeps && farmScr.wheets >= WheetCostForAdd)
            {
                int RandomNumber = Random.Range(1, PrimalAmount + 1);
                int AddNumber = SheepsToBeBorn + RandomNumber;

                if(AddNumber > HalfOfFedSheeps)
                    SheepsToBeBorn = HalfOfFedSheeps;
                else
                    SheepsToBeBorn = AddNumber;

                EventsScr.Instance.EventPopText("You increased chance with " + RandomNumber + " sheeps! (total "+SheepsToBeBorn+") For " + WheetCostForAdd + " wheet!");

                farmScr.wheets -= WheetCostForAdd;
                WheetCostForAdd = WheetCostForAdd * 2;
                AddCount ++;
            }    
        }
        else if(AddCount == 2)
        {
            if(SheepsToBeBorn < HalfOfFedSheeps && farmScr.wheets >= WheetCostForAdd)
            {
                int RandomNumber = Random.Range(1, PrimalAmount + 1);
                int AddNumber = SheepsToBeBorn + RandomNumber;

                if(AddNumber > HalfOfFedSheeps)
                    SheepsToBeBorn = HalfOfFedSheeps;
                else
                    SheepsToBeBorn = AddNumber;

                EventsScr.Instance.EventPopText("You increased chance with " + RandomNumber + " sheeps! (total "+SheepsToBeBorn+") For " + WheetCostForAdd + " wheet!");

                farmScr.wheets -= WheetCostForAdd;
                WheetCostForAdd = WheetCostForAdd * 2;
                AddCount ++;
            }    
        }
        else if(AddCount == 3)
        {
            if(SheepsToBeBorn < HalfOfFedSheeps && farmScr.wheets >= WheetCostForAdd)
            {
                SheepsToBeBorn = HalfOfFedSheeps;
                FullBreed.SetActive(true);

                farmScr.wheets -= WheetCostForAdd;
                EventsScr.Instance.EventPopText("You have breed " + SheepsToBeBorn + " sheeps! They will be born in 2 turns!");
                AddCount ++;
            }    
        }        

        
    }

    #endregion

    #region Sheeps Feed

    

    public void CountFoodForSheeps()
    {
        FoodAmountForSheeps = UnFeedSheeps * FoodNeededForSheeps;
    }

    public void HungrySheepsAlarm()
    {
        if(UnFeedSheeps > 0)
        {
            HungrySheepsAlert.SetActive(true);
            FedSheepsAlert.SetActive(false);
        }
        else if(UnFeedSheeps == 0 && barnScr.sheeps > 0)
        {
            FedSheepsAlert.SetActive(true);
            HungrySheepsAlert.SetActive(false);
        }
    }

    public void FeedTheSheeps()
    {

        WheetCostForAdd = FoodAmountForSheeps;

        if(farmScr.wheets >= FoodAmountForSheeps && FoodAmountForSheeps > 0)
        {
            FedSheeps = barnScr.sheeps;
            farmScr.wheets -= FoodAmountForSheeps;
            UnFeedSheeps = UnFeedSheeps - FedSheeps;
            if(UnFeedSheeps < 0)
                UnFeedSheeps = 0;

            EventsScr.Instance.EventPopText("You have fed " + FedSheeps + " sheeps, with " + FoodAmountForSheeps + " wheets!");

            CountFoodForSheeps();

        }
        else if(farmScr.wheets < FoodAmountForSheeps && FoodAmountForSheeps > 0)
        {
            //int canAffordFood = farmScr.wheets - FoodAmountForSheeps;
            int canFeedSheeps = farmScr.wheets / FoodNeededForSheeps;
            int neededAmountOfWheet = canFeedSheeps * FoodNeededForSheeps;

            FedSheeps += canFeedSheeps;
            
            farmScr.wheets -= neededAmountOfWheet;
            UnFeedSheeps = UnFeedSheeps - canFeedSheeps;
            if(UnFeedSheeps < 0)
                UnFeedSheeps = 0;

            EventsScr.Instance.EventPopText("You have fed " + FedSheeps + " sheeps, with " + FoodAmountForSheeps + " wheets!");
        }

    }

    public void SheepsHungerLogic()
    {
        if(FedSheeps > 0 && UnFeedSheeps < barnScr.SheepsCapAmount)
        {
            UnFeedSheeps = barnScr.sheeps - FedSheeps;
        }
        else
        {
            UnFeedSheeps = barnScr.sheeps;
        }

        if(UnFeedSheeps > barnScr.SheepsCapAmount)
            UnFeedSheeps = barnScr.SheepsCapAmount;

        if(UnFeedSheeps < 0)
            UnFeedSheeps = 0;
    }

    #endregion

    

    #region Sheeps/Wool Fields

    public void SheepsToHaveField()
    {
        SheepsCurrentTxt.text = GameManager.Instance.CountText(barnScr.sheeps);
        SheepsCapTxt.text = GameManager.Instance.CountText(barnScr.SheepsCapAmount);

        if(SheepsToBeBorn > 0)
        {
            SheepsToHaveText.text = "+" + GameManager.Instance.CountText(SheepsToBeBorn);
            SheepsToHaveText.color = new Color(0, 255, 0, 255);
        }    
        else
        {
            SheepsToHaveText.text = GameManager.Instance.CountText(SheepsToBeBorn);
            SheepsToHaveText.color = new Color(0, 0, 0, 255);
        }
    }

    public void WoolToHaveField()
    {
        WoolCurrentTxt.text = GameManager.Instance.CountText(barnScr.wool);
        //WoolCapTxt.text = GameManager.Instance.CountText(barnScr.WoolCapAmount);

        if(WoolToHave > 0)
        {
            int WoolToShow = WoolToHave * woolMult;
            WoolToHaveText.text = "+" + GameManager.Instance.CountText(WoolToShow);
            WoolToHaveText.color = new Color(0, 255, 0, 255);
        }    
        else
        {
            int WoolToShow = WoolToHave * woolMult;
            WoolToHaveText.text = GameManager.Instance.CountText(WoolToShow);
            WoolToHaveText.color = new Color(0, 0, 0, 255);
        }
    }

    #endregion

}
