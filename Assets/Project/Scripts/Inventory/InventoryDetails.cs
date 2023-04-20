using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDetails : MonoBehaviour
{
    public Items thisitems;
    public GameObject blog;
    public static InventoryDetails current;

    [Header("UI")]
    public Image itemsprite;
    public Image itemframe;
    public Button itembutton;
    public Button discardbutton;
    public TextMeshProUGUI itemname;
    public TextMeshProUGUI itemdescription;
    public TextMeshProUGUI itemvalue;
    [SerializeField] private Sprite[] frameset;

    private void Awake()
    {
        current = this;
    }

    public void SetDetails(Items setitem)
    {
        blog.SetActive(true);
        thisitems = setitem;
        itemsprite.sprite = thisitems.ItemSprite;
        itemname.text = thisitems.Name;
        itemdescription.text = thisitems.Description;
        itemvalue.text = "stock : " + thisitems.Value;

        switch (thisitems.Rate)
        {
            case KaiJuGame.Rarity.CM:
                itemframe.sprite = frameset[0];
                break;
            case KaiJuGame.Rarity.UN_CM:
                itemframe.sprite = frameset[1];
                break;
            case KaiJuGame.Rarity.RARE:
                itemframe.sprite = frameset[2];
                break;
            case KaiJuGame.Rarity.EPIC:
                itemframe.sprite = frameset[3];
                break;
            case KaiJuGame.Rarity.LG:
                itemframe.sprite = frameset[4];
                break;
            default:
                break;
        }

        switch (thisitems.itemtype)
        {
            case Items.ItemType.Supplies:
                itembutton.gameObject.SetActive(true);
                discardbutton.gameObject.SetActive(true);
                break;
            case Items.ItemType.Gear:
                itembutton.gameObject.SetActive(false);
                discardbutton.gameObject.SetActive(true);
                break;
            case Items.ItemType.Material:
                itembutton.gameObject.SetActive(false);
                discardbutton.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void SuppliesUse()
    {
        thisitems.Value -= 1;
        thisitems.itemsupplies.SuppliesType.Value += thisitems.itemsupplies.Value;
        blog.SetActive(false);
    }

    public void Discard()
    {
        thisitems.Value -= 1;
        blog.SetActive(false);
    }
}
