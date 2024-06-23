using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerFarmers : MonoBehaviour
{
    [Header("Scripts")]
    public FarmScr farmScr;
    public FieldScr Field1;
    public FieldScr Field2;
    public FieldScr Field3;

    public WorkerLivestock WL;

    [Header("Farmers Activation Vars")]

    public bool isFarmersActive = true;
    public bool isFarmersOpen = false;

    [Header("Field1")]

    private bool Field1WheetIsChoosen = false;
    private bool Field1VegsIsChoosen = false;
    private bool Field1GrapesIsChoosen = false;

    private bool Field1WheetIsPlanted = false;
    private bool Field1VegsIsPlanted = false;
    private bool Field1GrapesIsPlanted = false;

    public Image Field1WheetImageSelected;
    public Image Field1VegsImageSelected;
    public Image Field1GrapesImageSelected;

    private bool Field1Choosen = false; 
    private bool Field1IsPlanted = false;

    [Header("Field2")]

    private bool Field2WheetIsChoosen = false;
    private bool Field2VegsIsChoosen = false;
    private bool Field2GrapesIsChoosen = false;

    private bool Field2WheetIsPlanted = false;
    private bool Field2VegsIsPlanted = false;
    private bool Field2GrapesIsPlanted = false;

    public Image Field2WheetImageSelected;
    public Image Field2VegsImageSelected;
    public Image Field2GrapesImageSelected;

    private bool Field2Choosen = false;
    private bool Field2IsPlanted = false;

    [Header("Field3")]

    private bool Field3WheetIsChoosen = false;
    private bool Field3VegsIsChoosen = false;
    private bool Field3GrapesIsChoosen = false;

    private bool Field3WheetIsPlanted = false;
    private bool Field3VegsIsPlanted = false;
    private bool Field3GrapesIsPlanted = false;

    public Image Field3WheetImageSelected;
    public Image Field3VegsImageSelected;
    public Image Field3GrapesImageSelected;

    private bool Field3Choosen = false;

    private bool Field3IsPlanted = false;

    public int FarmersCost;

    public bool PlantIsActive = false;
    public bool HarvestIsActive = false;

    public Image PlantButtonImageSelected;
    public Image HarvestButtonImageSelected;

    public AudioClip AcceptSound;

    #region Update

    private void Update()
    {
        if(isFarmersActive)
            CheckForHarvest();
        
        if(!isFarmersActive)
        {
            FarmersIsInactive();
        }
            
    }

    #endregion

    private void DoubleCost(bool plus)
    {
        int PlantFullCost = 0;
        int HarvestFullCost = 0;

        if(PlantIsActive)
        {
            if(Field1Choosen)
            {
                PlantFullCost += 5000;
            }
            if(Field2Choosen)
            {
                PlantFullCost += 5000;
            }
            if(Field3Choosen)
            {
                PlantFullCost += 5000;
            }

            /*if(true)
                WL.SpendMoney += PlantFullCost;
            else
                WL.SpendMoney -= PlantFullCost;*/
            
        }
        if(HarvestIsActive)
        {
            if(Field1Choosen)
            {
                HarvestFullCost += 5000;
            }
            if(Field2Choosen)
            {
                HarvestFullCost += 5000;
            }
            if(Field3Choosen)
            {
                HarvestFullCost += 5000;
            }

            /*if(true)
                WL.SpendMoney += HarvestFullCost;
            else
                WL.SpendMoney -= HarvestFullCost;*/
        }
        
    }

    private void FarmersIsInactive()
    {
        Field1Choosen = false;
        Field2Choosen = false;
        Field3Choosen = false;

        Field1WheetIsChoosen = false;
        Field1VegsIsChoosen = false;
        Field1GrapesIsChoosen = false;

        Field2WheetIsChoosen = false;
        Field2VegsIsChoosen = false;
        Field2GrapesIsChoosen = false;

        Field3WheetIsChoosen = false;
        Field3VegsIsChoosen = false;
        Field3GrapesIsChoosen = false;

        Field1WheetImageSelected.color = new Color(255, 0, 0, 255);
        Field1VegsImageSelected.color = new Color(255, 0, 0, 255);
        Field1GrapesImageSelected.color = new Color(255, 0, 0, 255);

        Field2WheetImageSelected.color = new Color(255, 0, 0, 255);
        Field2VegsImageSelected.color = new Color(255, 0, 0, 255);
        Field2GrapesImageSelected.color = new Color(255, 0, 0, 255);

        Field3WheetImageSelected.color = new Color(255, 0, 0, 255);
        Field3VegsImageSelected.color = new Color(255, 0, 0, 255);
        Field3GrapesImageSelected.color = new Color(255, 0, 0, 255);

    }

    #region Plant Logic

    public void Field1AutoPlant()
    {
        if(isFarmersActive && PlantIsActive)
        {
            
            if(Field1WheetIsChoosen && !Field1.FieldIsPlanted)
            {
                if(GameManager.Instance.money >= FarmersCost)
                    GameManager.Instance.money -= FarmersCost;
                else
                {
                    isFarmersActive = false;
                    return;
                }

                AutomaticField1Plant(1);
                Field1.FieldIsPlanted = true;

                //TurnRecap.Instance.GetTextStrings("Planted: " + wheetsScr.SeedsAmount + " wheet");
                //EventsScr.Instance.EventPopText("Your farmers are planted: " + wheetsScr.SeedsAmount + " wheet");
                
            }
            else if(Field1VegsIsChoosen && !Field1.FieldIsPlanted)
            {
                if(GameManager.Instance.money >= FarmersCost)
                    GameManager.Instance.money -= FarmersCost;
                else
                {
                    isFarmersActive = false;
                    return;
                }

                AutomaticField1Plant(2);
                Field1.FieldIsPlanted = true;
                //TurnRecap.Instance.GetTextStrings("Planted: " + vegetablesScr.SeedsAmount + " vegs");
                //EventsScr.Instance.EventPopText("Your farmers are planted: " + vegetablesScr.SeedsAmount + " vegs");
                
            }
            else if(Field1GrapesIsChoosen && !Field1.FieldIsPlanted)
            {
                if(GameManager.Instance.money >= FarmersCost)
                    GameManager.Instance.money -= FarmersCost;
                else
                {
                    isFarmersActive = false;
                    return;
                }

                AutomaticField1Plant(3);
                Field1.FieldIsPlanted = true;
                //TurnRecap.Instance.GetTextStrings("Planted: " + grapesScr.SeedsAmount + " grapes");
                //EventsScr.Instance.EventPopText("Your farmers are planted: " + grapesScr.SeedsAmount + " grapes");
                
            }  
        }
    }

    public void Field2AutoPlant()
    {
        if(isFarmersActive && Field2.FieldIsActive && PlantIsActive)
        {
            
            if(Field2WheetIsChoosen && !Field2.FieldIsPlanted)
            {
                if(GameManager.Instance.money >= FarmersCost)
                    GameManager.Instance.money -= FarmersCost;
                else
                {
                    isFarmersActive = false;
                    return;
                }

                AutomaticField2Plant(1);
                Field2.FieldIsPlanted = true;

                //TurnRecap.Instance.GetTextStrings("Planted: " + wheetsScr.SeedsAmount + " wheet");
                //EventsScr.Instance.EventPopText("Your farmers are planted: " + wheetsScr.SeedsAmount + " wheet");
                
            }
            else if(Field2VegsIsChoosen && !Field2.FieldIsPlanted)
            {
                if(GameManager.Instance.money >= FarmersCost)
                    GameManager.Instance.money -= FarmersCost;
                else
                {
                    isFarmersActive = false;
                    return;
                }

                AutomaticField2Plant(2);
                Field2.FieldIsPlanted = true;
                //TurnRecap.Instance.GetTextStrings("Planted: " + vegetablesScr.SeedsAmount + " vegs");
                //EventsScr.Instance.EventPopText("Your farmers are planted: " + vegetablesScr.SeedsAmount + " vegs");
                
            }
            else if(Field2GrapesIsChoosen && !Field2.FieldIsPlanted)
            {
                if(GameManager.Instance.money >= FarmersCost)
                    GameManager.Instance.money -= FarmersCost;
                else
                {
                    isFarmersActive = false;
                    return;
                }

                AutomaticField2Plant(3);
                Field2.FieldIsPlanted = true;
                //TurnRecap.Instance.GetTextStrings("Planted: " + grapesScr.SeedsAmount + " grapes");
                //EventsScr.Instance.EventPopText("Your farmers are planted: " + grapesScr.SeedsAmount + " grapes");
                
            }  
        }
    }

    public void Field3AutoPlant()
    {
        if(isFarmersActive && Field3.FieldIsActive && PlantIsActive)
        {
            
            if(Field3WheetIsChoosen && !Field3.FieldIsPlanted)
            {
                if(GameManager.Instance.money >= FarmersCost)
                    GameManager.Instance.money -= FarmersCost;
                else
                {
                    isFarmersActive = false;
                    return;
                }

                AutomaticField3Plant(1);
                Field3.FieldIsPlanted = true;

                //TurnRecap.Instance.GetTextStrings("Planted: " + wheetsScr.SeedsAmount + " wheet");
                //EventsScr.Instance.EventPopText("Your farmers are planted: " + wheetsScr.SeedsAmount + " wheet");
                
            }
            else if(Field3VegsIsChoosen && !Field3.FieldIsPlanted)
            {
                if(GameManager.Instance.money >= FarmersCost)
                    GameManager.Instance.money -= FarmersCost;
                else
                {
                    isFarmersActive = false;
                    return;
                }

                AutomaticField3Plant(2);
                Field3.FieldIsPlanted = true;
                //TurnRecap.Instance.GetTextStrings("Planted: " + vegetablesScr.SeedsAmount + " vegs");
                //EventsScr.Instance.EventPopText("Your farmers are planted: " + vegetablesScr.SeedsAmount + " vegs");
                
            }
            else if(Field3GrapesIsChoosen && !Field3.FieldIsPlanted)
            {
                if(GameManager.Instance.money >= FarmersCost)
                    GameManager.Instance.money -= FarmersCost;
                else
                {
                    isFarmersActive = false;
                    return;
                }

                AutomaticField3Plant(3);
                Field3.FieldIsPlanted = true;
                //TurnRecap.Instance.GetTextStrings("Planted: " + grapesScr.SeedsAmount + " grapes");
                //EventsScr.Instance.EventPopText("Your farmers are planted: " + grapesScr.SeedsAmount + " grapes");
                
            }  
        }
    }

    #endregion

    #region Auto Functions

    private void AutomaticField1Plant(int prod)
    {
        switch(prod)
        {
            case 1:
                Field1.WheetChoosen();
                break;
            case 2:
                Field1.VegsChoosen();
                break;
            case 3:
                Field1.GrapesChoosen();
                break;
            default:
                break;
        }

        Field1.SeedsAmountFull();
        Field1.SeedsAmountPlant();

    }

    private void AutomaticField2Plant(int prod)
    {
        switch(prod)
        {
            case 1:
                Field2.WheetChoosen();
                break;
            case 2:
                Field2.VegsChoosen();
                break;
            case 3:
                Field2.GrapesChoosen();
                break;
            default:
                break;
        }

        Field2.SeedsAmountFull();
        Field2.SeedsAmountPlant();

    }

    private void AutomaticField3Plant(int prod)
    {
        switch(prod)
        {
            case 1:
                Field3.WheetChoosen();
                break;
            case 2:
                Field3.VegsChoosen();
                break;
            case 3:
                Field3.GrapesChoosen();
                break;
            default:
                break;
        }

        Field3.SeedsAmountFull();
        Field3.SeedsAmountPlant();

    }

    #endregion

    #region Choose Buttons

    public void PlantChoosen()
    {
        if(!isFarmersActive)
            isFarmersActive = true;
        
        if(!PlantIsActive)
        {
            if(HarvestIsActive)
                DoubleCost(true);
            PlantIsActive = true;
            PlantButtonImageSelected.color = new Color(0, 255, 0, 255);
            SoundManager.Instance.PlaySound(AcceptSound);

        }
        else
        {
            PlantIsActive = false;
            PlantButtonImageSelected.color = new Color(255, 0, 0, 255);
            if(HarvestIsActive)
                DoubleCost(false);
            
            SoundManager.Instance.PlaySound(AcceptSound);
        }
    }

    public void HarvestChoosen()
    {
        if(!isFarmersActive)
            isFarmersActive = true;
        
        if(!HarvestIsActive)
        {
            if(PlantIsActive)
                DoubleCost(true);
            HarvestIsActive = true;
            HarvestButtonImageSelected.color = new Color(0, 255, 0, 255);
            SoundManager.Instance.PlaySound(AcceptSound);
        }
        else
        {
            HarvestIsActive = false;
            HarvestButtonImageSelected.color = new Color(255, 0, 0, 255);
            if(PlantIsActive)
                DoubleCost(false);

            SoundManager.Instance.PlaySound(AcceptSound);
        }
    }

    // Field 1

    public void Field1ChooseWheet()
    {
        if(!isFarmersActive)
            isFarmersActive = true;

        if(!Field1WheetIsChoosen)
        {

            Field1WheetIsChoosen = true;
            Field1WheetImageSelected.color = new Color(0, 255, 0, 255);
            if(!Field1Choosen)
            {
                /*if(HarvestIsActive && PlantIsActive)
                    WL.SpendMoney += 10000;
                else if(!HarvestIsActive && !PlantIsActive)
                    Debug.Log("Nothing Is Choosen!");
                else
                    WL.SpendMoney += 5000;*/
            }
                
            Field1Choosen = true;


        }
        else
        {
            Field1WheetIsChoosen = false;
            Field1WheetImageSelected.color = new Color(255, 0, 0, 255);
            Field1Choosen = false;

            /*if(HarvestIsActive && PlantIsActive)
                WL.SpendMoney -= 10000;
            else if(!HarvestIsActive && !PlantIsActive)
                Debug.Log("Nothing Is Choosen!");
            else
                WL.SpendMoney -= 5000;*/
        }
            
        Field1VegsIsChoosen = false;
        Field1GrapesIsChoosen = false;

        
        Field1VegsImageSelected.color = new Color(255, 0, 0, 255);
        Field1GrapesImageSelected.color = new Color(255, 0, 0, 255);
        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void Field1ChooseVegs()
    {
        if(!isFarmersActive)
            isFarmersActive = true;
        
        if(!Field1VegsIsChoosen)
        {
            Field1VegsIsChoosen = true;
            Field1VegsImageSelected.color = new Color(0, 255, 0, 255);
            if(!Field1Choosen)
            {
                /*if(HarvestIsActive && PlantIsActive)
                    WL.SpendMoney += 10000;
                else if(!HarvestIsActive && !PlantIsActive)
                    Debug.Log("Nothing Is Choosen!");
                else
                    WL.SpendMoney += 5000;*/
            }
            Field1Choosen = true;
            
        }
        else
        {
            Field1VegsIsChoosen = false;
            Field1VegsImageSelected.color = new Color(255, 0, 0, 255);
            Field1Choosen = false;
            /*if(HarvestIsActive && PlantIsActive)
                WL.SpendMoney -= 10000;
            else if(!HarvestIsActive && !PlantIsActive)
                Debug.Log("Nothing Is Choosen!");
            else
                WL.SpendMoney -= 5000;*/
        }

        Field1WheetIsChoosen = false;
        Field1GrapesIsChoosen = false;

        Field1WheetImageSelected.color = new Color(255, 0, 0, 255);
        Field1GrapesImageSelected.color = new Color(255, 0, 0, 255);
        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void Field1ChooseGrapes()
    {
        if(!isFarmersActive)
            isFarmersActive = true;
        
        if(!Field1GrapesIsChoosen)
        {
            Field1GrapesIsChoosen = true;
            Field1GrapesImageSelected.color = new Color(0, 255, 0, 255);
            if(!Field1Choosen)
            {
                /*if(HarvestIsActive && PlantIsActive)
                    WL.SpendMoney += 10000;
                else if(!HarvestIsActive && !PlantIsActive)
                    Debug.Log("Nothing Is Choosen!");
                else
                    WL.SpendMoney += 5000;*/
            }
            Field1Choosen = true;
        }
        else
        {
            Field1GrapesIsChoosen = false;
            Field1GrapesImageSelected.color = new Color(255, 0, 0, 255);
            Field1Choosen = false;
            /*if(HarvestIsActive && PlantIsActive)
                WL.SpendMoney -= 10000;
            else if(!HarvestIsActive && !PlantIsActive)
                Debug.Log("Nothing Is Choosen!");
            else
                WL.SpendMoney -= 5000;*/
        }

        Field1WheetIsChoosen = false;
        Field1VegsIsChoosen = false;

        Field1WheetImageSelected.color = new Color(255, 0, 0, 255);
        Field1VegsImageSelected.color = new Color(255, 0, 0, 255);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    // Field 2

    public void Field2ChooseWheet()
    {
        if(!isFarmersActive)
            isFarmersActive = true;
        
        if(!Field2WheetIsChoosen)
        {
            Field2WheetIsChoosen = true;
            Field2WheetImageSelected.color = new Color(0, 255, 0, 255);
            if(!Field2Choosen)
            {
                /*if(HarvestIsActive && PlantIsActive)
                    WL.SpendMoney += 10000;
                else if(!HarvestIsActive && !PlantIsActive)
                    Debug.Log("Nothing Is Choosen!");
                else
                    WL.SpendMoney += 5000;*/
            }
            Field2Choosen = true;

        }
        else
        {
            Field2WheetIsChoosen = false;
            Field2WheetImageSelected.color = new Color(255, 0, 0, 255);
            Field2Choosen = false;
            /*if(HarvestIsActive && PlantIsActive)
                WL.SpendMoney -= 10000;
            else if(!HarvestIsActive && !PlantIsActive)
                Debug.Log("Nothing Is Choosen!");
            else
                WL.SpendMoney -= 5000;*/
        }

        Field2VegsIsChoosen = false;
        Field2GrapesIsChoosen = false;

        Field2VegsImageSelected.color = new Color(255, 0, 0, 255);
        Field2GrapesImageSelected.color = new Color(255, 0, 0, 255);
        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void Field2ChooseVegs()
    {
        if(!isFarmersActive)
            isFarmersActive = true;
        
        if(!Field2VegsIsChoosen)
        {
            Field2VegsIsChoosen = true;
            Field2VegsImageSelected.color = new Color(0, 255, 0, 255);
            if(!Field2Choosen)
            {
                /*if(HarvestIsActive && PlantIsActive)
                    WL.SpendMoney += 10000;
                else if(!HarvestIsActive && !PlantIsActive)
                    Debug.Log("Nothing Is Choosen!");
                else
                    WL.SpendMoney += 5000;*/
            }
            Field2Choosen = true;
        }
        else
        {
            Field2VegsIsChoosen = false;
            Field2VegsImageSelected.color = new Color(255, 0, 0, 255);
            Field2Choosen = false;
            /*if(HarvestIsActive && PlantIsActive)
                WL.SpendMoney -= 10000;
            else if(!HarvestIsActive && !PlantIsActive)
                Debug.Log("Nothing Is Choosen!");
            else
                WL.SpendMoney -= 5000;*/
        }

        Field2WheetIsChoosen = false;
        Field2GrapesIsChoosen = false;

        Field2WheetImageSelected.color = new Color(255, 0, 0, 255);
        Field2GrapesImageSelected.color = new Color(255, 0, 0, 255);
        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void Field2ChooseGrapes()
    {
        if(!isFarmersActive)
            isFarmersActive = true;
        
        if(!Field2GrapesIsChoosen)
        {
            Field2GrapesIsChoosen = true;
            Field2GrapesImageSelected.color = new Color(0, 255, 0, 255);
            if(!Field2Choosen)
            {
                /*if(HarvestIsActive && PlantIsActive)
                    WL.SpendMoney += 10000;
                else if(!HarvestIsActive && !PlantIsActive)
                    Debug.Log("Nothing Is Choosen!");
                else
                    WL.SpendMoney += 5000;*/
            }
            Field2Choosen = true;

        }
        else
        {
            Field2GrapesIsChoosen = false;
            Field2GrapesImageSelected.color = new Color(255, 0, 0, 255);
            Field2Choosen = false;
            /*if(HarvestIsActive && PlantIsActive)
                WL.SpendMoney -= 10000;
            else if(!HarvestIsActive && !PlantIsActive)
                Debug.Log("Nothing Is Choosen!");
            else
                WL.SpendMoney -= 5000;*/
        }

        Field2WheetIsChoosen = false;
        Field2VegsIsChoosen = false;

        Field2WheetImageSelected.color = new Color(255, 0, 0, 255);
        Field2VegsImageSelected.color = new Color(255, 0, 0, 255);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    // Field 3

    public void Field3ChooseWheet()
    {
        if(!isFarmersActive)
            isFarmersActive = true;
        
        if(!Field3WheetIsChoosen)
        {
            Field3WheetIsChoosen = true;
            Field3WheetImageSelected.color = new Color(0, 255, 0, 255);
            if(!Field3Choosen)
            {
                /*if(HarvestIsActive && PlantIsActive)
                    WL.SpendMoney += 10000;
                else if(!HarvestIsActive && !PlantIsActive)
                    Debug.Log("Nothing Is Choosen!");
                else
                    WL.SpendMoney += 5000;*/
            }
            Field3Choosen = true;
        }
        else
        {
            Field3WheetIsChoosen = false;
            Field3WheetImageSelected.color = new Color(255, 0, 0, 255);
            Field3Choosen = false;
            /*if(HarvestIsActive && PlantIsActive)
                WL.SpendMoney -= 10000;
            else if(!HarvestIsActive && !PlantIsActive)
                Debug.Log("Nothing Is Choosen!");
            else
                WL.SpendMoney -= 5000;*/
        }

        Field3VegsIsChoosen = false;
        Field3GrapesIsChoosen = false;

        Field3VegsImageSelected.color = new Color(255, 0, 0, 255);
        Field3GrapesImageSelected.color = new Color(255, 0, 0, 255);
        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void Field3ChooseVegs()
    {
        if(!isFarmersActive)
            isFarmersActive = true;
        
        if(!Field3VegsIsChoosen)
        {
            Field3VegsIsChoosen = true;
            Field3VegsImageSelected.color = new Color(0, 255, 0, 255);
            if(!Field3Choosen)
            {
                /*if(HarvestIsActive && PlantIsActive)
                    WL.SpendMoney += 10000;
                else if(!HarvestIsActive && !PlantIsActive)
                    Debug.Log("Nothing Is Choosen!");
                else
                    WL.SpendMoney += 5000;*/
            }
            Field3Choosen = true;
        }
        else
        {
            Field3VegsIsChoosen = false;
            Field3VegsImageSelected.color = new Color(255, 0, 0, 255);
            Field3Choosen = false;
            /*if(HarvestIsActive && PlantIsActive)
                WL.SpendMoney -= 10000;
            else if(!HarvestIsActive && !PlantIsActive)
                Debug.Log("Nothing Is Choosen!");
            else
                WL.SpendMoney -= 5000;*/
        }

        Field3WheetIsChoosen = false;
        Field3GrapesIsChoosen = false;

        Field3WheetImageSelected.color = new Color(255, 0, 0, 255);
        Field3GrapesImageSelected.color = new Color(255, 0, 0, 255);
        SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void Field3ChooseGrapes()
    {
        if(!isFarmersActive)
            isFarmersActive = true;
        
        if(!Field3GrapesIsChoosen)
        {
            Field3GrapesIsChoosen = true;
            Field3GrapesImageSelected.color = new Color(0, 255, 0, 255);
            if(!Field3Choosen)
            {
                /*if(HarvestIsActive && PlantIsActive)
                    WL.SpendMoney += 10000;
                else if(!HarvestIsActive && !PlantIsActive)
                    Debug.Log("Nothing Is Choosen!");
                else
                    WL.SpendMoney += 5000;*/
            }
            Field3Choosen = true;
        }
        else
        {
            Field3GrapesIsChoosen = false;
            Field3GrapesImageSelected.color = new Color(255, 0, 0, 255);
            Field3Choosen = false;
            /*if(HarvestIsActive && PlantIsActive)
                WL.SpendMoney -= 10000;
            else if(!HarvestIsActive && !PlantIsActive)
                Debug.Log("Nothing Is Choosen!");
            else
                WL.SpendMoney -= 5000;*/
        }

        Field3WheetIsChoosen = false;
        Field3VegsIsChoosen = false;

        Field3WheetImageSelected.color = new Color(255, 0, 0, 255);
        Field3VegsImageSelected.color = new Color(255, 0, 0, 255);
        SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion
    
    #region Harvest Logic

    public void CheckForHarvest()
    {
        if(Field1.HarvestReady && Field1Choosen && HarvestIsActive)
        {
            //TurnRecap.Instance.GetTextStrings("Harvested: " + wheetsScr.HarvestAmount + " wheet");
            //EventsScr.Instance.EventPopText("Your farmers are harvested: " + wheetsScr.HarvestAmount + " wheet");
            if(GameManager.Instance.money >= FarmersCost)
                GameManager.Instance.money -= FarmersCost;
            else
            {
                isFarmersActive = false;
                return;
            }
            
            Field1.HarvestButton();
            Field1.FieldIsPlanted = false;
            Field1.HarvestReady = false;
        }
        else if(Field2.HarvestReady && Field2Choosen && HarvestIsActive)
        {
            //TurnRecap.Instance.GetTextStrings("Harvested: " + vegetablesScr.HarvestAmount + " vegs");
            //EventsScr.Instance.EventPopText("Your farmers are harvested: " + vegetablesScr.HarvestAmount + "vegs");
            if(GameManager.Instance.money >= FarmersCost)
                GameManager.Instance.money -= FarmersCost;
            else
            {
                isFarmersActive = false;
                return;
            }

            Field2.HarvestButton();
            Field2.FieldIsPlanted = false;
            Field2.HarvestReady = false;
        }
        else if(Field3.HarvestReady && Field3Choosen && HarvestIsActive)
        {
            //TurnRecap.Instance.GetTextStrings("Harvested: " + grapesScr.HarvestAmount + " grapes");
            //EventsScr.Instance.EventPopText("Your farmers are harvested: " + grapesScr.HarvestAmount + " grapes");

            if(GameManager.Instance.money >= FarmersCost)
                GameManager.Instance.money -= FarmersCost;
            else
            {
                isFarmersActive = false;
                return;
            }

            Field3.HarvestButton();
            Field3.FieldIsPlanted = false;
            Field3.HarvestReady = false;
        }
    }

    #endregion
}
