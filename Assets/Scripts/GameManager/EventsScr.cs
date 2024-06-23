using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventsScr : MonoBehaviour
{
    public static EventsScr Instance;

    public TextMeshProUGUI EventText;
    public bool EventHasPoped = false;
    public float EventTime;
    public float EventTimer;

    public GameObject EventObj;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Update()
    {
        if(EventHasPoped || EventObj.activeInHierarchy)
        {
            EventTimer += Time.deltaTime;
            if(EventTimer > EventTime)
            {
                EventHasPoped = false;
                EventText.text = "";
                EventTimer = 0;
                EventObj.SetActive(false);
            }
        }

    }

    public void EventPopText(string Text)
    {
        EventObj.SetActive(true);
        EventText.text = Text;
        EventHasPoped = true;
        EventTimer = 0;
    }
}
