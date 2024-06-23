using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnRecap : MonoBehaviour
{
    public List<TextMeshProUGUI> TextSpaces;
    public List<string> TextStrings;

    public static TurnRecap Instance;

    [Header("Load")]
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;

    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;
    public TextMeshProUGUI text7;
    public TextMeshProUGUI text8;

    public TextMeshProUGUI text9;
    public TextMeshProUGUI text10;
    public TextMeshProUGUI text11;
    public TextMeshProUGUI text12;

    public TextMeshProUGUI text13;
    public TextMeshProUGUI text14;
    public TextMeshProUGUI text15;
    public TextMeshProUGUI text16;


    public void Awake()
    {
        if(Instance == null)
            Instance = this;

        TextSpaces = new List<TextMeshProUGUI>();
        TextStrings = new List<string>();

        LoadTMPToList();
        TurnShowRecap();
    }

    private void Update()
    {
        TurnShowRecap();
    }

    public void TurnShowRecap()
    {
        SetTextsLogic();
    }

    public void GetTextStrings(string text)
    {
        TextStrings.Add(text);
    }

    public void ClearAllStrings()
    {
        if(TextStrings.Count > 0)
            TextStrings.Clear();
    }

    public void SetTextsLogic()
    {
        for(int i = 0; i < TextSpaces.Count; i++)
        {
            if(TextStrings.Count > i)
                TextSpaces[i].text = TextStrings[i].ToString();
            else
                TextSpaces[i].text = "";
        }
    }

    public void LoadTMPToList()
    {
        TextSpaces.Add(text1);
        TextSpaces.Add(text2);
        TextSpaces.Add(text3);
        TextSpaces.Add(text4);
        TextSpaces.Add(text5);
        TextSpaces.Add(text6);
        TextSpaces.Add(text7);
        TextSpaces.Add(text8);

        TextSpaces.Add(text9);
        TextSpaces.Add(text10);
        TextSpaces.Add(text11);
        TextSpaces.Add(text12);
        TextSpaces.Add(text13);
        TextSpaces.Add(text14);
        TextSpaces.Add(text15);
        TextSpaces.Add(text16);
    }

}
