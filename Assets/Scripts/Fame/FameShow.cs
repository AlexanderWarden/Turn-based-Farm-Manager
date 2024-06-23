using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FameShow : MonoBehaviour
{
    public static FameShow Instance;

    public int fameLock1;
    public int fameLock2;
    public int fameLock3;
    public int fameLock4;
    public int fameLock5;
    public int fameLock6;
    public int fameLock7;
    public int fameLock8;
    public int fameLock9;
    public int fameLock10;

    public int fameLock11;
    public int fameLock12;
    public int fameLock13;
    public int fameLock14;
    public int fameLock15;
    public int fameLock16;
    public int fameLock17;
    public int fameLock18;
    public int fameLock19;
    public int fameLock20;

    public TextMeshProUGUI fameLockText1;
    public TextMeshProUGUI fameLockText2;
    public TextMeshProUGUI fameLockText3;
    public TextMeshProUGUI fameLockText4;
    public TextMeshProUGUI fameLockText5;
    public TextMeshProUGUI fameLockText6;
    public TextMeshProUGUI fameLockText7;
    public TextMeshProUGUI fameLockText8;
    public TextMeshProUGUI fameLockText9;
    public TextMeshProUGUI fameLockText10;

    public TextMeshProUGUI fameLockText11;
    public TextMeshProUGUI fameLockText12;
    public TextMeshProUGUI fameLockText13;
    public TextMeshProUGUI fameLockText14;
    public TextMeshProUGUI fameLockText15;
    public TextMeshProUGUI fameLockText16;
    public TextMeshProUGUI fameLockText17;
    public TextMeshProUGUI fameLockText18;
    public TextMeshProUGUI fameLockText19;
    public TextMeshProUGUI fameLockText20;

    public TextMeshProUGUI MainFameText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
            
    }

    private void Start()
    {
        fameLockText1.text = GameManager.Instance.CountText(fameLock1);
        fameLockText2.text = GameManager.Instance.CountText(fameLock2);
        fameLockText3.text = GameManager.Instance.CountText(fameLock3);
        fameLockText4.text = GameManager.Instance.CountText(fameLock4);
        fameLockText5.text = GameManager.Instance.CountText(fameLock5);

        fameLockText6.text = GameManager.Instance.CountText(fameLock6);
        fameLockText7.text = GameManager.Instance.CountText(fameLock7);
        fameLockText8.text = GameManager.Instance.CountText(fameLock8);
        fameLockText9.text = GameManager.Instance.CountText(fameLock9);
        fameLockText10.text = GameManager.Instance.CountText(fameLock10);

        fameLockText11.text = GameManager.Instance.CountText(fameLock11);
        fameLockText12.text = GameManager.Instance.CountText(fameLock12);
        fameLockText13.text = GameManager.Instance.CountText(fameLock13);
        fameLockText14.text = GameManager.Instance.CountText(fameLock14);
        fameLockText15.text = GameManager.Instance.CountText(fameLock15);

        fameLockText16.text = GameManager.Instance.CountText(fameLock16);
        fameLockText17.text = GameManager.Instance.CountText(fameLock17);
        fameLockText18.text = GameManager.Instance.CountText(fameLock18);
        fameLockText19.text = GameManager.Instance.CountText(fameLock19);
        fameLockText20.text = GameManager.Instance.CountText(fameLock20);

    }

    private void Update()
    {
        MainFameText.text = GameManager.Instance.CountText(GameManager.Instance.fame);
    }
}
