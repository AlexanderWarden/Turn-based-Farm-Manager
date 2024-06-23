using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FameOffice : MonoBehaviour
{
    private FameShow fameShow;

    public GameObject fameObject1;
    public GameObject fameObject2;
    public GameObject fameObject3;
    public GameObject fameObject4;
    public GameObject fameObject5;
    public GameObject fameObject6;
    public GameObject fameObject7;
    public GameObject fameObject8;
    public GameObject fameObject9;
    public GameObject fameObject10;

    public GameObject fameObject11;
    public GameObject fameObject12;
    public GameObject fameObject13;
    public GameObject fameObject14;
    public GameObject fameObject15;
    public GameObject fameObject16;
    public GameObject fameObject17;
    public GameObject fameObject18;
    public GameObject fameObject19;
    public GameObject fameObject20;

    private void Start()
    {
        fameShow = FindObjectOfType<FameShow>();

        fameObject1.GetComponent<FameObject>().fameAmount = fameShow.fameLock1;
        fameObject2.GetComponent<FameObject>().fameAmount = fameShow.fameLock2;
        fameObject3.GetComponent<FameObject>().fameAmount = fameShow.fameLock3;
        fameObject4.GetComponent<FameObject>().fameAmount = fameShow.fameLock4;
        fameObject5.GetComponent<FameObject>().fameAmount = fameShow.fameLock5;
        fameObject6.GetComponent<FameObject>().fameAmount = fameShow.fameLock6;
        fameObject7.GetComponent<FameObject>().fameAmount = fameShow.fameLock7;
        fameObject8.GetComponent<FameObject>().fameAmount = fameShow.fameLock8;
        fameObject9.GetComponent<FameObject>().fameAmount = fameShow.fameLock9;
        fameObject10.GetComponent<FameObject>().fameAmount = fameShow.fameLock10;

        fameObject11.GetComponent<FameObject>().fameAmount = fameShow.fameLock11;
        fameObject12.GetComponent<FameObject>().fameAmount = fameShow.fameLock12;
        fameObject13.GetComponent<FameObject>().fameAmount = fameShow.fameLock13;
        fameObject14.GetComponent<FameObject>().fameAmount = fameShow.fameLock14;
        fameObject15.GetComponent<FameObject>().fameAmount = fameShow.fameLock15;
        fameObject16.GetComponent<FameObject>().fameAmount = fameShow.fameLock16;
        fameObject17.GetComponent<FameObject>().fameAmount = fameShow.fameLock17;
        fameObject18.GetComponent<FameObject>().fameAmount = fameShow.fameLock18;
        fameObject19.GetComponent<FameObject>().fameAmount = fameShow.fameLock19;
        fameObject20.GetComponent<FameObject>().fameAmount = fameShow.fameLock20;
    }

    
}
