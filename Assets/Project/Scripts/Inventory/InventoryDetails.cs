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
    public TextMeshProUGUI itemname;
    public TextMeshProUGUI itemdescription;
    public TextMeshProUGUI itemvalue;

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
    }
}
