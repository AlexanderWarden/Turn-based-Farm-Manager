using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreShow : MonoBehaviour
{
    public FarmScr Farm;
    public BarnScr Barn;
    public StoreScr Store;
    public ShopPrices shopPrices;

    public TextMeshProUGUI wheetsText;
    public TextMeshProUGUI vegetablesText;
    public TextMeshProUGUI grapesText;

    public TextMeshProUGUI eggsText;
    public TextMeshProUGUI woolText;
    public TextMeshProUGUI milkText;

    public TextMeshProUGUI hensText;
    public TextMeshProUGUI sheepsText;
    public TextMeshProUGUI cowsText;

    public TextMeshProUGUI moneyText;


    public GameObject ProductsMarketScreen;
    public GameObject AnimalsMarketScreen;

    public GameObject ProductsMarketButton;
    public GameObject AnimalsMarketButton;
    

    public GameObject SelectProductObj;

    public GameObject ThingsWheets;
    public GameObject ThingsVegs;
    public GameObject ThingsGrapes;
    public GameObject ThingsEggs;
    public GameObject ThingsWool;
    public GameObject ThingsMilk;
    public GameObject ThingsHens;
    public GameObject ThingsSheeps;
    public GameObject ThingsCows;

    public AudioClip AcceptSound;

    private void Update()
    {
        wheetsText.text = GameManager.Instance.CountText(Farm.wheets);
        vegetablesText.text = GameManager.Instance.CountText(Farm.vegetables);
        grapesText.text = GameManager.Instance.CountText(Farm.grapes);

        eggsText.text = GameManager.Instance.CountText(Barn.eggs);
        woolText.text = GameManager.Instance.CountText(Barn.wool);
        milkText.text = GameManager.Instance.CountText(Barn.milk);

        hensText.text = GameManager.Instance.CountText(Barn.hens);
        sheepsText.text = GameManager.Instance.CountText(Barn.sheeps);
        cowsText.text = GameManager.Instance.CountText(Barn.cows);

        moneyText.text = GameManager.Instance.CountText(GameManager.Instance.money);
    }

    public void SelectedObjectOnWithTurn()
    {
        SelectProductObj.SetActive(true);
    }

    public void CloseAllIcons()
    {
        ThingsWheets.SetActive(false);
        ThingsVegs.SetActive(false);
        ThingsGrapes.SetActive(false);
        ThingsEggs.SetActive(false);
        ThingsWool.SetActive(false);
        ThingsMilk.SetActive(false);
        ThingsHens.SetActive(false);
        ThingsSheeps.SetActive(false);
        ThingsCows.SetActive(false);
    }

    public void MarketSwapAnimals()
    {
        AnimalsMarketScreen.SetActive(true);
        ProductsMarketButton.SetActive(true);

        AnimalsMarketButton.SetActive(false);
        ProductsMarketScreen.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void MarketSwapProducts()
    {
        AnimalsMarketButton.SetActive(true);
        ProductsMarketScreen.SetActive(true);

        AnimalsMarketScreen.SetActive(false);
        ProductsMarketButton.SetActive(false);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void WheetSelected()
    {
        CloseAllIcons();
        SelectProductObj.SetActive(false);
        Store.ClearBuySellNumbers();

        ThingsWheets.SetActive(true);
    
        Store.SelectedResource = 1;
        Store.Product = Farm.wheets;
        Store.ProductSellPrice = shopPrices.WheetsSellPrice;
        Store.ProductBuyPrice = shopPrices.WheetsBuyPrice;
        Store.ShowOnePrice();
        SoundManager.Instance.PlaySound(AcceptSound);
        
    }

    public void VegetablesSelected()
    {
        CloseAllIcons();
        SelectProductObj.SetActive(false);
        Store.ClearBuySellNumbers();

        ThingsVegs.SetActive(true);

        Store.SelectedResource = 2;
        Store.Product = Farm.vegetables;
        Store.ProductSellPrice = shopPrices.VegetablesSellPrice;
        Store.ProductBuyPrice = shopPrices.VegetablesBuyPrice;
        Store.ShowOnePrice();
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void GrapesSelected()
    {
        CloseAllIcons();
        SelectProductObj.SetActive(false);
        Store.ClearBuySellNumbers();

        ThingsGrapes.SetActive(true);

        Store.SelectedResource = 3;
        Store.Product = Farm.grapes;
        Store.ProductSellPrice = shopPrices.GrapesSellPrice;
        Store.ProductBuyPrice = shopPrices.GrapesBuyPrice;
        Store.ShowOnePrice();
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void EggsSelected()
    {
        CloseAllIcons();
        SelectProductObj.SetActive(false);
        Store.ClearBuySellNumbers();

        ThingsEggs.SetActive(true);

        Store.SelectedResource = 4;
        Store.Product = Barn.eggs;
        Store.ProductSellPrice = shopPrices.EggsSellPrice;
        Store.ProductBuyPrice = shopPrices.EggsBuyPrice;
        Store.ShowOnePrice();
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void WoolSelected()
    {
        CloseAllIcons();
        SelectProductObj.SetActive(false);
        Store.ClearBuySellNumbers();

        ThingsWool.SetActive(true);

        Store.SelectedResource = 5;
        Store.Product = Barn.wool;
        Store.ProductSellPrice = shopPrices.WoolSellPrice;
        Store.ProductBuyPrice = shopPrices.WoolBuyPrice;
        Store.ShowOnePrice();
        SoundManager.Instance.PlaySound(AcceptSound);
        
    }

    public void MilkSelected()
    {
        CloseAllIcons();
        SelectProductObj.SetActive(false);
        Store.ClearBuySellNumbers();

        ThingsMilk.SetActive(true);

        Store.SelectedResource = 6;
        Store.Product = Barn.milk;
        Store.ProductSellPrice = shopPrices.MilkSellPrice;
        Store.ProductBuyPrice = shopPrices.MilkBuyPrice;
        Store.ShowOnePrice();
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void HensSelected()
    {
        CloseAllIcons();
        SelectProductObj.SetActive(false);
        Store.ClearBuySellNumbers();

        ThingsHens.SetActive(true);

        Store.SelectedResource = 7;
        Store.Product = Barn.hens;
        Store.ProductSellPrice = shopPrices.HensSellPrice;
        Store.ProductBuyPrice = shopPrices.HensBuyPrice;
        Store.ShowOnePrice();
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void SheepsSelected()
    {
        CloseAllIcons();
        SelectProductObj.SetActive(false);
        Store.ClearBuySellNumbers();

        ThingsSheeps.SetActive(true);

        Store.SelectedResource = 8;
        Store.Product = Barn.sheeps;
        Store.ProductSellPrice = shopPrices.SheepsSellPrice;
        Store.ProductBuyPrice = shopPrices.SheepsBuyPrice;
        Store.ShowOnePrice();
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void CowsSelected()
    {
        CloseAllIcons();
        SelectProductObj.SetActive(false);
        Store.ClearBuySellNumbers();

        ThingsCows.SetActive(true);

        Store.SelectedResource = 9;
        Store.Product = Barn.cows;
        Store.ProductSellPrice = shopPrices.CowsSellPrice;
        Store.ProductBuyPrice = shopPrices.CowsBuyPrice;
        Store.ShowOnePrice();
        Debug.Log("ProductSellPrice: " + Store.ProductSellPrice);
        Debug.Log(shopPrices.CowsSellPrice);
        SoundManager.Instance.PlaySound(AcceptSound);
    }
}
