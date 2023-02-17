using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCoin : MonoBehaviour
{
    [SerializeField] bool isGems;
    [SerializeField] TMPro.TextMeshProUGUI textPro;

    private void Start()
    {
        textPro.text = $"{GameData.GOLDS}";
    }

    public void UpdateCoins(int coins)
    {
        if (isGems)
        {
            GameData.GEMS += coins;
        }
        else
        {
            GameData.GOLDS += coins;
        }

        textPro.text = $"{(isGems?GameData.GEMS:GameData.GOLDS)}";
    }
}
