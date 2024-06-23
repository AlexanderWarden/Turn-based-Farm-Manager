using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FarmScr : MonoBehaviour
{
    #region Variables 

    [Header("Scripts: ")]

    [Header("Main Prod: ")]

    public int wheets = 0;
    public int vegetables = 0;
    public int grapes = 0;

    [Header("Farm Top Info")]

    public TextMeshProUGUI wheetsText;
    public TextMeshProUGUI vegetablesText;
    public TextMeshProUGUI grapesText;

    [Header("Field Main")]

    public FieldScr Field1;
    public FieldScr Field2;
    public FieldScr Field3;

    [Header("Field Seconds")]

    [Header("Turns Needed for Prods")]
    public int WheetTurnsNeeded;
    public int VegetablesTurnsNeeded;
    public int GrapesTurnsNeeded;

    [Header("Open By Fame")]

    public GameObject VegsShowTopInfo;

    public GameObject GrapesShowTopInfo;

    private bool VegsOpened = false;
    private bool GrapesOpened = false;

    [Header("Fertility: ")]

    public int wheetFertilityInput;
    public int wheetFertilityRange;
    public int vegsFertilityInput;
    public int vegsFertilityRange;
    public int grapesFertilityInput;
    public int grapesFertilityRange;

    #endregion

    #region Start/Update


    private void Update()
    {
        wheetsText.text = GameManager.Instance.CountText(wheets);
        vegetablesText.text = GameManager.Instance.CountText(vegetables);
        grapesText.text = GameManager.Instance.CountText(grapes);

    }

    #endregion

    #region UnlockByFame

    public void VegetablesUnlock()
    {
        VegsShowTopInfo.SetActive(true);
        VegsOpened = true;

        /*if(SelectedCulture > 0)
        {
            vegetablesScr.SeedsAmountYN.SetActive(false);
            vegetablesScr.SeedsClickObj.SetActive(false);
            vegetablesScr.SeedsOn.SetActive(true);
        }

        newsScr.FarmNewsObj.SetActive(true);*/
    }

    public void GrapesUnlock()
    {
        GrapesShowTopInfo.SetActive(true);
        GrapesOpened = true;

        /*if(SelectedCulture > 0)
        {
            grapesScr.SeedsAmountYN.SetActive(false);
            grapesScr.SeedsClickObj.SetActive(false);
            grapesScr.SeedsOn.SetActive(true);
        }

        newsScr.FarmNewsObj.SetActive(true);*/
    }

    #endregion

    #region FartTurnLogic

    public void FarmTurnLogic()
    {
        Field1.FieldTurnLogic();

        if(Field2.FieldIsActive)
            Field2.FieldTurnLogic();
        if(Field3.FieldIsActive)
            Field3.FieldTurnLogic();
    }

    #endregion

    
}
