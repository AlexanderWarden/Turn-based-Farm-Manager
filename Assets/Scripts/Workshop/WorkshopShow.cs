using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkshopShow : MonoBehaviour
{
    [Header("Starting UP Cost")]

    public int UpCost1;
    public int UpCost2;
    public int UpCost3;

    public int UpCost4;
    public int UpCost5;
    public int UpCost6;

    public int UpCost7;
    public int UpCost8;
    public int UpCost9;

    public int UpCost10;
    public int UpCost11;
    public int UpCost12;

    public int UpCost13;
    public int UpCost14;
    public int UpCost15;

    public int UpCost16;
    public int UpCost17;
    public int UpCost18;

    public int UpCost19;
    public int UpCost20;

    [HideInInspector] public int UpNumber1 = 1;
    [HideInInspector] public int UpNumber2 = 1;
    [HideInInspector] public int UpNumber3 = 1;

    [HideInInspector] public int UpNumber4 = 1;
    [HideInInspector] public int UpNumber5 = 1;
    [HideInInspector] public int UpNumber6 = 1;

    [HideInInspector] public int UpNumber7 = 1;
    [HideInInspector] public int UpNumber8 = 1;
    [HideInInspector] public int UpNumber9 = 1;

    [HideInInspector] public int UpNumber10 = 1;
    [HideInInspector] public int UpNumber11 = 1;
    [HideInInspector] public int UpNumber12 = 1;

    [HideInInspector] public int UpNumber13 = 1;
    [HideInInspector] public int UpNumber14 = 1;
    [HideInInspector] public int UpNumber15 = 1;

    [HideInInspector] public int UpNumber16 = 1;
    [HideInInspector] public int UpNumber17 = 1;
    [HideInInspector] public int UpNumber18 = 1;

    [HideInInspector] public int UpNumber19 = 1;
    [HideInInspector] public int UpNumber20 = 1;

    [Header("UP Describtion")]

    private string UpDescribtion1 = "";
    private string UpDescribtion2 = "";
    private string UpDescribtion3 = "";

    private string UpDescribtion4 = "";
    private string UpDescribtion5 = "";
    private string UpDescribtion6 = "";

    private string UpDescribtion7  = "";
    private string UpDescribtion8  = "";
    private string UpDescribtion9  = "";

    private string UpDescribtion10 = "";
    private string UpDescribtion11 = "";
    private string UpDescribtion12 = "";

    private string UpDescribtion13 = "";
    private string UpDescribtion14 = "";
    private string UpDescribtion15 = "";

    private string UpDescribtion16 = "";
    private string UpDescribtion17 = "";
    private string UpDescribtion18 = "";

    private string UpDescribtion19 = "";
    private string UpDescribtion20 = "";

    public TextMeshProUGUI TextShow1;
    public TextMeshProUGUI TextShow2;
    public TextMeshProUGUI TextShow3;

    public TextMeshProUGUI TextShow4;
    public TextMeshProUGUI TextShow5;
    public TextMeshProUGUI TextShow6;

    public TextMeshProUGUI TextShow7;
    public TextMeshProUGUI TextShow8;
    public TextMeshProUGUI TextShow9;

    public TextMeshProUGUI TextShow10;
    public TextMeshProUGUI TextShow11;
    public TextMeshProUGUI TextShow12;

    public TextMeshProUGUI TextShow13;
    public TextMeshProUGUI TextShow14;
    public TextMeshProUGUI TextShow15;

    public TextMeshProUGUI TextShow16;
    public TextMeshProUGUI TextShow17;
    public TextMeshProUGUI TextShow18;

    public TextMeshProUGUI TextShow19;
    public TextMeshProUGUI TextShow20;

    private string UpDescribtionShow;
    public int UpCostShow;

    [SerializeField] private TextMeshProUGUI UpDescribtionShowText;
    [SerializeField] private TextMeshProUGUI UpCostShowText;

    private bool UpSelected = false;
    public Button UpgradeBtn;

    public int UpgradeClicked;

    public AudioClip AcceptSound;

    private void Update()
    {
        UpMainButton();
        ShowCostPermanently();
        DescribtionUpdate();
        ShowTextUpdate();
    }

    private void ShowTextUpdate()
    {
        TextShow1.text = "+1 prod";
        TextShow2.text = "+1 cost";
        //TextShow3.text = "+" + UpNumber3.ToString() + "k max";

        TextShow4.text = "+1 prod";
        TextShow5.text = "+1 cost";
        //TextShow6.text = "+" + UpNumber6.ToString() + "k max";

        TextShow7.text = "+1 prod";
        TextShow8.text = "+1 cost";
        //TextShow9.text = "+" + UpNumber9.ToString() + "k max";

        TextShow10.text = "+1 prod";
        TextShow11.text = "+1 cost";
        //TextShow12.text = "+" + UpNumber12.ToString() + "k max";

        TextShow13.text = "+1 prod";
        TextShow14.text = "+1 cost";
        //TextShow15.text = "+" + UpNumber15.ToString() + "k max";

        TextShow16.text = "+1 prod";
        TextShow17.text = "+1 cost";
        //TextShow18.text = "+" + UpNumber18.ToString() + "k max";

        TextShow19.text = "+1 prod";
        TextShow20.text = "+1 prod";
    }

    private void DescribtionUpdate()
    {
        UpDescribtion1 = "Wheet +1 production";
        UpDescribtion2 = "Wheet buy -1/ sell +1";
        UpDescribtion3 = "Filed1 +500 size";

        UpDescribtion4 = "Eggs +1 production";
        UpDescribtion5 = "Eggs buy -1/ sell +1";
        UpDescribtion6 = "Hens max amount";

        UpDescribtion7  = "Veggies +1 production";
        UpDescribtion8  = "Veggies buy -1/ sell +1";
        UpDescribtion9  = "Filed2 +500 size";

        UpDescribtion10 = "Milk +1 production";
        UpDescribtion11 = "Milk buy -1/ sell +1";
        UpDescribtion12 = "Cows max amount";

        UpDescribtion13 = "Wool +1 production";
        UpDescribtion14 = "Wool buy -1/ sell +1";
        UpDescribtion15 = "Sheeps + max amount";

        UpDescribtion16 = "Grapes +1 production";
        UpDescribtion17 = "Grapes buy -1/ sell +1";
        UpDescribtion18 = "Filed3 +500 size";

        UpDescribtion19 = "Tech +1 production";
        UpDescribtion20 = "Fame +1 production";
    }

    public void UpMainButton()
    {
        if(UpSelected && GameManager.Instance.tech >= UpCostShow)
        {
            UpgradeBtn.interactable = true;
        }
        else
        {
            UpgradeBtn.interactable = false;
        }

        //SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void ShowCostPermanently()
    {
        UpCostShowText.text = GameManager.Instance.CountText(UpCostShow);
    }

    #region UP Buttons
    public void UpButton1()
    {
        UpCostShow = UpCost1;
        UpDescribtionShow = UpDescribtion1;
        UpgradeClicked = 1;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton2()
    {
        UpCostShow = UpCost2;
        UpDescribtionShow = UpDescribtion2;
        UpgradeClicked = 2;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton3()
    {
        UpCostShow = UpCost3;
        UpDescribtionShow = UpDescribtion3;
        UpgradeClicked = 3;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton4()
    {
        UpCostShow = UpCost4;
        UpDescribtionShow = UpDescribtion4;
        UpgradeClicked = 4;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton5()
    {
        UpCostShow = UpCost5;
        UpDescribtionShow = UpDescribtion5;
        UpgradeClicked = 5;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void UpButton6()
    {
        UpCostShow = UpCost6;
        UpDescribtionShow = UpDescribtion6;
        UpgradeClicked = 6;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton7()
    {
        UpCostShow = UpCost7;
        UpDescribtionShow = UpDescribtion7;
        UpgradeClicked = 7;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton8()
    {
        UpCostShow = UpCost8;
        UpDescribtionShow = UpDescribtion8;
        UpgradeClicked = 8;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton9()
    {
        UpCostShow = UpCost9;
        UpDescribtionShow = UpDescribtion9;
        UpgradeClicked = 9;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton10()
    {
        UpCostShow = UpCost10;
        UpDescribtionShow = UpDescribtion10;
        UpgradeClicked = 10;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void UpButton11()
    {
        UpCostShow = UpCost11;
        UpDescribtionShow = UpDescribtion11;
        UpgradeClicked = 11;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton12()
    {
        UpCostShow = UpCost12;
        UpDescribtionShow = UpDescribtion12;
        UpgradeClicked = 12;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton13()
    {
        UpCostShow = UpCost13;
        UpDescribtionShow = UpDescribtion13;
        UpgradeClicked = 13;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton14()
    {
        UpCostShow = UpCost14;
        UpDescribtionShow = UpDescribtion14;
        UpgradeClicked = 14;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton15()
    {
        UpCostShow = UpCost15;
        UpDescribtionShow = UpDescribtion15;
        UpgradeClicked = 15;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }

    public void UpButton16()
    {
        UpCostShow = UpCost16;
        UpDescribtionShow = UpDescribtion16;
        UpgradeClicked = 16;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton17()
    {
        UpCostShow = UpCost17;
        UpDescribtionShow = UpDescribtion17;
        UpgradeClicked = 17;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton18()
    {
        UpCostShow = UpCost18;
        UpDescribtionShow = UpDescribtion18;
        UpgradeClicked = 18;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton19()
    {
        UpCostShow = UpCost19;
        UpDescribtionShow = UpDescribtion19;
        UpgradeClicked = 19;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }
    public void UpButton20()
    {
        UpCostShow = UpCost20;
        UpDescribtionShow = UpDescribtion20;
        UpgradeClicked = 20;

        UpDescribtionShowText.text = UpDescribtionShow;
        UpSelected = true;
        //SoundManager.Instance.PlaySound(AcceptSound);
    }

    #endregion
}
