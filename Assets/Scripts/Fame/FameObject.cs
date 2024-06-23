using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FameObject : MonoBehaviour
{
    public int fameAmount;

    public GameObject hideObj;

    private void Update()
    {
        ShowByFame();
    }

    public void ShowByFame()
    {
        if(GameManager.Instance.fame >= fameAmount)
        {
            hideObj.SetActive(false);
        }
            
    }
}
