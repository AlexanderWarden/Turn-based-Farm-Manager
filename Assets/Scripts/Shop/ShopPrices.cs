using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopPrices : MonoBehaviour
{
    [Header("Sell Prices:")]

    public int InputWheetsSellPrice;
    public int InputVegetablesSellPrice;
    public int InputGrapesSellPrice;

    public int InputEggsSellPrice;
    public int InputWoolSellPrice;
    public int InputMilkSellPrice;

    public int InputHensSellPrice;
    public int InputSheepsSellPrice;
    public int InputCowsSellPrice;

    public int BalanceWheetsSellPrice;
    public int BalanceVegetablesSellPrice;
    public int BalanceGrapesSellPrice;

    public int BalanceEggsSellPrice;
    public int BalanceWoolSellPrice;
    public int BalanceMilkSellPrice;

    public int BalanceHensSellPrice;
    public int BalanceSheepsSellPrice;
    public int BalanceCowsSellPrice;

    [HideInInspector] public int WheetsSellPrice;
    [HideInInspector] public int VegetablesSellPrice;
    [HideInInspector] public int GrapesSellPrice;

    [HideInInspector] public int EggsSellPrice;
    [HideInInspector] public int WoolSellPrice;
    [HideInInspector] public int MilkSellPrice;

    [HideInInspector] public int HensSellPrice;
    [HideInInspector] public int SheepsSellPrice;
    [HideInInspector] public int CowsSellPrice;

    [Header("Buy Prices:")]

    public int InputWheetsBuyPrice;
    public int InputVegetablesBuyPrice;
    public int InputGrapesBuyPrice;

    public int InputEggsBuyPrice;
    public int InputWoolBuyPrice;
    public int InputMilkBuyPrice;

    public int InputHensBuyPrice;
    public int InputSheepsBuyPrice;
    public int InputCowsBuyPrice;

    public int BalanceWheetsBuyPrice;
    public int BalanceVegetablesBuyPrice;
    public int BalanceGrapesBuyPrice;

    public int BalanceEggsBuyPrice;
    public int BalanceWoolBuyPrice;
    public int BalanceMilkBuyPrice;

    public int BalanceHensBuyPrice;
    public int BalanceSheepsBuyPrice;
    public int BalanceCowsBuyPrice;

    [HideInInspector] public int WheetsBuyPrice;
    [HideInInspector] public int VegetablesBuyPrice;
    [HideInInspector] public int GrapesBuyPrice;

    [HideInInspector] public int EggsBuyPrice;
    [HideInInspector] public int WoolBuyPrice;
    [HideInInspector] public int MilkBuyPrice;

    [HideInInspector] public int HensBuyPrice;
    [HideInInspector] public int SheepsBuyPrice;
    [HideInInspector] public int CowsBuyPrice;

    public TextMeshProUGUI wheetsSellText;
    public TextMeshProUGUI wheetsBuyText;

    public TextMeshProUGUI vegetablesSellText;
    public TextMeshProUGUI vegetablesBuyText;

    public TextMeshProUGUI grapesSellText;
    public TextMeshProUGUI grapesBuyText;

    public TextMeshProUGUI eggsSellText;
    public TextMeshProUGUI eggsBuyText;

    public TextMeshProUGUI woolSellText;
    public TextMeshProUGUI woolBuyText;

    public TextMeshProUGUI milkSellText;
    public TextMeshProUGUI milkBuyText;

    public TextMeshProUGUI HensSellText;
    public TextMeshProUGUI HensBuyText;

    public TextMeshProUGUI SheepsSellText;
    public TextMeshProUGUI SheepsBuyText;

    public TextMeshProUGUI CowsSellText;
    public TextMeshProUGUI CowsBuyText;

    public int PricesBoost;

    private void Start()
    {
        SetPricesForTurn();
    }

    public void Update()
    {
        NotNegativePrice();
    }

    public void NotNegativePrice()
    {
        if(InputWheetsBuyPrice <= 0)
            InputWheetsBuyPrice = 1;
        if(InputVegetablesBuyPrice <= 0)
            InputVegetablesBuyPrice = 1;
        if(InputGrapesBuyPrice <= 0)
            InputGrapesBuyPrice = 1;

        if(InputEggsBuyPrice <= 0)
            InputEggsBuyPrice = 1;
        if(InputWoolBuyPrice <= 0)
            InputWoolBuyPrice = 1;
        if(InputMilkBuyPrice <= 0)
            InputMilkBuyPrice = 1;

        if(InputHensBuyPrice <= 0)
            InputHensBuyPrice = 1;
        if(InputSheepsBuyPrice <= 0)
            InputSheepsBuyPrice = 1;
        if(InputCowsBuyPrice <= 0)
            InputCowsBuyPrice = 1;

        if(WheetsBuyPrice <= 0)
            WheetsBuyPrice = 1;
        if(VegetablesBuyPrice <= 0)
            VegetablesBuyPrice = 1;
        if(GrapesBuyPrice <= 0)
            GrapesBuyPrice = 1;

        if(EggsBuyPrice <= 0)
            EggsBuyPrice = 1;
        if(WoolBuyPrice <= 0)
            WoolBuyPrice = 1;
        if(MilkBuyPrice <= 0)
            MilkBuyPrice = 1;

        if(HensBuyPrice <= 0)
            HensBuyPrice = 1;
        if(SheepsBuyPrice <= 0)
            SheepsBuyPrice = 1;
        if(CowsBuyPrice <= 0)
            CowsBuyPrice = 1;
    }

    public void SetPricesForTurn()
    {
        SetWheetPrice();
        SetVegetablesPrice();
        SetGrapesPrice();
        SetEggsPrice();
        SetWoolPrice();
        SetMilkPrice();
        SetHensPrice();
        SetSheepsPrice();
        SetCowsPrice();

        TurnRecap.Instance.GetTextStrings("New prices in the shop!");
    }

    public void PricesBoosted()
    {
        InputWheetsBuyPrice += PricesBoost;
        InputWheetsSellPrice += PricesBoost;

        InputVegetablesBuyPrice += PricesBoost;
        InputVegetablesSellPrice += PricesBoost;

        InputGrapesBuyPrice += PricesBoost;
        InputGrapesSellPrice += PricesBoost;

        InputEggsBuyPrice += PricesBoost;
        InputEggsSellPrice += PricesBoost;

        InputWoolBuyPrice += PricesBoost;
        InputWoolSellPrice += PricesBoost;

        InputMilkBuyPrice += PricesBoost;
        InputMilkSellPrice += PricesBoost;

        InputHensBuyPrice += PricesBoost;
        InputHensSellPrice += PricesBoost;

        InputCowsBuyPrice += PricesBoost;
        InputCowsSellPrice += PricesBoost;

        InputSheepsBuyPrice += PricesBoost;
        InputSheepsSellPrice += PricesBoost;
    }

    public void SetWheetPrice()
    {
        int lowWheetSellPrice = InputWheetsSellPrice - BalanceWheetsSellPrice;
        int UpWheetSellPrice = InputWheetsSellPrice + BalanceWheetsSellPrice;
        int wheetSellPriceRandom = Random.Range(lowWheetSellPrice, UpWheetSellPrice+1);
        WheetsSellPrice = wheetSellPriceRandom;

        wheetsSellText.text = WheetsSellPrice.ToString();

        int lowWheetBuyPrice = InputWheetsBuyPrice - BalanceWheetsBuyPrice;
        int UpWheetBuyPrice = InputWheetsBuyPrice + BalanceWheetsBuyPrice;
        int WheetBuyPriceRandom = Random.Range(lowWheetBuyPrice, UpWheetBuyPrice+1);
        WheetsBuyPrice = WheetBuyPriceRandom;

        wheetsBuyText.text = WheetsBuyPrice.ToString();
    }

    public void SetVegetablesPrice()
    {
        int lowVegetablesSellPrice = InputVegetablesSellPrice - BalanceVegetablesSellPrice;
        int UpVegetablesSellPrice = InputVegetablesSellPrice + BalanceVegetablesSellPrice;
        int VegetablesSellPriceRandom = Random.Range(lowVegetablesSellPrice, UpVegetablesSellPrice+1);
        VegetablesSellPrice = VegetablesSellPriceRandom;

        vegetablesSellText.text = VegetablesSellPrice.ToString();

        int lowVegetablesBuyPrice = InputVegetablesBuyPrice - BalanceVegetablesBuyPrice;
        int UpVegetablesBuyPrice = InputVegetablesBuyPrice + BalanceVegetablesBuyPrice;
        int VegetablesBuyPriceRandom = Random.Range(lowVegetablesBuyPrice, UpVegetablesBuyPrice+1);
        VegetablesBuyPrice = VegetablesBuyPriceRandom;

        vegetablesBuyText.text = VegetablesBuyPrice.ToString();

    }

    public void SetGrapesPrice()
    {
        int lowGrapesSellPrice = InputGrapesSellPrice - BalanceGrapesSellPrice;
        int UpGrapesSellPrice = InputGrapesSellPrice + BalanceGrapesSellPrice;
        int GrapesSellPriceRandom = Random.Range(lowGrapesSellPrice, UpGrapesSellPrice+1);
        GrapesSellPrice = GrapesSellPriceRandom;

        grapesSellText.text = GrapesSellPrice.ToString();

        int lowGrapesBuyPrice = InputGrapesBuyPrice - BalanceGrapesBuyPrice;
        int UpGrapesBuyPrice = InputGrapesBuyPrice + BalanceGrapesBuyPrice;
        int GrapesBuyPriceRandom = Random.Range(lowGrapesBuyPrice, UpGrapesBuyPrice+1);
        GrapesBuyPrice = GrapesBuyPriceRandom;

        grapesBuyText.text = GrapesBuyPrice.ToString();

    }


    public void SetEggsPrice()
    {
        int lowEggsSellPrice = InputEggsSellPrice - BalanceEggsSellPrice;
        int UpEggsSellPrice = InputEggsSellPrice + BalanceEggsSellPrice;
        int EggsSellPriceRandom = Random.Range(lowEggsSellPrice, UpEggsSellPrice+1);
        EggsSellPrice = EggsSellPriceRandom;

        eggsSellText.text = EggsSellPrice.ToString();

        int lowEggsBuyPrice = InputEggsBuyPrice - BalanceEggsBuyPrice;
        int UpEggsBuyPrice = InputEggsBuyPrice + BalanceEggsBuyPrice;
        int EggsBuyPriceRandom = Random.Range(lowEggsBuyPrice, UpEggsBuyPrice+1);
        EggsBuyPrice = EggsBuyPriceRandom;

        eggsBuyText.text = EggsBuyPrice.ToString();

    }

    public void SetWoolPrice()
    {
        int lowWoolSellPrice = InputWoolSellPrice - BalanceWoolSellPrice;
        int UpWoolSellPrice = InputWoolSellPrice + BalanceWoolSellPrice;
        int WoolSellPriceRandom = Random.Range(lowWoolSellPrice, UpWoolSellPrice+1);
        WoolSellPrice = WoolSellPriceRandom;

        woolSellText.text = WoolSellPrice.ToString();

        int lowWoolBuyPrice = InputWoolBuyPrice - BalanceWoolBuyPrice;
        int UpWoolBuyPrice = InputWoolBuyPrice + BalanceWoolBuyPrice;
        int WoolBuyPriceRandom = Random.Range(lowWoolBuyPrice, UpWoolBuyPrice+1);
        WoolBuyPrice = WoolBuyPriceRandom;

        woolBuyText.text = WoolBuyPrice.ToString();

    }

    public void SetMilkPrice()
    {
        int lowMilkSellPrice = InputMilkSellPrice - BalanceMilkSellPrice;
        int UpMilkSellPrice = InputMilkSellPrice + BalanceMilkSellPrice;
        int MilkSellPriceRandom = Random.Range(lowMilkSellPrice, UpMilkSellPrice+1);
        MilkSellPrice = MilkSellPriceRandom;

        milkSellText.text = MilkSellPrice.ToString();

        int lowMilkBuyPrice = InputMilkBuyPrice - BalanceMilkBuyPrice;
        int UpMilkBuyPrice = InputMilkBuyPrice + BalanceMilkBuyPrice;
        int MilkBuyPriceRandom = Random.Range(lowMilkBuyPrice, UpMilkBuyPrice+1);
        MilkBuyPrice = MilkBuyPriceRandom;

        milkBuyText.text = MilkBuyPrice.ToString();

    }

    public void SetHensPrice()
    {
        int lowHensSellPrice = InputHensSellPrice - BalanceHensSellPrice;
        int UpHensSellPrice = InputHensSellPrice + BalanceHensSellPrice;
        int HensSellPriceRandom = Random.Range(lowHensSellPrice, UpHensSellPrice+1);
        HensSellPrice = HensSellPriceRandom;

        HensSellText.text = HensSellPrice.ToString();

        int lowHensBuyPrice = InputHensBuyPrice - BalanceHensBuyPrice;
        int UpHensBuyPrice = InputHensBuyPrice + BalanceHensBuyPrice;
        int HensBuyPriceRandom = Random.Range(lowHensBuyPrice, UpHensBuyPrice+1);
        HensBuyPrice = HensBuyPriceRandom;

        HensBuyText.text = HensBuyPrice.ToString();
    }

    public void SetSheepsPrice()
    {
        int lowSheepsSellPrice = InputSheepsSellPrice - BalanceSheepsSellPrice;
        int UpSheepsSellPrice = InputSheepsSellPrice + BalanceSheepsSellPrice;
        int SheepsSellPriceRandom = Random.Range(lowSheepsSellPrice, UpSheepsSellPrice+1);
        SheepsSellPrice = SheepsSellPriceRandom;

        SheepsSellText.text = SheepsSellPrice.ToString();

        int lowSheepsBuyPrice = InputSheepsBuyPrice - BalanceSheepsBuyPrice;
        int UpSheepsBuyPrice = InputSheepsBuyPrice + BalanceSheepsBuyPrice;
        int SheepsBuyPriceRandom = Random.Range(lowSheepsBuyPrice, UpSheepsBuyPrice+1);
        SheepsBuyPrice = SheepsBuyPriceRandom;

        SheepsBuyText.text = SheepsBuyPrice.ToString();
    }

    public void SetCowsPrice()
    {
        int lowCowsSellPrice = InputCowsSellPrice - BalanceCowsSellPrice;
        int UpCowsSellPrice = InputCowsSellPrice + BalanceCowsSellPrice;
        int CowsSellPriceRandom = Random.Range(lowCowsSellPrice, UpCowsSellPrice+1);
        CowsSellPrice = CowsSellPriceRandom;

        CowsSellText.text = CowsSellPrice.ToString();

        int lowCowsBuyPrice = InputCowsBuyPrice - BalanceCowsBuyPrice;
        int UpCowsBuyPrice = InputCowsBuyPrice + BalanceCowsBuyPrice;
        int CowsBuyPriceRandom = Random.Range(lowCowsBuyPrice, UpCowsBuyPrice+1);
        CowsBuyPrice = CowsBuyPriceRandom;

        CowsBuyText.text = CowsBuyPrice.ToString();
    }

}
