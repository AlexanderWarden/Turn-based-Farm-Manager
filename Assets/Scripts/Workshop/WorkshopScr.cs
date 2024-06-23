using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkshopScr : MonoBehaviour
{
    #region Variables
    [Header("Scripts Vars")]
    public WorkshopShow WS;

    public FarmScr farmScr;
    public BarnScr barnScr;

    public ShopPrices shopPrices;

    public HensScr hensScr;
    public SheepsScr sheepsScr;
    public CowsScr cowsScr;

    public FieldScr Field1;
    public FieldScr Field2;
    public FieldScr Field3;

    [Header("Multiplicators")]

    // wheets multiplicators

    public int wheetAllMult;
    public int wheetCapPlus;

    private int wheetProdMult = 1;
    private int wheetCostMult = 1;
    private int wheetCapMult = 1;

    // vegetables multiplicators

    public int vegsAllMult;
    public int vegsCapPlus;

    private int vegsProdMult = 1;
    private int vegsCostMult = 1;
    private int vegsCapMult = 1;

    // grapes multiplicators

    public int grapesAllMult;
    public int grapesCapPlus;

    private int grapesProdMult = 1;
    private int grapesCostMult = 1;
    private int grapesCapMult = 1;

    // eggs multiplicators

    public int eggsAllMult;
    public int HensCapPlus;

    private int eggsProdMult = 1;
    private int eggsCostMult = 1;
    private int HensCapMult = 1;

    // wool multiplicators

    public int woolAllMult;
    public int SheepsCapPlus;

    private int woolProdMult = 1;
    private int woolCostMult = 1;
    private int SheepsCapMult = 1;

    // milk multiplicators

    public int milkAllMult;
    public int CowsCapPlus;

    private int milkProdMult = 1;
    private int milkCostMult = 1;
    private int CowsCapMult = 1;

    public int techAllMult;
    private int techProdMult = 1;
    
    public int fameAllMult;
    private int fameProdMult = 1; 

    public TextMeshProUGUI haveTechText;

    //public AudioClip AcceptSound;

    public int SI1;
    public int SI2;
    public int SI3;
    public int SI4;
    public int SI5;
    public int SI6;
    public int SI7;
    public int SI8;
    public int SI9;
    public int SI10;

    public int SI11;
    public int SI12;
    public int SI13;
    public int SI14;
    public int SI15;
    public int SI16;
    public int SI17;
    public int SI18;
    public int SI19;
    public int SI20;

    public int SI21;
    public int SI22;
    public int SI23;
    public int SI24;
    public int SI25;
    public int SI26;
    public int SI27;
    public int SI28;
    public int SI29;
    public int SI30;

    public int SI31;
    public int SI32;
    public int SI33;
    public int SI34;
    public int SI35;
    public int SI36;
    public int SI37;
    public int SI38;
    public int SI39;
    public int SI40;

    public int SI41;
    public int SI42;
    public int SI43;
    public int SI44;
    public int SI45;
    public int SI46;
    public int SI47;
    public int SI48;
    public int SI49;
    public int SI50;

    public int SI51;
    public int SI52;
    public int SI53;
    public int SI54;
    public int SI55;
    public int SI56;
    public int SI57;
    public int SI58;
    public int SI59;
    public int SI60;

    public int SI61;
    public int SI62;
    public int SI63;
    public int SI64;
    public int SI65;
    public int SI66;
    public int SI67;
    public int SI68;
    public int SI69;
    public int SI70;

    public int SI71;
    public int SI72;
    public int SI73;
    public int SI74;
    public int SI75;
    public int SI76;
    public int SI77;
    public int SI78;
    public int SI79;
    public int SI80;

    public int SI81;
    public int SI82;
    public int SI83;
    public int SI84;
    public int SI85;
    public int SI86;
    public int SI87;
    public int SI88;
    public int SI89;
    public int SI90;

    public int SI91;
    public int SI92;


    #endregion

    #region Udpate

    private void Update()
    {
        haveTechText.text = GameManager.Instance.CountText(GameManager.Instance.tech);
    }
    #endregion

    #region Save WS Info

    public void SaveWSInfo()
    {

        SI1 = WS.UpNumber1;
        SI2 = WS.UpCost1;
        SI3 = WS.UpNumber2;
        SI4 = WS.UpCost2;
        SI5 = WS.UpNumber3;
        SI6 = WS.UpCost3;
        SI7 = WS.UpNumber4;
        SI8 = WS.UpCost4;
        SI9 = WS.UpNumber5;
        SI10 = WS.UpCost5;
        SI11 = WS.UpNumber6;
        SI12 = WS.UpCost6;
        SI13 = WS.UpNumber7;
        SI14 = WS.UpCost7;
        SI15 = WS.UpNumber8;
        SI16 = WS.UpCost8;
        SI17 = WS.UpNumber9;
        SI18 = WS.UpCost9;
        SI19 = WS.UpNumber10;
        SI20 = WS.UpCost10;
        SI21 = WS.UpNumber11;
        SI22 = WS.UpCost11;
        SI23 = WS.UpNumber12;
        SI24 = WS.UpCost12;
        SI25 = WS.UpNumber13;
        SI26 = WS.UpCost13;
        SI27 = WS.UpNumber14;
        SI28 = WS.UpCost14;
        SI29 = WS.UpNumber15;
        SI30 = WS.UpCost15;
        SI31 = WS.UpNumber16;
        SI32 = WS.UpCost16;
        SI33 = WS.UpNumber17;
        SI34 = WS.UpCost17;
        SI35 = WS.UpNumber18;
        SI36 = WS.UpCost18;
        SI37 = WS.UpNumber19;
        SI38 = WS.UpCost19;
        SI39 = WS.UpNumber20;
        SI40 = WS.UpCost20;

        SI41 = shopPrices.InputWheetsSellPrice;
        SI42 = shopPrices.InputWheetsBuyPrice;
        SI43 = shopPrices.InputVegetablesSellPrice;
        SI44 = shopPrices.InputVegetablesBuyPrice;
        SI45 = shopPrices.InputGrapesSellPrice;
        SI46 = shopPrices.InputGrapesBuyPrice;
        SI47 = shopPrices.InputEggsSellPrice;
        SI48 = shopPrices.InputEggsBuyPrice;
        SI49 = shopPrices.InputWoolSellPrice;
        SI50 = shopPrices.InputWoolBuyPrice;
        SI51 = shopPrices.InputMilkSellPrice;
        SI52 = shopPrices.InputMilkBuyPrice;
        SI53 = shopPrices.InputHensSellPrice;
        SI54 = shopPrices.InputHensBuyPrice;
        SI55 = shopPrices.InputSheepsSellPrice;
        SI56 = shopPrices.InputSheepsBuyPrice;
        SI57 = shopPrices.InputCowsSellPrice;
        SI58 = shopPrices.InputCowsBuyPrice;

        SI59 = Field1.FieldCap;
        SI60 = Field2.FieldCap;
        SI61 = Field3.FieldCap;

        // Wheet

        SI62 = farmScr.wheetFertilityInput;
        SI63 = wheetProdMult;
        SI64 = wheetCostMult;
        SI65 = wheetCapMult;

        // Vegs

        SI66 = farmScr.vegsFertilityInput;
        SI67 = vegsProdMult;
        SI68 = vegsCostMult;
        SI69 = vegsCapMult;

        // Grapes

        SI70 = farmScr.grapesFertilityInput;
        SI71 = grapesProdMult;
        SI72 = grapesCostMult;
        SI73 = grapesCapMult;

        // hens

        SI74 = hensScr.eggsMult;
        SI75 = eggsProdMult;
        SI76 = eggsCostMult;
        SI77 = barnScr.HensCapAmount;
        SI78 = HensCapMult;

        SI79 = cowsScr.milkMult;
        SI80 = milkProdMult;
        SI81 = milkCostMult;
        SI82 = barnScr.CowsCapAmount;
        SI83 = CowsCapMult;

        SI84 = sheepsScr.woolMult;
        SI85 = woolProdMult;
        SI86 = woolCostMult;
        SI87 = barnScr.SheepsCapAmount;
        SI88 = SheepsCapMult;

        SI89 = techProdMult;
        SI90 = fameProdMult;

        SI91 = GameManager.Instance.techPlusAmount;
        SI92 = GameManager.Instance.famePlusAmount;
    }

    #endregion

    #region Load WS unfo

    public void LoadWSInfo()
    {

        WS.UpNumber1 = SI1;
        WS.UpCost1 = SI2;
        WS.UpNumber2 = SI3;
        WS.UpCost2 = SI4;
        WS.UpNumber3 = SI5;
        WS.UpCost3 = SI6;
        WS.UpNumber4 = SI7;
        WS.UpCost4 = SI8;
        WS.UpNumber5 = SI9;
        WS.UpCost5 = SI10;
        WS.UpNumber6 = SI11;
        WS.UpCost6 = SI12;
        WS.UpNumber7 = SI13;
        WS.UpCost7 = SI14;
        WS.UpNumber8 = SI15;
        WS.UpCost8 = SI16;
        WS.UpNumber9 = SI17;
        WS.UpCost9 = SI18;
        WS.UpNumber10 = SI19;
        WS.UpCost10 = SI20;
        WS.UpNumber11 = SI21;
        WS.UpCost11 = SI22;
        WS.UpNumber12 = SI23;
        WS.UpCost12 = SI24;
        WS.UpNumber13 = SI25;
        WS.UpCost13 = SI26;
        WS.UpNumber14 = SI27;
        WS.UpCost14 = SI28;
        WS.UpNumber15 = SI29;
        WS.UpCost15 = SI30;
        WS.UpNumber16 = SI31;
        WS.UpCost16 = SI32;
        WS.UpNumber17 = SI33;
        WS.UpCost17 = SI34;
        WS.UpNumber18 = SI35;
        WS.UpCost18 = SI36;
        WS.UpNumber19 = SI37;
        WS.UpCost19 = SI38;
        WS.UpNumber20 = SI39;
        WS.UpCost20 = SI40;

        shopPrices.InputWheetsSellPrice = SI41;
        shopPrices.InputWheetsBuyPrice = SI42;
        shopPrices.InputVegetablesSellPrice = SI43;
        shopPrices.InputVegetablesBuyPrice = SI44;
        shopPrices.InputGrapesSellPrice = SI45;
        shopPrices.InputGrapesBuyPrice = SI46;
        shopPrices.InputEggsSellPrice = SI47;
        shopPrices.InputEggsBuyPrice = SI48;
        shopPrices.InputWoolSellPrice = SI49;
        shopPrices.InputWoolBuyPrice = SI50;
        shopPrices.InputMilkSellPrice = SI51;
        shopPrices.InputMilkBuyPrice = SI52;
        shopPrices.InputHensSellPrice = SI53;
        shopPrices.InputHensBuyPrice = SI54;
        shopPrices.InputSheepsSellPrice = SI55;
        shopPrices.InputSheepsBuyPrice = SI56;
        shopPrices.InputCowsSellPrice = SI57;
        shopPrices.InputCowsBuyPrice = SI58;

        Field1.FieldCap = SI59;
        Field2.FieldCap = SI60;
        Field3.FieldCap = SI61;

        // Wheet

        farmScr.wheetFertilityInput = SI62;
        wheetProdMult = SI63;
        wheetCostMult = SI64;
        wheetCapMult = SI65;

        // Vegs

        farmScr.vegsFertilityInput = SI66;
        vegsProdMult = SI67;
        vegsCostMult = SI68;
        vegsCapMult = SI69;

        // Grapes

        farmScr.grapesFertilityInput = SI70;
        grapesProdMult = SI71;
        grapesCostMult = SI72;
        grapesCapMult = SI73;

        // hens

        hensScr.eggsMult = SI74;
        eggsProdMult = SI75;
        eggsCostMult = SI76;
        barnScr.HensCapAmount = SI77;
        HensCapMult = SI78;

        cowsScr.milkMult = SI79;
        milkProdMult = SI80;
        milkCostMult = SI81;
        barnScr.CowsCapAmount = SI82;
        CowsCapMult = SI83;

        sheepsScr.woolMult = SI84;
        woolProdMult = SI85;
        woolCostMult = SI86;
        barnScr.SheepsCapAmount = SI87;
        SheepsCapMult = SI88;

        techProdMult = SI89;
        fameProdMult = SI90;

        GameManager.Instance.techPlusAmount = SI91;
        GameManager.Instance.famePlusAmount = SI92;
    }

    #endregion

    #region Upgrade Logic

    public void UpgradeButtonClicked()
    {
        if(WS.UpgradeClicked > 0 && GameManager.Instance.tech >= WS.UpCostShow)
        {
            switch (WS.UpgradeClicked)
            {
                case 1:
                    farmScr.wheetFertilityInput += wheetProdMult;
                    wheetProdMult += wheetAllMult;
                    WS.UpNumber1 = wheetProdMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost1 += wheetProdMult;
                    WS.UpCostShow = WS.UpCost1;
                    
                    break;
                case 2:
                    shopPrices.InputWheetsSellPrice += wheetCostMult;
                    if(shopPrices.InputWheetsBuyPrice > 1)
                        shopPrices.InputWheetsBuyPrice -= wheetCostMult;
                    else
                        shopPrices.InputWheetsBuyPrice = 1;

                    shopPrices.SetWheetPrice();
                    wheetCostMult += wheetAllMult;
                    WS.UpNumber2 = wheetCostMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost2 += wheetCostMult;
                    WS.UpCostShow = WS.UpCost2;
                    
                    break;
                case 3:
                    //int WheetsCapMultResult = wheetCapMult * wheetCapPlus;
                    Field1.FieldCap += 500;
                    //farmScr.wheetCapAmount += WheetsCapMultResult;
                    wheetCapMult += wheetAllMult;
                    WS.UpNumber3 = wheetCapMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost3 += wheetCapMult;
                    WS.UpCostShow = WS.UpCost3;
                    
                    break;
                    
                case 4:
                    hensScr.eggsMult += eggsProdMult;
                    eggsProdMult += eggsAllMult;
                    WS.UpNumber4 = eggsProdMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost4 += eggsProdMult;
                    WS.UpCostShow = WS.UpCost4;
                    
                    break;
                case 5:
                    shopPrices.InputEggsSellPrice += eggsCostMult;
                    if(shopPrices.InputEggsBuyPrice > 1)
                        shopPrices.InputEggsBuyPrice -= eggsCostMult;
                    else
                        shopPrices.InputEggsBuyPrice = 1;
                    shopPrices.SetEggsPrice();
                    eggsCostMult += eggsAllMult;
                    WS.UpNumber5 = eggsCostMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost5 += eggsCostMult;
                    WS.UpCostShow = WS.UpCost5;
                    
                    break;
                case 6:
                    int HensCapMultResult = HensCapMult * HensCapPlus;
                    barnScr.HensCapAmount += HensCapMultResult;
                    HensCapMult += eggsAllMult;
                    WS.UpNumber6 = HensCapMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost6 += HensCapMult;
                    WS.UpCostShow = WS.UpCost6;
                    
                    break;
                case 7:
                    farmScr.vegsFertilityInput += vegsProdMult;
                    vegsProdMult += vegsAllMult;
                    WS.UpNumber7 = vegsProdMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost7 += vegsProdMult;
                    WS.UpCostShow = WS.UpCost7;
                    
                    break;
                case 8:
                    shopPrices.InputVegetablesSellPrice += vegsCostMult;

                    if(shopPrices.InputVegetablesBuyPrice > 1)
                        shopPrices.InputVegetablesBuyPrice -= vegsCostMult;
                    else
                        shopPrices.InputVegetablesBuyPrice = 1;
                    shopPrices.SetVegetablesPrice();
                    vegsCostMult += vegsAllMult;
                    WS.UpNumber8 = vegsCostMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost8 += vegsCostMult;
                    WS.UpCostShow = WS.UpCost8;
                    
                    break;
                case 9:
                    //int VegsCapMultResult = vegsCapMult * vegsCapPlus;
                    //farmScr.vegetablesCapAmount += VegsCapMultResult;

                    Field2.FieldCap += 500;
                    vegsCapMult += vegsAllMult;
                    WS.UpNumber9 = vegsCapMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost9 += vegsCapMult;
                    WS.UpCostShow = WS.UpCost9;
                    
                    break;
                case 10:
                    cowsScr.milkMult += milkProdMult;
                    milkProdMult += milkAllMult;
                    WS.UpNumber10 = milkProdMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost10 += milkProdMult;
                    WS.UpCostShow = WS.UpCost10;
                    
                    break;
                case 11:
                shopPrices.InputMilkSellPrice += milkCostMult;

                    if(shopPrices.InputMilkBuyPrice > 1)
                        shopPrices.InputMilkBuyPrice -= milkCostMult;
                    else
                        shopPrices.InputMilkBuyPrice = 1;
                    shopPrices.SetMilkPrice();

                    milkCostMult += milkAllMult;
                    WS.UpNumber11 = milkCostMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost11 += milkCostMult;
                    WS.UpCostShow = WS.UpCost11;
                    
                    break;

                    
                case 12:
                    int CowsCapMultResult = CowsCapMult * CowsCapPlus;
                    barnScr.CowsCapAmount += CowsCapMultResult;
                    CowsCapMult += milkAllMult;
                    WS.UpNumber12 = CowsCapMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost12 += CowsCapMult;
                    WS.UpCostShow = WS.UpCost12;
                    
                    break;
                    
                case 13:
                    sheepsScr.woolMult += woolProdMult;
                    woolProdMult += woolAllMult;
                    WS.UpNumber13 = woolProdMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost13 += woolProdMult;
                    WS.UpCostShow = WS.UpCost13;
                    
                    break;
                    
                case 14:
                    shopPrices.InputWoolSellPrice += woolCostMult;

                    if(shopPrices.InputWoolBuyPrice > 1)
                        shopPrices.InputWoolBuyPrice -= woolCostMult;
                    else
                        shopPrices.InputWoolBuyPrice = 1;
                    shopPrices.SetWoolPrice();
                    
                    woolCostMult += woolAllMult;
                    WS.UpNumber14 = woolCostMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost14 += woolCostMult;
                    WS.UpCostShow = WS.UpCost14;
                    
                    break;
                case 15:
                    int SheepsCapMultResult = SheepsCapMult * SheepsCapPlus;
                    barnScr.SheepsCapAmount += SheepsCapMultResult;
                    
                    SheepsCapMult += woolAllMult;
                    WS.UpNumber15 = SheepsCapMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost15 += SheepsCapMult;
                    WS.UpCostShow = WS.UpCost15;
                    
                    break;
                case 16:
                    farmScr.grapesFertilityInput += grapesProdMult;
                    grapesProdMult += grapesAllMult;
                    WS.UpNumber16 = grapesProdMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost16 += grapesProdMult;
                    WS.UpCostShow = WS.UpCost16;
                    
                    break;
                case 17:
                    shopPrices.InputGrapesSellPrice += grapesCostMult;

                    if(shopPrices.InputGrapesBuyPrice > 1)
                        shopPrices.InputGrapesBuyPrice -= grapesCostMult;
                    else
                        shopPrices.InputGrapesBuyPrice = 1;
                    shopPrices.SetGrapesPrice();
                    
                    grapesCostMult += grapesAllMult;
                    WS.UpNumber17 = grapesCostMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost17 += grapesCostMult;
                    WS.UpCostShow = WS.UpCost17;
                    
                    break;
                case 18:
                    //int GrapesCapMultResult = grapesCapMult * grapesCapPlus;
                    //farmScr.grapesCapAmount += GrapesCapMultResult;

                    Field3.FieldCap += 500;

                    grapesCapMult += grapesAllMult;
                    WS.UpNumber18 = grapesCapMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost18 += grapesCapMult;
                    WS.UpCostShow = WS.UpCost18;
                    
                    break;
                case 19:
                    GameManager.Instance.techPlusAmount += techProdMult;
                    techProdMult += techAllMult;
                    WS.UpNumber19 = techProdMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost19 += 30;
                    WS.UpCostShow = WS.UpCost19;
                    
                    break;
                case 20:
                    GameManager.Instance.famePlusAmount += fameProdMult;
                    fameProdMult += fameAllMult;
                    WS.UpNumber20 = fameProdMult;
                    GameManager.Instance.tech -= WS.UpCostShow;
                    WS.UpCost20 += 30;
                    WS.UpCostShow = WS.UpCost20;
                    
                    break;
                default:
                    break;
            }
        }
    }
    #endregion
}
