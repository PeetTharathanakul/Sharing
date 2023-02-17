using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoinHandler
{
    [SerializeField] private GameObject coinsUI;
    [SerializeField] private GameObject gemDisplay;
    [SerializeField] private GameObject goldDisplay;


    public void ShowDisplay()
    {
        //TrackingEngine.Instance.ShowDisplay(true);
    }

    public void ControlUI(bool isOn)
    {
        coinsUI.gameObject.SetActive(isOn);
    }

    public GameObject GetDisplay(bool isGem)
    {
        ShowDisplay();
        coinsUI.gameObject.SetActive(true);
        return isGem? gemDisplay:goldDisplay;
    }


}
