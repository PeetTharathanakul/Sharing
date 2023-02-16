using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductDetails : MonoBehaviour
{
    public Product thisproduct;
    public Text ProductName;
    public Image ProductSprite;
    public Text ProductPrice;

    void Start()
    {
        SetProduct();
    }

    public void SetProduct()
    {
        ProductName.text = thisproduct.Name;
        ProductSprite.sprite = thisproduct.ProductItem.ItemSprite;
        ProductPrice.text = thisproduct.ProductCost + "";
    }
}
