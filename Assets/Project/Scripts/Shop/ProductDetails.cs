using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductDetails : MonoBehaviour
{
    [Header("Detail")]
    public Product thisproduct;
    public ItemDetails ProductItem;

    [Header("UI")]
    public TextMeshProUGUI ProductName;
    public TextMeshProUGUI ProductPrice;
    public TextMeshProUGUI ProductAmount;
    public Button BuyButton;

    void Start()
    {
        SetProduct();
    }

    public void SetProduct()
    {
        ProductName.text = thisproduct.Name;
        ProductItem.thisitem = thisproduct.ProductItem;
        ProductItem.SetDetail(thisproduct.isBuy, thisproduct.ProductValue);
        ProductPrice.text = thisproduct.ProductCost + "";
        ProductAmount.text = "Left : " + thisproduct.ProductAmount;
        StartCoroutine(BuyableCheck());
    }

    public int CostCheck()
    {
        switch (thisproduct.ProductCurrency)
        {
            case Currency.Golds:
                return (GameData.GOLDS);
                break;
            case Currency.Gems:
                return (GameData.GEMS);
                break;
            default:
                return (0);
                break;
        }
        
    }

    IEnumerator BuyableCheck()
    {
        BuyButton.interactable = false;
        while (!thisproduct.isBuy)
        {
            if((CostCheck() < thisproduct.ProductCost))
            {
                BuyButton.interactable = false;
            }
            else
            {
                BuyButton.interactable = true;
            }
            yield return null;
        }

        if(!thisproduct.isBuy)
            BuyButton.interactable = true;
        else
        {
            BuyButton.interactable = false;
            gameObject.transform.SetAsLastSibling();
        }
    }

    public void BuyProduct()
    {
        switch (thisproduct.ProductCurrency)
        {
            case Currency.Golds:
                GameData.GOLDS = GameData.GOLDS - thisproduct.ProductCost; 
                break;
            case Currency.Gems:
                GameData.GEMS = GameData.GEMS - thisproduct.ProductCost;
                break;
            default:
                break;
        }
        thisproduct.ProductItem.Value += thisproduct.ProductValue;
        thisproduct.ProductAmount -= 1;
        ProductAmount.text = "Left : " + thisproduct.ProductAmount;
        if (thisproduct.ProductAmount <= 0)
        {
            thisproduct.isBuy = true;
            StartCoroutine(BuyableCheck());
            ProductItem.SetDetail(thisproduct.isBuy, thisproduct.ProductValue);
        }
    }
}
