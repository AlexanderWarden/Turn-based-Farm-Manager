using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContractsScr : MonoBehaviour
{
    #region Variables 

    public ShopPrices shopPrices;
    public FarmScr farmScr;
    public BarnScr barnScr;

    public bool ContractIsDone = false;

    public int TurnsForContract;
    public int ProdAmountForContract;
    public int MoneyAmountForContract;
    public int FameAmountForContract;

    private int EasyContractTurns;
    private int MediumContractTurns;
    private int HardContractTurns;

    private int EasyProdAmount;
    private int MediumProdAmount;
    private int HardProdAmount;

    private int EasyMoneyAmount;
    private int MediumMoneyAmount;
    private int HardMoneyAmount;

    private int EasyMult = 1;
    private int MediumMult = 2;
    private int HardMult = 3;

    public int EasyFame;
    public int MediumFame;
    public int HardFame;

    private int EasyResourceNumber;
    private int MediumResourceNumber;
    private int HardResourceNumber;

    public GameObject EasyContractAgree;
    public GameObject MediumContractAgree;
    public GameObject HardContractAgree;

    public GameObject EasyContractHide;
    public GameObject MediumContractHide;
    public GameObject HardContractHide;

    [Header("Texts")]
    public TextMeshProUGUI EasyProdAmountText;
    public TextMeshProUGUI EasyTurnsAmountText;
    public TextMeshProUGUI EasyMoneyAmountText;
    public TextMeshProUGUI EasyFameAmountText;

    public TextMeshProUGUI MediumProdAmountText;
    public TextMeshProUGUI MediumTurnsAmountText;
    public TextMeshProUGUI MediumMoneyAmountText;
    public TextMeshProUGUI MediumFameAmountText;

    public TextMeshProUGUI HardProdAmountText;
    public TextMeshProUGUI HardTurnsAmountText;
    public TextMeshProUGUI HardMoneyAmountText;
    public TextMeshProUGUI HardFameAmountText;

    [Header("Easy Icons")]
    public GameObject EasyWheetIcon;
    public GameObject EasyVegsIcon;
    public GameObject EasyGrapesIcon;
    public GameObject EasyEggsIcon;
    public GameObject EasyWoolIcon;
    public GameObject EasyMilkIcon;

    [Header("Medium Icons")]
    public GameObject MediumWheetIcon;
    public GameObject MediumVegsIcon;
    public GameObject MediumGrapesIcon;
    public GameObject MediumEggsIcon;
    public GameObject MediumWoolIcon;
    public GameObject MediumMilkIcon;

    [Header("Hard Icons")]
    public GameObject HardWheetIcon;
    public GameObject HardVegsIcon;
    public GameObject HardGrapesIcon;
    public GameObject HardEggsIcon;
    public GameObject HardWoolIcon;
    public GameObject HardMilkIcon;

    [Header("Contract Info Icons")]
    public GameObject InfoWheetIcon;
    public GameObject InfoVegsIcon;
    public GameObject InfoGrapesIcon;
    public GameObject InfoEggsIcon;
    public GameObject InfoWoolIcon;
    public GameObject InfoMilkIcon;

    [Header("Info Texts")]
    public TextMeshProUGUI InfoTurnsText;
    public TextMeshProUGUI InfoNeedAmountText;
    public TextMeshProUGUI InfoHasAmountText;

    public bool hasContract = false;
    public int choosenResNumber = 0;
    public GameObject ContractInfoActive;

    public int hasResAmount = 0;
    public bool ContractChoosen = false;

    [Header("Can Choose Res")]
    public int CanChooseRes = 2; // Random Range second argument (+1 than actual)

    public AudioClip AcceptSound;

    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnContracts();
        }

        if(ContractChoosen)
            ShowContractInfo();
        else
            ContractInfoActive.SetActive(false);

    }
    #region Contract Turns

    public void SpawnContracts()
    {
        CloseDiffIcons();
        EasyContractSpawn();
        MediumContractSpawn();
        HardContractSpawn();
    }

    public void ContractByTurn()
    {
        if(ContractChoosen)
        {
            TurnRecap.Instance.GetTextStrings("Contract turns: " + TurnsForContract);
            EventsScr.Instance.EventPopText("Turns before the contract are fired: " + TurnsForContract);
            TurnsForContract--;

            if(TurnsForContract <= 0)
            {
                ContractDone(false);
            }
        }

        if(!ContractChoosen)
        {
            SpawnContracts();
        }
    }

    public void ContractDone(bool done)
    {
        if(done)
        {
            TurnRecap.Instance.GetTextStrings("You Done A Contract(+"+ FameAmountForContract+" fame)");
            EventsScr.Instance.EventPopText("You finished a contract(+"+MoneyAmountForContract+" money, and +"
                                            + FameAmountForContract+" fame)!");
            GameManager.Instance.fame += FameAmountForContract;
            GameManager.Instance.money += MoneyAmountForContract;
            ContractChoosen = false;
            Debug.Log("Contract is Done!");
            CloseTheContracts();
            CloseInfoIcons();
            SpawnContracts();
        }
        else
        {
            int doubleForPenalty = FameAmountForContract * 2;
            TurnRecap.Instance.GetTextStrings("You Failed Contract(-"+ doubleForPenalty +" fame)");
            EventsScr.Instance.EventPopText("You ruined a contract(-"+MoneyAmountForContract+" money, and -"
                                            + FameAmountForContract+" fame)!");
            
            GameManager.Instance.fame -= doubleForPenalty;
            GameManager.Instance.money -= MoneyAmountForContract;
            ContractChoosen = false;
            Debug.Log("Contract is Ruined!");
            CloseTheContracts();
            CloseInfoIcons();
            SpawnContracts();
        }
    }

    public void SendButton()
    {
        Debug.Log("hasResAmount: " + hasResAmount);
        Debug.Log("ProdAmount: " + ProdAmountForContract);
        SoundManager.Instance.PlaySound(AcceptSound);

        if(hasResAmount >= ProdAmountForContract)
        {
            switch(choosenResNumber)
            {
                case 1:
                    farmScr.wheets -= ProdAmountForContract;
                    ProdAmountForContract = 0;
                    ContractDone(true);
                    break;
                case 2:
                    barnScr.eggs -= ProdAmountForContract;                    
                    ProdAmountForContract = 0;
                    ContractDone(true);
                    break;
                case 3:
                    farmScr.vegetables -= ProdAmountForContract;                    
                    ProdAmountForContract = 0;
                    ContractDone(true);
                    break;
                case 4:
                    barnScr.milk -= ProdAmountForContract;                    
                    ProdAmountForContract = 0;
                    ContractDone(true);
                    break;
                case 5:
                    barnScr.wool -= ProdAmountForContract;
                    ProdAmountForContract = 0;
                    ContractDone(true);
                 break;
                case 6:
                    farmScr.grapes -= ProdAmountForContract;                    
                    ProdAmountForContract = 0;
                    ContractDone(true);
                    break;
                default:
                    break;
            }
        }
        else if(hasResAmount < ProdAmountForContract)
        {
            
            switch(choosenResNumber)
            {
                case 1:
                    ProdAmountForContract -= hasResAmount;
                    farmScr.wheets -= hasResAmount;
                    break;
                case 2:
                    ProdAmountForContract -= hasResAmount;
                    barnScr.eggs -= hasResAmount;
                    break;
                case 3:
                    ProdAmountForContract -= hasResAmount;
                    farmScr.vegetables -= hasResAmount;                    
                    break;
                case 4:
                    ProdAmountForContract -= hasResAmount;
                    barnScr.milk -= hasResAmount;                    
                    break;
                case 5:
                    ProdAmountForContract -= hasResAmount;
                    barnScr.wool -= hasResAmount;
                    break;
                case 6:
                    ProdAmountForContract -= hasResAmount;                    
                    farmScr.grapes -= hasResAmount;
                    break;
                default:
                    break;
            }
            
        }

        
    }

    #endregion

    #region Close Stuff

    private void CloseDiffIcons()
    {
        EasyWheetIcon.SetActive(false);
        EasyVegsIcon.SetActive(false);
        EasyGrapesIcon.SetActive(false);
        EasyEggsIcon.SetActive(false);
        EasyWoolIcon.SetActive(false);
        EasyMilkIcon.SetActive(false);

        MediumWheetIcon.SetActive(false);
        MediumVegsIcon.SetActive(false);
        MediumGrapesIcon.SetActive(false);
        MediumEggsIcon.SetActive(false);
        MediumWoolIcon.SetActive(false);
        MediumMilkIcon.SetActive(false);

        HardWheetIcon.SetActive(false);
        HardVegsIcon.SetActive(false);
        HardGrapesIcon.SetActive(false);
        HardEggsIcon.SetActive(false);
        HardWoolIcon.SetActive(false);
        HardMilkIcon.SetActive(false);
    }

    private void CloseInfoIcons()
    {
        InfoWheetIcon.SetActive(false);
        InfoVegsIcon.SetActive(false);
        InfoGrapesIcon.SetActive(false);
        InfoEggsIcon.SetActive(false);
        InfoWoolIcon.SetActive(false);
        InfoMilkIcon.SetActive(false);
    }

    public void CloseTheContracts()
    {
        EasyContractHide.SetActive(false);
        MediumContractHide.SetActive(false);
        HardContractHide.SetActive(false);

        EasyContractAgree.SetActive(false);
        MediumContractAgree.SetActive(false);
        HardContractAgree.SetActive(false);
    }

    #endregion

    //level of contract easy / medium / hard

    #region Contract Choose

    public void EasyContractChoosen()
    {
        hasContract = true;
        choosenResNumber = EasyResourceNumber;

        TurnsForContract = EasyContractTurns;
        ProdAmountForContract = EasyProdAmount;
        MoneyAmountForContract = EasyMoneyAmount;
        FameAmountForContract = EasyFame;

        EasyContractAgree.SetActive(true);
        ContractInfoActive.SetActive(true);

        MediumContractHide.SetActive(true);
        HardContractHide.SetActive(true);

        ContractChoosen = true;
        SoundManager.Instance.PlaySound(AcceptSound);
        
    }

    public void MediumContractChoosen()
    {
        hasContract = true;
        choosenResNumber = MediumResourceNumber;

        TurnsForContract = MediumContractTurns;
        ProdAmountForContract = MediumProdAmount;
        MoneyAmountForContract = MediumMoneyAmount;
        FameAmountForContract = MediumFame;

        MediumContractAgree.SetActive(true);
        ContractInfoActive.SetActive(true);

        EasyContractHide.SetActive(true);
        HardContractHide.SetActive(true);
        ContractChoosen = true;
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void HardContractChoosen()
    {
        hasContract = true;
        choosenResNumber = HardResourceNumber;

        TurnsForContract = HardContractTurns;
        ProdAmountForContract = HardProdAmount;
        MoneyAmountForContract = HardMoneyAmount;
        FameAmountForContract = HardFame;

        HardContractAgree.SetActive(true);
        ContractInfoActive.SetActive(true);

        EasyContractHide.SetActive(true);
        MediumContractHide.SetActive(true);
        ContractChoosen = true;
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region Res Choose Func

    private int ChooseContractResource()
    {
        int RandomResource = Random.Range(1, CanChooseRes);
        return RandomResource;

    }

    #endregion

    #region Prod Amount Spawn

    private int SetProdAmount(int DiffMult, bool isFielded)
    {
        int RandomNumber = 0;
        int ProdAmount = 0;

        if(GameManager.Instance.fame <= 10)
        {
            if(isFielded)
                RandomNumber = Random.Range(100, 1000);
            else
                RandomNumber = Random.Range(20, 100);
        }
        else if(GameManager.Instance.fame <= 50)
        {
            if(isFielded)
                RandomNumber = Random.Range(2000, 10000);
            else
                RandomNumber = Random.Range(50, 300);
        }
        else if(GameManager.Instance.fame <= 100)
        {
            if(isFielded)
                RandomNumber = Random.Range(3000, 15000);
            else
                RandomNumber = Random.Range(100, 1000);
        }
        else if(GameManager.Instance.fame <= 250)
        {
            if(isFielded)
                RandomNumber = Random.Range(40000, 200000);
            else
                RandomNumber = Random.Range(1000, 4000);
        }
        else if(GameManager.Instance.fame <= 500)
        {
            if(isFielded)
                RandomNumber = Random.Range(50000, 400000);
            else
                RandomNumber = Random.Range(5000, 10000);
        }
        else if(GameManager.Instance.fame <= 1000)
        {
            if(isFielded)
                RandomNumber = Random.Range(60000, 300000);
            else
                RandomNumber = Random.Range(10000, 20000);
        }
        else if(GameManager.Instance.fame <= 3000)
        {
            if(isFielded)
                RandomNumber = Random.Range(70000, 350000);
            else
                RandomNumber = Random.Range(20000, 40000);
        }
        else if(GameManager.Instance.fame <= 7500)
        {
            if(isFielded)
                RandomNumber = Random.Range(80000, 400000);
            else
                RandomNumber = Random.Range(40000, 100000);
        }
        else if(GameManager.Instance.fame <= 10000)
        {
            if(isFielded)
                RandomNumber = Random.Range(100000, 500000);
            else
                RandomNumber = Random.Range(100000, 500000);
        }

        ProdAmount = RandomNumber * DiffMult;

        return ProdAmount;
    }

    #endregion

    #region Amount of Turns Spawn

    private int SetTurnAmount(int DiffMult)
    {
        int RandomTurns = 0;
        int TurnsAmount = 0;

        if(GameManager.Instance.fame <= 10)
        {
            RandomTurns = Random.Range(1, 3);
        }
        else if(GameManager.Instance.fame <= 50)
        {
            RandomTurns = Random.Range(2, 6);
        }
        else if(GameManager.Instance.fame <= 100)
        {
            RandomTurns = Random.Range(3, 6);
        }
        else if(GameManager.Instance.fame <= 250)
        {
            RandomTurns = Random.Range(4, 8);
        }
        else if(GameManager.Instance.fame <= 500)
        {
            RandomTurns = Random.Range(5, 12);
        }
        else if(GameManager.Instance.fame <= 1000)
        {
            RandomTurns = Random.Range(6, 12);
        }
        else if(GameManager.Instance.fame <= 2000)
        {
            RandomTurns = Random.Range(8, 14);
        }
        else if(GameManager.Instance.fame <= 3500)
        {
            RandomTurns = Random.Range(8, 16);
        }
        else if(GameManager.Instance.fame <= 5000)
        {
            RandomTurns = Random.Range(10, 16);
        }
        else
        {
            RandomTurns = Random.Range(10, 20);
        }

        TurnsAmount = RandomTurns * DiffMult;
        return TurnsAmount;
    }

    #endregion

    #region Money Amount for Contract

    private int GetPriceForChoosenRes(int number)
    {

        int SellPrice = 0;

        switch(number)
        {
            case 1:
                SellPrice = shopPrices.InputWheetsSellPrice;
                break;
            case 2:
                SellPrice = shopPrices.InputVegetablesSellPrice;
                break;
            case 3:
                SellPrice = shopPrices.InputGrapesSellPrice;
                break;
            case 4:
                SellPrice = shopPrices.InputEggsSellPrice;
                break;
            case 5:
                SellPrice = shopPrices.InputWoolSellPrice;
                break;
            case 6:
                SellPrice = shopPrices.InputMilkSellPrice;
                break;
            default:
                break;
    
        }

        return SellPrice;
    }
    
    private int SetMoneyAmount(int DiffMult, int ResNumber, int ResAmount)
    {
        int PriceOfRes = GetPriceForChoosenRes(ResNumber);
        int AddNumberByFame = 0;
        int MoneyOffDiff = PriceOfRes * DiffMult;
        int MoneySum = MoneyOffDiff * ResAmount;
        int MoneyForReturn = 0;


        if(GameManager.Instance.fame <= 10)
        {
            AddNumberByFame = Random.Range(100, 1000);
        }
        else if(GameManager.Instance.fame <= 50)
        {
            AddNumberByFame = Random.Range(200, 2000);
        }
        else if(GameManager.Instance.fame <= 100)
        {
            AddNumberByFame = Random.Range(400, 4000);
        }
        else if(GameManager.Instance.fame <= 250)
        {
            AddNumberByFame = Random.Range(800, 8000);
        }
        else if(GameManager.Instance.fame <= 500)
        {
            AddNumberByFame = Random.Range(1600, 16000);
        }
        else if(GameManager.Instance.fame <= 1000)
        {
            AddNumberByFame = Random.Range(3200, 32000);
        }
        else if(GameManager.Instance.fame <= 3000)
        {
            AddNumberByFame = Random.Range(6400, 64000);
        }
        else if(GameManager.Instance.fame <= 7500)
        {
            AddNumberByFame = Random.Range(12800, 128000);
        }
        else if(GameManager.Instance.fame <= 10000)
        {
            AddNumberByFame = Random.Range(25000, 250000);
        }

        MoneyForReturn = MoneySum + AddNumberByFame;
        return MoneyForReturn;
    }

    #endregion

    #region Contracts Spawn

    private void EasyContractSpawn()
    {
        EasyResourceNumber = ChooseContractResource();

        switch(EasyResourceNumber)
        {
            case 1:
                EasyWheetIcon.SetActive(true);
                EasyProdAmount = SetProdAmount(EasyMult, true);
                break;
            case 2:
                EasyEggsIcon.SetActive(true);
                EasyProdAmount = SetProdAmount(EasyMult, false);
                break;
            case 3:
                EasyVegsIcon.SetActive(true);
                EasyProdAmount = SetProdAmount(EasyMult, true);
                break;
            case 4:
                EasyMilkIcon.SetActive(true);
                EasyProdAmount = SetProdAmount(EasyMult, false);
                break;
            case 5:
                EasyWoolIcon.SetActive(true);
                EasyProdAmount = SetProdAmount(EasyMult, false);
                break;
            case 6:
                EasyGrapesIcon.SetActive(true);
                EasyProdAmount = SetProdAmount(EasyMult, true);
                break;
            default:
                break;
        }

        EasyContractTurns = SetTurnAmount(3);
        EasyMoneyAmount = SetMoneyAmount(EasyMult, EasyResourceNumber, EasyProdAmount);

        EasyProdAmountText.text = GameManager.Instance.CountText(EasyProdAmount);
        EasyTurnsAmountText.text = GameManager.Instance.CountText(EasyContractTurns);
        EasyMoneyAmountText.text = GameManager.Instance.CountText(EasyMoneyAmount);
        EasyFameAmountText.text = EasyFame.ToString();
        
        

    }

    private void MediumContractSpawn()
    {
        MediumResourceNumber = ChooseContractResource();

        switch(MediumResourceNumber)
        {
            case 1:
                MediumWheetIcon.SetActive(true);
                MediumProdAmount = SetProdAmount(MediumMult, true);
                break;
            case 2:
                MediumEggsIcon.SetActive(true);
                MediumProdAmount = SetProdAmount(MediumMult, false);
                break;
            case 3:
                MediumVegsIcon.SetActive(true);
                MediumProdAmount = SetProdAmount(MediumMult, true);
                break;
            case 4:
                MediumMilkIcon.SetActive(true);
                MediumProdAmount = SetProdAmount(MediumMult, false);
                break;
            case 5:
                MediumWoolIcon.SetActive(true);
                MediumProdAmount = SetProdAmount(MediumMult, false);
                break;
            case 6:
                MediumGrapesIcon.SetActive(true);
                MediumProdAmount = SetProdAmount(MediumMult, true);
                break;
            default:
                break;
        }
        
        MediumContractTurns = SetTurnAmount(2);
        MediumMoneyAmount = SetMoneyAmount(MediumMult, MediumResourceNumber, MediumProdAmount);

        MediumProdAmountText.text = GameManager.Instance.CountText(MediumProdAmount);
        MediumTurnsAmountText.text = GameManager.Instance.CountText(MediumContractTurns);
        MediumMoneyAmountText.text = GameManager.Instance.CountText(MediumMoneyAmount);
        MediumFameAmountText.text = MediumFame.ToString();
        
        

    }

    private void HardContractSpawn()
    {
        HardResourceNumber = ChooseContractResource();

        switch(HardResourceNumber)
        {
            case 1:
                HardWheetIcon.SetActive(true);
                HardProdAmount = SetProdAmount(HardMult, true);
                break;
            case 2:
                HardEggsIcon.SetActive(true);
                HardProdAmount = SetProdAmount(HardMult, false);
                break;
            case 3:
                HardVegsIcon.SetActive(true);
                HardProdAmount = SetProdAmount(HardMult, true);
                break;
            case 4:
                HardMilkIcon.SetActive(true);
                HardProdAmount = SetProdAmount(HardMult, false);
                break;
            case 5:
                HardWoolIcon.SetActive(true);
                HardProdAmount = SetProdAmount(HardMult, false);
                break;
            case 6:
                HardGrapesIcon.SetActive(true);
                HardProdAmount = SetProdAmount(HardMult, true);
                break;
            default:
                break;
        }
        
        HardContractTurns = SetTurnAmount(1);
        HardMoneyAmount = SetMoneyAmount(HardMult, HardResourceNumber, HardProdAmount);

        HardProdAmountText.text = GameManager.Instance.CountText(HardProdAmount);
        HardTurnsAmountText.text = GameManager.Instance.CountText(HardContractTurns);
        HardMoneyAmountText.text = GameManager.Instance.CountText(HardMoneyAmount);
        HardFameAmountText.text = HardFame.ToString();
        
    }

    #endregion

    private void ShowContractInfo()
    {
        hasResAmount = 0;
        
        switch(choosenResNumber)
        {
            case 1:
                InfoWheetIcon.SetActive(true);
                hasResAmount = farmScr.wheets;
                break;
            case 2:
                InfoEggsIcon.SetActive(true);
                hasResAmount = barnScr.eggs;
                
                break;
            case 3:
                InfoVegsIcon.SetActive(true);
                hasResAmount = farmScr.vegetables;
                
                break;
            case 4:
                InfoMilkIcon.SetActive(true);
                hasResAmount = barnScr.milk;
                
                break;
            case 5:
                InfoWoolIcon.SetActive(true);
                hasResAmount = barnScr.wool;
                break;
            case 6:
                InfoGrapesIcon.SetActive(true);
                hasResAmount = farmScr.grapes;
                
                break;
            default:
                break;
        }

        InfoTurnsText.text = TurnsForContract.ToString();
        InfoNeedAmountText.text = GameManager.Instance.CountText(ProdAmountForContract);
        InfoHasAmountText.text = GameManager.Instance.CountText(hasResAmount);
        
    }

}
