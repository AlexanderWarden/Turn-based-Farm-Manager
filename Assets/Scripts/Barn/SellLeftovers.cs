using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellLeftovers : MonoBehaviour
{
    public StoreShow storeShow;
    public StoreScr storeScr;
    public ShopPrices shopPrices;

    public int SellPrice;

    public void LeftoversTransfer(int leftoversAmount, int numberOfLeftovers)
    {
        switch(numberOfLeftovers)
        {
            case 1:
                storeScr.ProductSellPrice = shopPrices.EggsSellPrice;
                storeScr.SellTheLeftovers(leftoversAmount, 1);
                Debug.Log("Eggs Chosen!");
                break;
            case 2:
                storeScr.ProductSellPrice = shopPrices.WoolSellPrice;
                storeScr.SellTheLeftovers(leftoversAmount, 2);
                break;
            case 3:
                storeScr.ProductSellPrice = shopPrices.MilkSellPrice;
                storeScr.SellTheLeftovers(leftoversAmount, 3);
                break;
            case 4:
                storeScr.ProductSellPrice = shopPrices.HensSellPrice;
                storeScr.SellTheLeftovers(leftoversAmount, 4);
                break;
            case 5:
                storeScr.ProductSellPrice = shopPrices.SheepsSellPrice;
                storeScr.SellTheLeftovers(leftoversAmount, 5);
                break;
            case 6:
                storeScr.ProductSellPrice = shopPrices.CowsSellPrice;
                storeScr.SellTheLeftovers(leftoversAmount, 6);
                break;
            default:
                break;
        }
    }

}
