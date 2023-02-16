using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Product", menuName = "Shop/Create Products")]
[System.Serializable]
public class Product : ScriptableObject
{
    public string Name;
    public Items ProductItem;
    public bool isBuy;
    public int ProductValue;
    public Currency ProductCurrency;
    public int ProductCost;
}

public enum Currency
{
    Coins,
    Gems,
    Topup
}
