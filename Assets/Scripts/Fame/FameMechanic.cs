using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FameMechanic : MonoBehaviour
{
    public FameShow fameShow;
    
    public FarmScr farmScr;
    public BarnScr barnScr;
    public StoreScr storeScr;
    public ShopPrices shopPrices;
    public ContractsScr contractsScr;

    public HensScr hensScr;
    public SheepsScr sheepsScr;
    public CowsScr cowsScr;

    //public HasNewsScr newsScr;

    public FieldScr Field2;
    public FieldScr Field3;

    public GameObject barnShow;

    public GameObject ContractIsOpen;
    public GameObject WorkersIsOpen;

    public GameObject BarnUnlock;

    public GameObject WorkersUnlock;
    public GameObject ContractUnlock;

    public UnityEvent HensUnlockEvent;
    public UnityEvent CowsUnlockEvent;
    public UnityEvent SheepsUnlockEvent;

    public UnityEvent VegetablesUnlockEvent;
    public UnityEvent GrapesUnlockEvent;

    

    private bool fameLockReached1 = false;
    private bool fameLockReached2 = false;
    private bool fameLockReached3 = false;
    private bool fameLockReached4 = false;
    private bool fameLockReached5 = false;
    private bool fameLockReached6 = false;
    private bool fameLockReached7 = false;
    private bool fameLockReached8 = false;
    private bool fameLockReached9 = false;
    private bool fameLockReached10 = false;

    private bool fameLockReached11 = false;
    private bool fameLockReached12 = false;
    private bool fameLockReached13 = false;
    private bool fameLockReached14 = false;
    private bool fameLockReached15 = false;
    private bool fameLockReached16 = false;
    private bool fameLockReached17 = false;
    private bool fameLockReached18 = false;
    private bool fameLockReached19 = false;
    private bool fameLockReached20 = false;

    private void Start()
    {
        //HensUnlockEvent.AddListener(GameObject.FindGameObjectWithTag("BarnScr").GetComponent<BarnScr>().HensUnlock);
    }

    public void Update()
    {
        FameUnlock();
    }

    private void FameUnlock()
    {
        if(GameManager.Instance.fame >= fameShow.fameLock20) // All Prices Boost
        {
            if(!fameLockReached20)
            {
                shopPrices.InputWheetsSellPrice += 20;
                shopPrices.InputVegetablesSellPrice += 20;
                shopPrices.InputGrapesSellPrice += 20;

                shopPrices.InputEggsSellPrice += 20;
                shopPrices.InputWoolSellPrice += 20;
                shopPrices.InputMilkSellPrice += 20;

                shopPrices.InputHensSellPrice += 20;
                shopPrices.InputSheepsSellPrice += 20;
                shopPrices.InputCowsSellPrice += 20;

                shopPrices.InputWheetsBuyPrice -= 20;
                shopPrices.InputVegetablesBuyPrice -= 20;
                shopPrices.InputGrapesBuyPrice -= 20;

                shopPrices.InputEggsBuyPrice -= 20;
                shopPrices.InputWoolBuyPrice -= 20;
                shopPrices.InputMilkBuyPrice -= 20;

                shopPrices.InputHensBuyPrice -= 20;
                shopPrices.InputSheepsBuyPrice -= 20;
                shopPrices.InputCowsBuyPrice -= 20;

                EventsScr.Instance.EventPopText("Fame Reached! (+20 all prices boost)");
            }
            
            fameLockReached20 = true;

            // +fame boost prices
        }

        if(GameManager.Instance.fame >= fameShow.fameLock19) // All Fertility Boost
        {
            if(!fameLockReached19)
            {
                farmScr.wheetFertilityInput += 20;
                farmScr.vegsFertilityInput += 20;
                farmScr.grapesFertilityInput += 20;

                hensScr.EggsBoost += 20;
                sheepsScr.woolMult += 20;
                cowsScr.milkMult += 20;

                EventsScr.Instance.EventPopText("Fame Reached! (+20 all prods boost)");
            }
            
            fameLockReached19 = true;
            // +fame boost production
        }
        if(GameManager.Instance.fame >= fameShow.fameLock18)
        {
            // +1000 animals cap
            if(!fameLockReached18)
            {
                GameManager.Instance.techPlusAmount += 10;
                EventsScr.Instance.EventPopText("Fame Reached! (+10 tech by turn)");
            }

            fameLockReached18 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock17)
        {
            if(!fameLockReached17)
            {
                GameManager.Instance.famePlusAmount += 10;
                EventsScr.Instance.EventPopText("Fame Reached! (+10 fame by turn)");
            }

            fameLockReached17 = true;
            
        }
        if(GameManager.Instance.fame >= fameShow.fameLock16)
        {
            // + field 3
            if(!fameLockReached16)
            {
                Field3.fameUnlock.SetActive(false);
                Field3.FieldIsActive = true;
                EventsScr.Instance.EventPopText("Fame reached! (Field 3)");
            }
            fameLockReached16 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock15)
        {
            // grapes unlock
            if(!fameLockReached15)
            {
                GrapesUnlockEvent.Invoke();
                contractsScr.CanChooseRes ++;
                EventsScr.Instance.EventPopText("Fame reached! (Grapes Unlocked)");
            }

            fameLockReached15 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock14) // AUTOBREED
        {
            // +3 mech
            if(!fameLockReached14)
            {
                EventsScr.Instance.EventPopText("Fame reached! (Auto-Breed Animals Unlocked)");
            }
            
            fameLockReached14 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock13)
        {
            // + 3 prices boost
            if(!fameLockReached13)
            {
                GameManager.Instance.techPlusAmount += 3;
                EventsScr.Instance.EventPopText("Fame reached! (+3 tech by turn)");
                //shopPrices.PricesBoost += 3;
                //shopPrices.PricesBoosted();
            }

            fameLockReached13 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock12)
        {
            // sheeps unlock
            if(!fameLockReached12)
            {
                SheepsUnlockEvent.Invoke();
                contractsScr.CanChooseRes ++;
                EventsScr.Instance.EventPopText("Fame reached! (Sheeps Unlocked)");
            }

            fameLockReached12 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock11)
        {
            // +3 fame
            if(!fameLockReached11)
            {
                GameManager.Instance.famePlusAmount += 3;
                EventsScr.Instance.EventPopText("Fame reached! (+3 fame by turn)");
            }
            
            fameLockReached11 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock10) // AUTO FEED
        {
            if(!fameLockReached10)
                EventsScr.Instance.EventPopText("Fame reached! (Auto-Feed Animals Unlocked)");

            fameLockReached10 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock9)
        {
            // cows unlock
            if(!fameLockReached9)
            {
                CowsUnlockEvent.Invoke();
                contractsScr.CanChooseRes ++;
                EventsScr.Instance.EventPopText("Fame reached! (Cows Unlocked)");
            }

            fameLockReached9 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock8) // AUTOHARVEST
        {
            // +1300 field
            if(!fameLockReached8)
            {
                
                EventsScr.Instance.EventPopText("Fame reached! (Auto-Harvest Unlocked)");
            }
            
            fameLockReached8 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock7)
        {
            // + 2 max fertility
            if(!fameLockReached7)
            {
                Field2.fameUnlock.SetActive(false);
                Field2.FieldIsActive = true;
                EventsScr.Instance.EventPopText("Fame reached! (Field 2 Unlocked)");
            }
            fameLockReached7 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock6)
        {
            // veg unlock
            if(!fameLockReached6)
            {
                VegetablesUnlockEvent.Invoke();
                contractsScr.CanChooseRes ++;
                EventsScr.Instance.EventPopText("Fame reached! (Vegetables Unlocked)");
            }

            fameLockReached6 = true;
            
        }
        if(GameManager.Instance.fame >= fameShow.fameLock5)
        {
            // + 2 prices boost
            if(!fameLockReached5)
            {
                WorkersUnlock.SetActive(false);
                AlertsScr.Instance.HouseAlertObj.SetActive(true);
                EventsScr.Instance.EventPopText("Fame reached! (Workers Hut Unlocked)");
            }

            fameLockReached5 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock4) // AUTO Plant
        {
            // +1 fame
            if(!fameLockReached4)
            {
                GameManager.Instance.famePlusAmount = GameManager.Instance.famePlusAmount + 2;
                EventsScr.Instance.EventPopText("Fame reached! (+2 fame by turn)");
                
                //GameManager.Instance.famePlusAmount ++; AUTO PLANT
                //EventsScr.Instance.EventPopText("You reached next fame point! (+1 tech by turn)");
            }
            
            fameLockReached4 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock3)
        {
            // hens unlock
            if(!fameLockReached3)
            {
                BarnUnlock.SetActive(false);
                barnScr.BarnIsActivated = true;
                HensUnlockEvent.Invoke();
                contractsScr.CanChooseRes ++;
                EventsScr.Instance.EventPopText("Fame reached! (Hens Unlocked)");
            }

            fameLockReached3 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock2)
        {
            // + 1 mech
            if(!fameLockReached2)
            {
                
                GameManager.Instance.techPlusAmount = GameManager.Instance.techPlusAmount + 2;
                EventsScr.Instance.EventPopText("Fame reached! (+2 tech by turn)");
            }
            
            fameLockReached2 = true;
        }
        if(GameManager.Instance.fame >= fameShow.fameLock1)
        {
            if(!fameLockReached1)
            {
                ContractUnlock.SetActive(false);
                AlertsScr.Instance.HouseAlertObj.SetActive(true);
                EventsScr.Instance.EventPopText("Fame reached! (Contracts Unlocked)");

            }
            
            fameLockReached1 = true;
            // fame increse prices
        }
    }
}
