using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unlocker : MonoBehaviour
{
    public FameShow fameShow;
    public int UnlockNumber;
    private int fameNeeded = 0;
    public TextMeshProUGUI fameNeededText;


    private void Start()
    {
        SetUnlock();
        fameNeededText.text = fameNeeded.ToString();
    }

    private void Update()
    {
        if(GameManager.Instance.fame >= fameNeeded)
        {
            gameObject.SetActive(false);
        }
    }

    private void SetUnlock()
    {
        switch (UnlockNumber)
        {
            case 1:
                fameNeeded = fameShow.fameLock1;
                break;
            case 2:
                fameNeeded = fameShow.fameLock2;
                break;
            case 3:
                fameNeeded = fameShow.fameLock3;
                break;
            case 4:
                fameNeeded = fameShow.fameLock4;
                break;
            case 5:
                fameNeeded = fameShow.fameLock5;
                break;
            case 6:
                fameNeeded = fameShow.fameLock6;
                break;
            case 7:
                fameNeeded = fameShow.fameLock7;
                break;
            case 8:
                fameNeeded = fameShow.fameLock8;
                break;
            case 9:
                fameNeeded = fameShow.fameLock9;
                break;
            case 10:
                fameNeeded = fameShow.fameLock10;
                break;
            case 11:
                fameNeeded = fameShow.fameLock11;
                break;
            case 12:
                fameNeeded = fameShow.fameLock12;
                break;
            case 13:
                fameNeeded = fameShow.fameLock13;
                break;
            case 14:
                fameNeeded = fameShow.fameLock14;
                break;
            case 15:
                fameNeeded = fameShow.fameLock15;
                break;
            case 16:
                fameNeeded = fameShow.fameLock16;
                break;
            case 17:
                fameNeeded = fameShow.fameLock17;
                break;
            case 18:
                fameNeeded = fameShow.fameLock18;
                break;
            case 19:
                fameNeeded = fameShow.fameLock19;
                break;
            case 20:
                fameNeeded = fameShow.fameLock20;
                break;
            default:
                break;
        
        }
    }
}
