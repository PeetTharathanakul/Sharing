using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shoplist", menuName = "Shop/Create Shoplist")]
[System.Serializable]
public class ProductList : ScriptableObject
{
    public Product[] List;
    public ShopType thisShopType;
}

public enum ShopType
{
    A,
    B,
    C
}
