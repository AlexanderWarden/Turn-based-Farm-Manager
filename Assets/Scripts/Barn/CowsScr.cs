using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CowsScr : MonoBehaviour
{
    #region Inspector Variables

    [Header("Scripts Objects:")]
    public BarnScr barnScr;
    public FarmScr farmScr;
    public SellLeftovers sellLeftovers;

    public WorkerLivestock WL;

    //public HasNewsScr newsScr;

    [Header("Food For Cows:")]
    [HideInInspector] public int FoodAmountForCows;
    public int FoodNeededForCows;
    public TextMeshProUGUI FoodForCowsText;

    public int FedCows; // how many Cows are fed

    public int UnFeedCows;
    public TextMeshProUGUI HungryCowsTxt;

    public GameObject HungryCowsAlert;
    public GameObject FedCowsAlert;

    [Header("Birth Mechanics")]

    public int HalfOfFedCows;
    public int HalfOfCows;
    public int AddCount;

    public GameObject BreedButton;
    public GameObject AddButton;
    public GameObject FullBreed;
    public bool PrimalIsOn = false;
    public int PrimalAmount;

    public int WheetCostForAdd = 0;

    public GameObject WheetCostForAddObject;
    public TextMeshProUGUI WheetCostForAddText;
    public TextMeshProUGUI MaxCowsAmountToBeBornText;

    public GameObject BreedHideObj;

    [Header("Extra")]
    public GameObject ExtraAlarm;
    public TextMeshProUGUI ExtraCowsText;
    public int ExtraCowsNumber;

    [Header("Leftovers")]

    //public int MilkLeftoversNumber;
    public int CowsLeftoversNumber;

    //public GameObject SellMilkLeftovers;
    public GameObject SellCowsLeftovers;
    public GameObject SellCowsLeftoversInBarn;

    [Header("Milk to Have:")]

    [HideInInspector] public int MilkToHave;
    public TextMeshProUGUI MilkToHaveText;

    public TextMeshProUGUI CowsToHaveText;
    public int milkMult;

    [Header("Cows/Milk Field Texts:")]

    public TextMeshProUGUI CowsCurrentTxt;
    public TextMeshProUGUI CowsCapTxt;

    public TextMeshProUGUI MilkCurrentTxt;
    public TextMeshProUGUI MilkCapTxt;

    [Header("Top Info Texts:")]

    public TextMeshProUGUI CowsHaveTxt;
    public TextMeshProUGUI MilkHaveTxt;
    public TextMeshProUGUI WheetsHaveTxt;

    [HideInInspector] public int CowsMilking;
    //[HideInInspector] public int CowsMissing;

    [Header("Cows to be Born:")]

    [HideInInspector] public int CowsToBeBorn;
    public TextMeshProUGUI CowsToBeBornText;
    public int PlusRandomToCowBorn;

    public int MilkBoost;

    public bool CowsBreedingTurned;
    public int CowsBarnTurn;

    public bool CowsAreActive;

    #endregion

    #region Start and Update

    private void Update()
    {
        if(CowsAreActive)
        {
            CowsHungerLogic();
        
            CountFoodForCows();
            HungryCowsAlarm();

            CowsToHaveField();
            MilkToHaveField();
            MilkToHaveByTurn();
            ShowTopInfo();
            LeftoversCheck();

            if(PrimalIsOn)
                CheckForAdd();

            CowsToHaveText.text = GameManager.Instance.CountText(CowsToBeBorn);

            CowsToBeBornText.text = GameManager.Instance.CountText(CowsToBeBorn);
            MaxCowsAmountToBeBornText.text = GameManager.Instance.CountText(HalfOfFedCows);

            HungryCowsTxt.text = GameManager.Instance.CountText(UnFeedCows);
            FoodForCowsText.text = GameManager.Instance.CountText(FoodAmountForCows);

            WheetCostForAddText.text = GameManager.Instance.CountText(WheetCostForAdd);

        }
    }

    public void ShowTopInfo()
    {
        CowsHaveTxt.text = GameManager.Instance.CountText(barnScr.cows);
        MilkHaveTxt.text = GameManager.Instance.CountText(barnScr.milk);
        WheetsHaveTxt.text = GameManager.Instance.CountText(farmScr.wheets);

        GameManager.Instance.CapCheck(barnScr.cows, barnScr.CowsCapAmount, CowsHaveTxt, false);
        //GameManager.Instance.CapCheck(barnScr.milk, barnScr.MilkCapAmount, MilkHaveTxt, true);
    }  

    #endregion

    #region Leftovers

    public void LeftoversCheck()
    {
        /*if(barnScr.milk > barnScr.MilkCapAmount)
        {
            MilkLeftoversNumber = barnScr.milk - barnScr.MilkCapAmount;
            SellMilkLeftovers.SetActive(true);
        }
        else
        {
            SellMilkLeftovers.SetActive(false);
        }*/

        if(barnScr.cows > barnScr.CowsCapAmount)
        {
            CowsLeftoversNumber = barnScr.cows - barnScr.CowsCapAmount;
            SellCowsLeftovers.SetActive(true);
            SellCowsLeftoversInBarn.SetActive(true);
        }
        else
        {
            SellCowsLeftovers.SetActive(false);
            SellCowsLeftoversInBarn.SetActive(false);
        }
    }

    /*public void SellMilkLeftoversFunc()
    {
        sellLeftovers.LeftoversTransfer(MilkLeftoversNumber, 3);
        MilkLeftoversNumber = 0;
    }*/
    public void SellCowsLeftoversFunc()
    {
        sellLeftovers.LeftoversTransfer(CowsLeftoversNumber, 6);
        CowsLeftoversNumber = 0;
    }

    public void LeftoversDisappear()
    {
        /*if(MilkLeftoversNumber > 0)
        {
            barnScr.milk -= MilkLeftoversNumber;
            TurnRecap.Instance.GetTextStrings("Lost: " + MilkLeftoversNumber + " milk!");
            MilkLeftoversNumber = 0;
        }*/

        if(CowsLeftoversNumber > 0)
        {
            barnScr.cows -= CowsLeftoversNumber;
            TurnRecap.Instance.GetTextStrings("Lost: " + CowsLeftoversNumber + " cows!");
            CowsLeftoversNumber = 0;
        }
    }

    #endregion

    #region Turn Logic

    public void CowsTurnLogic()
    {
        LeftoversDisappear();
        CowsBirthByTurn();
        TurnEarnMilk();
        ClearByTurn();
        
    }

    public void MilkToHaveByTurn()
    {
        CowsMilking = FedCows;
        MilkToHave = CowsMilking;        
    }

    public void TurnEarnMilk()
    {
        if(CowsMilking > 0)
        {
            int milkCount = CowsMilking * milkMult;
            barnScr.milk += milkCount;
        }
    }

    public void ClearByTurn()
    {
        UnFeedCows = barnScr.cows;
        FedCows = 0;

        MilkToHave = 0;
        CowsMilking = 0;
        
    }

    #endregion

    #region Cows Feed

    public void CowsHungerLogic()
    {
        if(FedCows > 0 && UnFeedCows < barnScr.CowsCapAmount)
        {
            UnFeedCows = barnScr.cows - FedCows;
        }
        else
        {
            UnFeedCows = barnScr.cows;
        }

        if(UnFeedCows > barnScr.CowsCapAmount)
            UnFeedCows = barnScr.CowsCapAmount;

        if(UnFeedCows < 0)
            UnFeedCows = 0;
    }

    public void CountFoodForCows()
    {
        FoodAmountForCows = UnFeedCows * FoodNeededForCows;
    }

    public void HungryCowsAlarm()
    {
        if(UnFeedCows > 0)
        {
            HungryCowsAlert.SetActive(true);
            FedCowsAlert.SetActive(false);
        }
        else if(UnFeedCows == 0 && barnScr.cows > 0)
        {
            FedCowsAlert.SetActive(true);
            HungryCowsAlert.SetActive(false);
        }
    }

    public void FeedTheCows()
    {

        WheetCostForAdd = FoodAmountForCows;

        if(farmScr.wheets >= FoodAmountForCows && FoodAmountForCows > 0)
        {
            FedCows = barnScr.cows;
            farmScr.wheets -= FoodAmountForCows;
            UnFeedCows = UnFeedCows - FedCows;
            if(UnFeedCows < 0)
                UnFeedCows = 0;

            CountFoodForCows();

        }
        else if(farmScr.wheets < FoodAmountForCows && FoodAmountForCows > 0)
        {
            //int canAffordFood = farmScr.wheets - FoodAmountForCows;
            int canFeedCows = farmScr.wheets / FoodNeededForCows;
            int neededAmountOfWheet = canFeedCows * FoodNeededForCows;

            FedCows += canFeedCows;
            
            farmScr.wheets -= neededAmountOfWheet;
            UnFeedCows = UnFeedCows - canFeedCows;
            if(UnFeedCows < 0)
                UnFeedCows = 0;
        }

    }

    /*public void CheckUnFeedCows()
    {
        if(barnScr.cows > FedCows)
        {
            UnFeedCows = barnScr.cows - FedCows;
            CowsMilking = CowsMilking - UnFeedCows;
            
            if(CowsMilking < 0)
                CowsMilking = 0;

        }
    }*/

    #endregion

    #region Cows Birth

    public void CowsBirthByTurn()
    {
        if(CowsBreedingTurned)
        {
            CowsBarnTurn++;

            if(CowsBarnTurn >= 4)
            {
                barnScr.cows += CowsToBeBorn;
                TurnRecap.Instance.GetTextStrings(CowsToBeBorn + " cows was born!");

                //HasNewsScr.BarnNewsObj.SetActive(true);

                WL.CowsIsPlanted = false;
                CowsToBeBorn = 0;

                BreedButton.SetActive(true);
                PrimalIsOn = false;
        
                AddButton.SetActive(false);
                FullBreed.SetActive(false);
                WheetCostForAddObject.SetActive(false);
                AddCount = 0;
                HalfOfFedCows = 0;
                PrimalAmount = 0;
                WheetCostForAdd = 0;
                ExtraCowsNumber = 0;

                ExtraAlarm.SetActive(false);
                CowsBreedingTurned = false;

                

            }
            
        }
    }

    public void PrimalCowsToBorn()
    {
        if(FedCows > 0)
        {
            HalfOfFedCows = FedCows / 2;
            PrimalAmount = HalfOfFedCows / 2;

            int RandomNumberOfCows = Random.Range(1, PrimalAmount);

            if(RandomNumberOfCows < 0)
                RandomNumberOfCows = 0;
            else if(RandomNumberOfCows >= HalfOfFedCows)
                RandomNumberOfCows = HalfOfFedCows;

            CowsToBeBorn = RandomNumberOfCows;
            BreedButton.SetActive(false);
            PrimalIsOn = true;
            BreedHideObj.SetActive(true);
            CowsBreedingTurned = true;

            WheetCostForAddObject.SetActive(true);
        }
    }

    public void CheckForAdd()
    {
        HalfOfFedCows = FedCows / 2;

        if(CowsToBeBorn >= HalfOfFedCows)
        {
            AddButton.SetActive(false);
            FullBreed.SetActive(true);
            WheetCostForAddObject.SetActive(false);
        }
        else if(CowsToBeBorn < HalfOfFedCows)
        {
            AddButton.SetActive(true);
            FullBreed.SetActive(false);
        }

        if(AddCount > 3)
        {
            AddButton.SetActive(false);
            FullBreed.SetActive(true);
            WheetCostForAddObject.SetActive(false);
        }

        int fullAmountOfNewBorns = barnScr.cows + CowsToBeBorn;

        if(fullAmountOfNewBorns > barnScr.CowsCapAmount)
        {
            ExtraAlarm.SetActive(true);

            ExtraCowsNumber = fullAmountOfNewBorns - barnScr.CowsCapAmount;
            ExtraCowsText.text = GameManager.Instance.CountText(ExtraCowsNumber);
        }
        else
        {
            ExtraAlarm.SetActive(false);
        }
        
    }

    public void AddToCowsBorn()
    {
        if(AddCount == 0)
        {
            if(CowsToBeBorn < HalfOfFedCows && farmScr.wheets >= WheetCostForAdd)
            {
                int RandomNumber = Random.Range(1, PrimalAmount + 1);
                int AddNumber = CowsToBeBorn + RandomNumber;

                if(AddNumber > HalfOfFedCows)
                    CowsToBeBorn = HalfOfFedCows;
                else
                    CowsToBeBorn = AddNumber;

                farmScr.wheets -= WheetCostForAdd;
                WheetCostForAdd = WheetCostForAdd * 2;
                AddCount ++;
            }
        }
        else if(AddCount == 1)
        {
            if(CowsToBeBorn < HalfOfFedCows && farmScr.wheets >= WheetCostForAdd)
            {
                int RandomNumber = Random.Range(1, PrimalAmount + 1);
                int AddNumber = CowsToBeBorn + RandomNumber;

                if(AddNumber > HalfOfFedCows)
                    CowsToBeBorn = HalfOfFedCows;
                else
                    CowsToBeBorn = AddNumber;

                farmScr.wheets -= WheetCostForAdd;
                WheetCostForAdd = WheetCostForAdd * 2;
                AddCount ++;
            }    
        }
        else if(AddCount == 2)
        {
            if(CowsToBeBorn < HalfOfFedCows && farmScr.wheets >= WheetCostForAdd)
            {
                int RandomNumber = Random.Range(1, PrimalAmount + 1);
                int AddNumber = CowsToBeBorn + RandomNumber;

                if(AddNumber > HalfOfFedCows)
                    CowsToBeBorn = HalfOfFedCows;
                else
                    CowsToBeBorn = AddNumber;

                farmScr.wheets -= WheetCostForAdd;
                WheetCostForAdd = WheetCostForAdd * 2;
                AddCount ++;
            }    
        }
        else if(AddCount == 3)
        {
            if(CowsToBeBorn < HalfOfFedCows && farmScr.wheets >= WheetCostForAdd)
            {
                CowsToBeBorn = HalfOfFedCows;
                FullBreed.SetActive(true);

                farmScr.wheets -= WheetCostForAdd;
                AddCount ++;
            }    
        }        

        
    }

    #endregion

    #region Cow/Milk Fields

    public void CowsToHaveField()
    {
        CowsCurrentTxt.text = GameManager.Instance.CountText(barnScr.cows);
        CowsCapTxt.text = GameManager.Instance.CountText(barnScr.CowsCapAmount);

        if(CowsToBeBorn > 0)
        {
            CowsToHaveText.text = "+" + GameManager.Instance.CountText(CowsToBeBorn);
            CowsToHaveText.color = new Color(0, 255, 0, 255);
        }    
        else
        {
            CowsToHaveText.text = GameManager.Instance.CountText(CowsToBeBorn);
            CowsToHaveText.color = new Color(0, 0, 0, 255);
        }
    }

    public void MilkToHaveField()
    {
        MilkCurrentTxt.text = GameManager.Instance.CountText(barnScr.milk);
        //MilkCapTxt.text = GameManager.Instance.CountText(barnScr.MilkCapAmount);

        if(MilkToHave > 0)
        {
            int milkToShow = MilkToHave * milkMult;
            MilkToHaveText.text = "+" + GameManager.Instance.CountText(milkToShow);
            MilkToHaveText.color = new Color(0, 255, 0, 255);
        }    
        else
        {
            int milkToShow = MilkToHave * milkMult;
            MilkToHaveText.text = GameManager.Instance.CountText(milkToShow);
            MilkToHaveText.color = new Color(0, 0, 0, 255);
        }
    }

    #endregion
}
