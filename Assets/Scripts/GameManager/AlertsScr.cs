using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertsScr : MonoBehaviour
{
    public static AlertsScr Instance;

    public GameObject FarmAlertObj;
    public GameObject BarnAlertObj;
    public GameObject HouseAlertObj;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
}
