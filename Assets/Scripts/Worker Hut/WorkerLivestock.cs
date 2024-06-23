using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkerLivestock : MonoBehaviour
{
    #region Variables 

    public BarnScr barnScr;
    public FarmScr farmScr;
    public HensScr hensScr;
    public SheepsScr sheepsScr;
    public CowsScr cowsScr;

    public bool isLivestockActive = true;
    public bool isLivestockOpen = false;

    public bool HensIsPlanted = false;
    public bool SheepsIsPlanted = false;
    public bool CowsIsPlanted = false;

    private bool HensFeedChoosen = false;
    private bool SheepsFeedChoosen = false;
    private bool CowsFeedChoosen = false;

    private bool HensBreedChoosen = false;
    private bool SheepsBreedChoosen = false;
    private bool CowsBreedChoosen = false;

    private bool IsPlanted = false;

    public Image HensFeedImageSelected;
    public Image SheepsFeedImageSelected;
    public Image CowsFeedImageSelected;

    public Image HensBreedImageSelected;
    public Image SheepsBreedImageSelected;
    public Image CowsBreedImageSelected;

    public int fullFeedCost;
    public int fullBreedCost;

    private int hensFeedCost;
    private int sheepsFeedCost;
    private int cowsFeedCost;

    private int hensBreedCost;
    private int sheepsBreedCost;
    private int cowsBreedCost;

    public TextMeshProUGUI fullFeedCostText;
    public TextMeshProUGUI fullBreedCostText;

    public TextMeshProUGUI haveWheetText;
    public TextMeshProUGUI haveMoneyText;

    public int SpendMoney;
    public int SpendWheet;

    public int SpendFeedCost;
    public int SpendBreedCost;

    public TextMeshProUGUI SpendMoneyText;
    public TextMeshProUGUI SpendWheetText;

    public AudioClip AcceptSound;
    

    #endregion

    private void Update()
    {
        if(!isLivestockActive)
        {
            IsInactive();
        }

        SpendMoneyText.text = GameManager.Instance.CountText(SpendMoney);
        SpendWheetText.text = GameManager.Instance.CountText(SpendWheet);

        haveWheetText.text = GameManager.Instance.CountText(farmScr.wheets);
        haveMoneyText.text = GameManager.Instance.CountText(GameManager.Instance.money);
            
    }

    private void IsInactive()
    {
        HensFeedChoosen = false;
        SheepsFeedChoosen = false;
        CowsFeedChoosen = false;

        HensBreedChoosen = false;
        SheepsBreedChoosen = false;
        CowsBreedChoosen = false;

        HensFeedImageSelected.color = new Color(255,0,0,255);
        SheepsFeedImageSelected.color = new Color(255,0,0,255);
        CowsFeedImageSelected.color = new Color(255,0,0,255);

        HensBreedImageSelected.color = new Color(255,0,0,255);
        SheepsBreedImageSelected.color = new Color(255,0,0,255);
        CowsBreedImageSelected.color = new Color(255,0,0,255);

    }

    /*#region full Feed Breed Show


    private void KnowFoodAmount()
    {
        hensScr.CountFoodForHens();
        hensFeedCost = hensScr.FoodAmountForHens;
        hensBreedCost = hensScr.FoodAmountForHens;

        sheepsScr.CountFoodForSheeps();
        sheepsFeedCost = sheepsScr.FoodAmountForSheeps;
        sheepsBreedCost = sheepsScr.FoodAmountForSheeps;

        cowsScr.CountFoodForCows();
        cowsFeedCost = cowsScr.FoodAmountForCows;
        cowsBreedCost = cowsScr.FoodAmountForCows;
    }

    #endregion*/

    #region Feed Logic

    public void LivestockersFeedByTurn()
    {
        if(HensFeedChoosen && isLivestockActive)
        {
            LivestockersFeedHens();
        }
        if(CowsFeedChoosen && isLivestockActive)
        {
            LivestockersFeedCows();
        }
        if(SheepsFeedChoosen && isLivestockActive)
        {
            LivestockersFeedSheeps();
        }
    }

    public void LivestockersFeedHens()
    {
        if(farmScr.wheets >= hensFeedCost && GameManager.Instance.money >= SpendFeedCost)
        {
            AutoFeedHens();
            GameManager.Instance.money -= SpendFeedCost;
        } 
        else
        {
            isLivestockActive = false;
        }
    }

    public void LivestockersFeedCows()
    {
        if(farmScr.wheets >= cowsFeedCost && GameManager.Instance.money >= SpendFeedCost)
        {
            AutoFeedCows();
            GameManager.Instance.money -= SpendFeedCost;
        } 
        else
        {
            isLivestockActive = false;
        }
    }

    public void LivestockersFeedSheeps()
    {
        if(farmScr.wheets >= sheepsFeedCost && GameManager.Instance.money >= SpendFeedCost)
        {
            GameManager.Instance.money -= SpendFeedCost;
            AutoFeedSheeps();
        }
        else
        {
            isLivestockActive = false;
        }
    }

    #endregion

    #region Breed Logic

    public void LivestockersBreedByTurn()
    {
        if(isLivestockActive)
        {
            Debug.Log("HensPlanted: " + HensIsPlanted);
            Debug.Log("SheepsPlanted: " + SheepsIsPlanted);
            Debug.Log("CowsPlanted: " + CowsIsPlanted);   

            if(!HensIsPlanted && HensBreedChoosen && farmScr.wheets >= hensFeedCost && GameManager.Instance.money >= SpendBreedCost)
            {

                GameManager.Instance.money -= SpendBreedCost;
                AutomaticHensBreed();
                TurnRecap.Instance.GetTextStrings("Breed: " + hensScr.HensToBeBorn + " hens");
                HensIsPlanted = true;
            }    

            if(!SheepsIsPlanted && SheepsBreedChoosen && farmScr.wheets >= sheepsFeedCost && GameManager.Instance.money >= SpendBreedCost)
            {
                GameManager.Instance.money -= SpendBreedCost;
                AutomaticSheepsBreed();
                TurnRecap.Instance.GetTextStrings("Breed: " + sheepsScr.SheepsToBeBorn + " sheeps");
                SheepsIsPlanted = true;
            }    

            if(!CowsIsPlanted && CowsBreedChoosen && farmScr.wheets >= cowsFeedCost && GameManager.Instance.money >= SpendBreedCost)
            {
                GameManager.Instance.money -= SpendBreedCost;
                AutomaticCowsBreed();
                TurnRecap.Instance.GetTextStrings("Breed: " + cowsScr.CowsToBeBorn + " cows");
                CowsIsPlanted = true;
            }       
  
        }
    }

    #endregion

    #region Automatic Functions

    private void AutoFeedHens()
    {   
        hensScr.CountFoodForHens();     
        hensScr.FeedTheHens();
        hensScr.HensGivingEggs();
        hensScr.TurnEarnEggs();

        TurnRecap.Instance.GetTextStrings("Hens AUTO Feed(" + hensFeedCost + " wheet)");
    }

    private void AutomaticHensBreed()
    {
        Debug.Log("FedHens: " + hensScr.FedHens);

        if(hensScr.FedHens > 0)
        {
            hensScr.PrimalHensToBorn();
            farmScr.wheets -= hensFeedCost;
            TurnRecap.Instance.GetTextStrings("Hens AUTO Breed(" + hensFeedCost + " wheet)");
        }
        else
        {
            hensScr.CountFoodForHens();     
            hensScr.FeedTheHens();

            hensScr.PrimalHensToBorn();
            farmScr.wheets -= hensFeedCost;
            TurnRecap.Instance.GetTextStrings("Hens AUTO Breed(" + hensFeedCost + " wheet)");
        }
        
    }

    private void AutoFeedSheeps()
    {   
        sheepsScr.CountFoodForSheeps(); 
        sheepsScr.FeedTheSheeps();
        sheepsScr.WoolToHaveByTurn();
        sheepsScr.TurnEarnWool();

        TurnRecap.Instance.GetTextStrings("Sheeps AUTO Feed(" + sheepsFeedCost + " wheet)");
    }

    private void AutomaticSheepsBreed()
    {
        Debug.Log("FedSheeps: " + sheepsScr.FedSheeps);

        if(sheepsScr.FedSheeps > 0)
        {
            sheepsScr.PrimalSheepsToBorn();
            farmScr.wheets -= sheepsFeedCost;
            TurnRecap.Instance.GetTextStrings("Sheeps AUTO Breed(" + sheepsFeedCost + " wheet)");
        }
        else
        {
            sheepsScr.CountFoodForSheeps(); 
            sheepsScr.FeedTheSheeps();

            sheepsScr.PrimalSheepsToBorn();
            farmScr.wheets -= sheepsFeedCost;
            TurnRecap.Instance.GetTextStrings("Sheeps AUTO Breed(" + sheepsFeedCost + " wheet)");
        }
        
    }

    private void AutoFeedCows()
    {   
        cowsScr.CountFoodForCows();
        cowsScr.FeedTheCows();
        cowsScr.MilkToHaveByTurn();
        cowsScr.TurnEarnMilk();

        TurnRecap.Instance.GetTextStrings("Cows AUTO Feed(" + cowsFeedCost + " wheet)");
    }

    private void AutomaticCowsBreed()
    {
        Debug.Log("FedCows: " + cowsScr.FedCows);

        if(cowsScr.FedCows > 0)
        {
            cowsScr.PrimalCowsToBorn();
            farmScr.wheets -= cowsFeedCost;
            TurnRecap.Instance.GetTextStrings("Cows were Breed(" + cowsFeedCost + " wheet)");
        }
        else
        {
            cowsScr.CountFoodForCows();
            cowsScr.FeedTheCows();

            cowsScr.PrimalCowsToBorn();
            farmScr.wheets -= cowsFeedCost;
            TurnRecap.Instance.GetTextStrings("Cows were Breed(" + cowsFeedCost + " wheet)");
        }
        
    }

    #endregion
    
    #region Choose Buttons

    public void ChooseFeedHens()
    {
        if(!HensFeedChoosen)
        {
            HensFeedChoosen = true;
            HensFeedImageSelected.color = new Color(0, 255, 0, 255);

            hensFeedCost = barnScr.hens * hensScr.FoodNeededForHens;

            SpendMoney += SpendFeedCost;
            SpendWheet += hensFeedCost;

            isLivestockActive = true;
            SoundManager.Instance.PlaySound(AcceptSound);
        }
        else
        {
            HensFeedChoosen = false;
            HensFeedImageSelected.color = new Color(255, 0, 0, 255);

            hensFeedCost = barnScr.hens * hensScr.FoodNeededForHens;

            SpendMoney -= SpendFeedCost;
            if(SpendMoney < 0)
                SpendMoney = 0;

            SpendWheet -= hensFeedCost;
            if(SpendWheet < 0)
                SpendWheet = 0;

            SoundManager.Instance.PlaySound(AcceptSound);
        }
    }

    public void ChooseBreedHens()
    {
        if(!HensBreedChoosen)
        {
            HensBreedChoosen = true;
            HensBreedImageSelected.color = new Color(0, 255, 0, 255);

            hensFeedCost = barnScr.hens * hensScr.FoodNeededForHens;

            SpendMoney += SpendFeedCost;
            SpendWheet += hensFeedCost;

            isLivestockActive = true;

            SoundManager.Instance.PlaySound(AcceptSound);
        }
        else
        {
            HensBreedChoosen = false;
            HensBreedImageSelected.color = new Color(255, 0, 0, 255);

            hensFeedCost = barnScr.hens * hensScr.FoodNeededForHens;

            SpendMoney -= SpendFeedCost;
            if(SpendMoney < 0)
                SpendMoney = 0;
            SpendWheet -= hensFeedCost;
            if(SpendWheet < 0)
                SpendWheet = 0;

            SoundManager.Instance.PlaySound(AcceptSound);
        }
    }

    public void ChooseFeedSheeps()
    {
        if(!SheepsFeedChoosen)
        {
            SheepsFeedChoosen = true;
            SheepsFeedImageSelected.color = new Color(0, 255, 0, 255);

            sheepsFeedCost = barnScr.sheeps * sheepsScr.FoodNeededForSheeps;

            SpendMoney += SpendFeedCost;
            SpendWheet += sheepsFeedCost;

            isLivestockActive = true;

            SoundManager.Instance.PlaySound(AcceptSound);
        }
        else
        {
            SheepsFeedChoosen = false;
            SheepsFeedImageSelected.color = new Color(255, 0, 0, 255);

            sheepsFeedCost = barnScr.sheeps * sheepsScr.FoodNeededForSheeps;

            SpendMoney -= SpendFeedCost;
            if(SpendMoney < 0)
                SpendMoney = 0;

            SpendWheet -= sheepsFeedCost;
            if(SpendWheet < 0)
                SpendWheet = 0;

            SoundManager.Instance.PlaySound(AcceptSound);
        }
    }

    public void ChooseBreedSheeps()
    {
        if(!SheepsBreedChoosen)
        {
            SheepsBreedChoosen = true;
            SheepsBreedImageSelected.color = new Color(0, 255, 0, 255);

            sheepsFeedCost = barnScr.sheeps * sheepsScr.FoodNeededForSheeps;

            SpendMoney += SpendFeedCost;
            SpendWheet += sheepsFeedCost;

            isLivestockActive = true;

            SoundManager.Instance.PlaySound(AcceptSound);
        }
        else
        {
            SheepsBreedChoosen = false;
            SheepsBreedImageSelected.color = new Color(255, 0, 0, 255);

            sheepsFeedCost = barnScr.sheeps * sheepsScr.FoodNeededForSheeps;

            SpendMoney -= SpendFeedCost;
            if(SpendMoney < 0)
                SpendMoney = 0;
            SpendWheet -= sheepsFeedCost;
            if(SpendWheet < 0)
                SpendWheet = 0;

            SoundManager.Instance.PlaySound(AcceptSound);
        }
    }

    public void ChooseFeedCows()
    {
        if(!CowsFeedChoosen)
        {
            CowsFeedChoosen = true;
            CowsFeedImageSelected.color = new Color(0, 255, 0, 255);

            cowsFeedCost = barnScr.cows * cowsScr.FoodNeededForCows;

            SpendMoney += SpendFeedCost;
            SpendWheet += cowsFeedCost;

            isLivestockActive = true;
            SoundManager.Instance.PlaySound(AcceptSound);
        }
        else
        {
            CowsFeedChoosen = false;
            CowsFeedImageSelected.color = new Color(255, 0, 0, 255);

            cowsFeedCost = barnScr.cows * cowsScr.FoodNeededForCows;

            SpendMoney -= SpendFeedCost;
            if(SpendMoney < 0)
                SpendMoney = 0;
            SpendWheet -= cowsFeedCost;
            if(SpendWheet < 0)
                SpendWheet = 0;

            SoundManager.Instance.PlaySound(AcceptSound);
        }
    }

    public void ChooseBreedCows()
    {
        if(!CowsBreedChoosen)
        {
            CowsBreedChoosen = true;
            CowsBreedImageSelected.color = new Color(0, 255, 0, 255);

            cowsFeedCost = barnScr.cows * cowsScr.FoodNeededForCows;

            SpendMoney += SpendFeedCost;
            SpendWheet += cowsFeedCost;

            isLivestockActive = true;
            SoundManager.Instance.PlaySound(AcceptSound);
        }
        else
        {
            CowsBreedChoosen = false;
            CowsBreedImageSelected.color = new Color(255, 0, 0, 255);

            cowsFeedCost = barnScr.cows * cowsScr.FoodNeededForCows;

            SpendMoney -= SpendFeedCost;
            if(SpendMoney < 0)
                SpendMoney = 0;
            SpendWheet -= cowsFeedCost;
            if(SpendWheet < 0)
                SpendWheet = 0;

            SoundManager.Instance.PlaySound(AcceptSound);
        }
    }

    #endregion
}
