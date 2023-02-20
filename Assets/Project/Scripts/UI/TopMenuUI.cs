using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum CurrencyType { GOLD,GEM }
public class TopMenuUI : MonoBehaviour
{
    [Space(10)]
    [Header("Currency")]
    [SerializeField] private AddCoin goldCoins;
    [SerializeField] private AddCoin gemsCoins;
    [SerializeField] private TMPro.TextMeshProUGUI gemsText;
    [SerializeField] private TMPro.TextMeshProUGUI goldsText;

    [Header("CoinsEvents")]
    //[SerializeField] private CoinsEventSO coinsEvent;

    [Header("Setting")]
    [SerializeField] private Button settingButton;
    public CurrencyType currencyType;

    private void OnEnable()
    {
        /*coinsEvent.OnEventRaised += goldCoins.UpdateCoins;
        coinsEvent.OnEventRaised += gemsCoins.UpdateCoins;*/
    }


    private void Start()
    {
        //goldButton.onClick.AddListener(()=> OpenShop(currencyType));
        //settingButton.onClick.AddListener(()=> )
        StartCoroutine(updateText());
    }

    private void OpenShop(CurrencyType type)
    {
        // gold
        // gem
        GameData.currencyType = currencyType;
        SceneManager.LoadScene("Shop");
    }

    IEnumerator updateText()
    {
        while (true)
        {
            gemsText.text = GameData.GEMS + "";
            goldsText.text = GameData.GOLDS + "";
            yield return null;
        }
    }

    public void BuyGold(int value)
    {
        GameData.GOLDS += value;
    }

    public void BuyGems(int value)
    {
        GameData.GEMS += value;
    }
}
