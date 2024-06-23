using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreScr : MonoBehaviour
{
    #region Variable 

    public FarmScr Farm;
    public BarnScr Barn;
    public ShopPrices shopPrices;
    public StoreShow storeShow;

    public GameObject priceList;

    public int SelectedResource = 0;
    public int Product;
    public int ProductSellPrice;
    public int ProductBuyPrice;

    public int farmUpNumber = 1;
    public int barnUpNumber = 1;
    public int FertilityUpNumber = 1;
    public int ChoosenUpgrade = 0;

    public int UpgradeMult = 0;

    public int farmUpMoney = 0;
    public int barnUpMoney = 0;
    public int FertilityUpMoney = 0;

    public int wheetBuyPrice = 3;
    public int wheetSellPrice = 2;
    public int eggBuyPrice = 40;
    public int eggSellPrice = 30;

    public int BuyAmount = 0;
    public int SellAmount = 0;
    public int BuyMoney = 0;
    public int SellMoney = 0;

    public int HoWMuchMoney = 0;
    public TextMeshProUGUI howMuchMoneyText;

    public int HoWMuchThings = 0;
    public TextMeshProUGUI howMuchThingsText;

    [Header("ShowResourcesByFame:")]

    public GameObject PriceHensShow;
    public GameObject ShopPanelHensShow;
    public GameObject ShopPanelEggsShow;

    public GameObject PriceSheepsShow;
    public GameObject ShopPanelSheepsShow;
    public GameObject ShopPanelWoolShow;

    public GameObject PriceCowsShow;
    public GameObject ShopPanelCowsShow;
    public GameObject ShopPanelMilkShow;

    public GameObject PriceVegetablesShow;
    public GameObject ShopPanelVegetablesShow;

    public GameObject PriceGrapesShow;
    public GameObject ShopPanelGrapesShow;

    public GameObject AnimalShopShow;

    public int BuyNumber;
    public int BuyLock = 5000;
    public TextMeshProUGUI BuyLockText;

    public int SellButtonChoosen = 0;

    public AudioClip AcceptSound;

    #endregion

    private void Update()
    {
        HowMuchMoneyText();
        HowMuchThingsText();  
        BuyLockText.text = BuyLock.ToString();    
    }

    public void BuyLockReset()
    {
        BuyLock = 5000;
    }

    #region Unlock

    public void HensProductsUnlock()
    {
        PriceHensShow.SetActive(true);
        AnimalShopShow.SetActive(true);

        ShopPanelHensShow.SetActive(true);
        ShopPanelEggsShow.SetActive(true);
    }

    public void SheepsProductsUnlock()
    {
        PriceSheepsShow.SetActive(true);

        ShopPanelSheepsShow.SetActive(true);
        ShopPanelWoolShow.SetActive(true);
        
    }

    public void CowsProductsUnlock()
    {
        PriceCowsShow.SetActive(true);

        ShopPanelCowsShow.SetActive(true);
        ShopPanelMilkShow.SetActive(true);
    }

    public void VegetablesProductsUnlock()
    {
        PriceVegetablesShow.SetActive(true);

        ShopPanelVegetablesShow.SetActive(true);
    }

    public void GrapesProductsUnlock()
    {
        PriceGrapesShow.SetActive(true);

        ShopPanelGrapesShow.SetActive(true);
    }

    #endregion

    #region ShowOnePrice

    public void ShowOnePrice()
    {
        HoWMuchThings = -1;
        HoWMuchMoney = ProductSellPrice;
    }

    #endregion

    #region HowMuch

    private void HowMuchMoneyText()
    {
        if(HoWMuchMoney > 0)
        {
            howMuchMoneyText.text = "+" + GameManager.Instance.CountText(HoWMuchMoney);
            howMuchMoneyText.color = new Color(0, 255, 0, 1);
        }
        else if(HoWMuchMoney < 0)
        {
            howMuchMoneyText.text = GameManager.Instance.CountText(HoWMuchMoney);
            howMuchMoneyText.color = new Color(255, 0, 0, 1);
        }
        else
        {
            howMuchMoneyText.text = GameManager.Instance.CountText(HoWMuchMoney);
            howMuchMoneyText.color = new Color(0, 0, 0, 1);
        }
    }

    private void HowMuchThingsText()
    {
        if(HoWMuchThings > 0)
        {
            howMuchThingsText.text = "+" + GameManager.Instance.CountText(HoWMuchThings);
            howMuchThingsText.color = new Color(0, 255, 0, 1);
        }
        else if(HoWMuchThings < 0)
        {
            howMuchThingsText.text = GameManager.Instance.CountText(HoWMuchThings);
            howMuchThingsText.color = new Color(255, 0, 0, 1);
        }
        else
        {
            howMuchThingsText.text = GameManager.Instance.CountText(HoWMuchThings);
            howMuchThingsText.color = new Color(0, 0, 0, 1);
        }
    }

    #endregion

    #region BuyButton

    public void BuyButton()
    {
        SoundManager.Instance.PlaySound(AcceptSound);

        switch(SelectedResource)
        {
            case 1:
                Debug.Log(SelectedResource);
                if(GameManager.Instance.money >= BuyMoney)
                {
                    GameManager.Instance.money -= BuyMoney;
                    Farm.wheets += BuyAmount;
                    BuyLock -= BuyAmount;
                    EventsScr.Instance.EventPopText("You have bought " + BuyAmount + " wheet for " + BuyMoney + " money!");
                    storeShow.WheetSelected();
                }
                break;
            case 2:
                Debug.Log(SelectedResource);
                if(GameManager.Instance.money >= BuyMoney)
                {
                    GameManager.Instance.money -= BuyMoney;
                    Farm.vegetables += BuyAmount;
                    BuyLock -= BuyAmount;
                    EventsScr.Instance.EventPopText("You have bought " + BuyAmount + " vegetables for " + BuyMoney + " money!");
                    storeShow.VegetablesSelected();
                }
                
                break;
            case 3:
                Debug.Log(SelectedResource);
                if(GameManager.Instance.money >= BuyMoney)
                {
                    GameManager.Instance.money -= BuyMoney;
                    Farm.grapes += BuyAmount;
                    BuyLock -= BuyAmount;
                    EventsScr.Instance.EventPopText("You have bought " + BuyAmount + " grapes for " + BuyMoney + " money!");
                    storeShow.GrapesSelected();
                }
                
                break;
            case 4:
                Debug.Log(SelectedResource);
                if(GameManager.Instance.money >= BuyMoney)
                {
                    GameManager.Instance.money -= BuyMoney;
                    Barn.eggs += BuyAmount;
                    BuyLock -= BuyAmount;
                    EventsScr.Instance.EventPopText("You have bought " + BuyAmount + " eggs for " + BuyMoney + " money!");
                    storeShow.EggsSelected();
                }
                
                break;
            case 5:
                Debug.Log(SelectedResource);
                if(GameManager.Instance.money >= BuyMoney)
                {
                    GameManager.Instance.money -= BuyMoney;
                    Barn.wool += BuyAmount;
                    BuyLock -= BuyAmount;
                    EventsScr.Instance.EventPopText("You have bought " + BuyAmount + " wool for " + BuyMoney + " money!");
                    storeShow.WoolSelected();
                }
                
                break;
            case 6:
                Debug.Log(SelectedResource);
                if(GameManager.Instance.money >= BuyMoney)
                {
                    GameManager.Instance.money -= BuyMoney;
                    Barn.milk += BuyAmount;
                    BuyLock -= BuyAmount;
                    EventsScr.Instance.EventPopText("You have bought " + BuyAmount + " milk for " + BuyMoney + " money!");
                    storeShow.MilkSelected();
                }
                
                break;
            case 7:
                Debug.Log(SelectedResource);
                if(GameManager.Instance.money >= BuyMoney)
                {
                    GameManager.Instance.money -= BuyMoney;
                    Barn.hens += BuyAmount;
                    BuyLock -= BuyAmount;
                    EventsScr.Instance.EventPopText("You have bought " + BuyAmount + " hens for " + BuyMoney + " money!");
                    storeShow.HensSelected();
                }
                
                break;
            case 8:
                Debug.Log(SelectedResource);
                if(GameManager.Instance.money >= BuyMoney)
                {
                    GameManager.Instance.money -= BuyMoney;
                    Barn.sheeps += BuyAmount;
                    BuyLock -= BuyAmount;
                    EventsScr.Instance.EventPopText("You have bought " + BuyAmount + " sheeps for " + BuyMoney + " money!");
                    storeShow.SheepsSelected();
                }
                
                break;
            case 9:
                Debug.Log(SelectedResource);
                if(GameManager.Instance.money >= BuyMoney)
                {
                    GameManager.Instance.money -= BuyMoney;
                    Barn.cows += BuyAmount;
                    BuyLock -= BuyAmount;
                    EventsScr.Instance.EventPopText("You have bought " + BuyAmount + " cows for " + BuyMoney + " money!");
                    storeShow.CowsSelected();
                }
                
                break;
            default:
                Debug.Log("No Selected Resource!");
                break;
        }

        
        if(BuyLock < 0)
            BuyLock = 0;

        Debug.Log("BuyLock: " + BuyLock);

    }

    #endregion

    #region SellButton

    public void SellButton()
    {
        SoundManager.Instance.PlaySound(AcceptSound);

        switch(SelectedResource)
        {
            case 1:
                Debug.Log(SelectedResource);
                if( Farm.wheets >= SellAmount)
                {
                    GameManager.Instance.money += SellMoney;
                    Farm.wheets -= SellAmount;
                    EventsScr.Instance.EventPopText("You have sold " + SellAmount + " wheet for " + SellMoney + " money!");
                    storeShow.WheetSelected();
                }
                
                break;
            case 2:
                Debug.Log(SelectedResource);
                if(Farm.vegetables >= SellAmount)
                {
                    GameManager.Instance.money += SellMoney;
                    Farm.vegetables -= SellAmount;
                    EventsScr.Instance.EventPopText("You have sold " + SellAmount + " vegetables for " + SellMoney + " money!");
                    storeShow.VegetablesSelected();
                }

                break;
            case 3:
                Debug.Log(SelectedResource);
                if(Farm.grapes >= SellAmount)
                {
                    GameManager.Instance.money += SellMoney;
                    Farm.grapes -= SellAmount;
                    EventsScr.Instance.EventPopText("You have sold " + SellAmount + " grapes for " + SellMoney + " money!");
                    storeShow.GrapesSelected();
                }

                break;
            case 4:
                Debug.Log(SelectedResource);
                if(Barn.eggs >= SellAmount)
                {
                    GameManager.Instance.money += SellMoney;
                    Barn.eggs -= SellAmount;
                    EventsScr.Instance.EventPopText("You have sold " + SellAmount + " eggs for " + SellMoney + " money!");
                    storeShow.EggsSelected();
                }

                break;
            case 5:
                Debug.Log(SelectedResource);
                if(Barn.wool >= SellAmount)
                {
                    GameManager.Instance.money += SellMoney;
                    Barn.wool -= SellAmount;
                    EventsScr.Instance.EventPopText("You have sold " + SellAmount + " wool for " + SellMoney + " money!");
                    storeShow.WoolSelected();
                }

                break;
            case 6:
                Debug.Log(SelectedResource);
                if(Barn.milk >= SellAmount)
                {
                    GameManager.Instance.money += SellMoney;
                    Barn.milk -= SellAmount;
                    EventsScr.Instance.EventPopText("You have sold " + SellAmount + " milk for " + SellMoney + " money!");
                    storeShow.MilkSelected();
                }

                break;
            case 7:
                Debug.Log(SelectedResource);
                if(Barn.hens >= SellAmount)
                {
                    GameManager.Instance.money += SellMoney;
                    Barn.hens -= SellAmount;
                    EventsScr.Instance.EventPopText("You have sold " + SellAmount + " hens for " + SellMoney + " money!");
                    storeShow.HensSelected();
                }

                break;
            case 8:
                Debug.Log(SelectedResource);
                if(Barn.sheeps >= SellAmount)
                {
                    GameManager.Instance.money += SellMoney;
                    Barn.sheeps -= SellAmount;
                    EventsScr.Instance.EventPopText("You have sold " + SellAmount + " sheeps for " + SellMoney + " money!");
                    storeShow.SheepsSelected();
                }

                break;
            case 9:
                Debug.Log(SelectedResource);
                if(Barn.cows >= SellAmount)
                {
                    GameManager.Instance.money += SellMoney;
                    Barn.cows -= SellAmount;
                    EventsScr.Instance.EventPopText("You have sold " + SellAmount + " cows for " + SellMoney + " money!");
                    storeShow.CowsSelected();
                }

                break;
            default:
                Debug.Log("No Selected Resource!");
                break;

        }

        if(SellButtonChoosen == 10)
            sellTenProcent();
        else if(SellButtonChoosen == 25)
            sellQuaterProcent();
        else if(SellButtonChoosen == 50)
            sellHalfProcent();
        else if(SellButtonChoosen == 100)
            sellFullProcent();

    }

    #endregion

    #region PriceList Show/Close

    public void ShowPriceList()
    {
        priceList.SetActive(true);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void ClosePriceList()
    {
        priceList.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region ClearNumbers

    public void ClearBuySellNumbers()
    {
        SellAmount = 0;
        SellMoney = 0;
        BuyAmount = 0;
        BuyMoney = 0;
        
        BuyNumber = 0;
    }

    #endregion

    #region Buy Amount Buttons

    public void buyOneProduct()
    {

        BuyNumber += 1;
        
        if(BuyNumber > BuyLock)
        {
            BuyNumber = BuyLock;
        }

        BuyMoney = ProductBuyPrice * BuyNumber;
        HoWMuchMoney = -BuyMoney;
        if(GameManager.Instance.money >= BuyMoney)
        {
            BuyAmount = BuyNumber;
            HoWMuchThings = BuyAmount;
        }
        else
        {
            HoWMuchThings = BuyNumber;
        }

        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void buyTwentyFiveProduct()
    {
        BuyNumber += 25;

        if(BuyNumber > BuyLock)
        {
            BuyNumber = BuyLock;
        }

        BuyMoney = ProductBuyPrice * BuyNumber;
        HoWMuchMoney = -BuyMoney;
        if(GameManager.Instance.money >= BuyMoney)
        {
            BuyAmount = BuyNumber;
            HoWMuchThings = BuyAmount;
        }
        else
        {
            HoWMuchThings = BuyNumber;
        }

        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void buyHundredProduct()
    {
        BuyNumber += 100;
        if(BuyNumber > BuyLock)
        {
            BuyNumber = BuyLock;
        }

        BuyMoney = ProductBuyPrice * BuyNumber;
        HoWMuchMoney = -BuyMoney;
        if(GameManager.Instance.money >= BuyMoney)
        {
            BuyAmount = BuyNumber;
            HoWMuchThings = BuyAmount;
        }
        else
        {
            HoWMuchThings = BuyNumber;
        }

        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void buyThousandProduct()
    {
        BuyNumber += 1000;
        if(BuyNumber > BuyLock)
        {
            BuyNumber = BuyLock;
        }

        BuyMoney = ProductBuyPrice * BuyNumber;
        HoWMuchMoney = -BuyMoney;
        if(GameManager.Instance.money >= BuyMoney)
        {
            BuyAmount = BuyNumber;
            HoWMuchThings = BuyAmount;
        }
        else
        {
            HoWMuchThings = BuyNumber;
        }

        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region Sell Amount Buttons

    public void sellTenProcent()
    {
        SellButtonChoosen = 10;

        if(Product > 0)
        {
            SellAmount = Product / 10;
            SellMoney = ProductSellPrice * SellAmount;
            HoWMuchMoney = SellMoney;
            HoWMuchThings = -SellAmount;
        }
        else
        {
            SellAmount = 0;
            SellMoney = 0;
            HoWMuchMoney = SellMoney;  
            HoWMuchThings = 0;
        }

        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void sellQuaterProcent()
    {
        SellButtonChoosen = 25;
        if(Product > 0)
        {
            SellAmount = Product / 4;
            SellMoney = ProductSellPrice * SellAmount;
            HoWMuchMoney = SellMoney;
            HoWMuchThings = -SellAmount;
        }
        else
        {
            SellAmount = 0;
            SellMoney = 0; 
            HoWMuchMoney = SellMoney; 
            HoWMuchThings = 0;
        }

        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void sellHalfProcent()
    {
        SellButtonChoosen = 50;
        if(Product > 0)
        {
            SellAmount = Product / 2;
            SellMoney = ProductSellPrice * SellAmount;
            HoWMuchMoney = SellMoney;
            HoWMuchThings = -SellAmount;
        }
        else
        {
            SellAmount = 0;
            SellMoney = 0;
            HoWMuchMoney = SellMoney;
            HoWMuchThings = 0;  
        }

        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void sellFullProcent()
    {
        SellButtonChoosen = 100;
        if(Product > 0)
        {
            SellAmount = Product;
            SellMoney = ProductSellPrice * SellAmount;
            HoWMuchMoney = SellMoney;
            HoWMuchThings = -SellAmount;
        }
        else
        {
            SellAmount = 0;
            SellMoney = 0;
            HoWMuchMoney = SellMoney;
            HoWMuchThings = 0;  
        }

        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion

    #region SellLeftovers

    public void SellTheLeftovers(int leftoversAmount, int LOProduct)
    {
        SellMoney = ProductSellPrice * leftoversAmount;
        Debug.Log("LeftoverAmount: " + leftoversAmount);
        Debug.Log("SellMoney: " + SellMoney);
        Debug.Log("ProductSellPrice: " + ProductSellPrice);

        switch(LOProduct)
        {
            case 1:
                GameManager.Instance.money += SellMoney;
                Barn.eggs -= leftoversAmount;
                EventsScr.Instance.EventPopText("You have sold " + leftoversAmount + " eggs for " + SellMoney + " money!");
                break;
            case 2:
                GameManager.Instance.money += SellMoney;
                Barn.wool -= leftoversAmount;
                EventsScr.Instance.EventPopText("You have sold " + leftoversAmount + " wool for " + SellMoney + " money!");
                break;
            case 3:
                GameManager.Instance.money += SellMoney;
                Barn.milk -= leftoversAmount;
                EventsScr.Instance.EventPopText("You have sold " + leftoversAmount + " milk for " + SellMoney + " money!");
                break;
            case 4:
                GameManager.Instance.money += SellMoney;
                Barn.hens -= leftoversAmount;
                EventsScr.Instance.EventPopText("You have sold " + leftoversAmount + " hens for " + SellMoney + " money!");
                break;
            case 5:
                GameManager.Instance.money += SellMoney;
                Barn.sheeps -= leftoversAmount;
                EventsScr.Instance.EventPopText("You have sold " + leftoversAmount + " sheeps for " + SellMoney + " money!");
                break;
            case 6:
                GameManager.Instance.money += SellMoney;
                Barn.cows -= leftoversAmount;
                EventsScr.Instance.EventPopText("You have sold " + leftoversAmount + " cows for " + SellMoney + " money!");
                break;
            default:
                break;
            
        }

        Debug.Log("Money: " + GameManager.Instance.money);

        Product = 0;
        SelectedResource = 0;
        SellMoney = 0;
        //ProductSellPrice = 0;
        //ProductBuyPrice = 0;
        
    }

    #endregion

}
