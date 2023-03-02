using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryController : MonoBehaviour
{
    [Header("ItemList")]
    public List<Items> SuppliesList;
    public List<Items> GearList;
    public List<Items> MatList;

    [Header("Objects")]
    private GameObject r;
    public GameObject[] content;
    public GameObject ItemPrefab;
    [HideInInspector] public List<GameObject> SuppliesObj;
    [HideInInspector] public List<GameObject> GearObj;
    [HideInInspector] public List<GameObject> MatObj;

    public static InventoryController current;

    private void Awake()
    {
        current = this;
        SuppliesList.AddRange(Resources.LoadAll<Items>("Inventory/Supplies"));
        GearList.AddRange(Resources.LoadAll<Items>("Inventory/Gear"));
        MatList.AddRange(Resources.LoadAll<Items>("Inventory/Materials"));
        SetInventory(SuppliesList);
        SetInventory(GearList);
        SetInventory(MatList);
        content[1].SetActive(false);
        content[2].SetActive(false);
    }

    public void SetInventory(List<Items> thislist)
    {
        List<GameObject> objlist;
        int set;
        if (thislist == SuppliesList)
        {
            objlist = SuppliesObj;
            set = 0;
        }
        else if(thislist == GearList)
        {
            objlist = GearObj;
            set = 1;
        }
        else
        {
            objlist = MatObj;
            set = 2;
        }

        for (int i = 0; i < thislist.Count; i++)
        {
            if (thislist[i].Value > 0)
            {
                r = Instantiate(ItemPrefab, content[set].transform);
                r.transform.parent = content[set].transform;
                r.TryGetComponent<InventoryItem>(out InventoryItem c);
                c.thisitem = thislist[i];
                objlist.Add(r);
            }
        }
    }

    public void ShowInventory(int thisinv)
    {
        for (int i = 0; i < content.Length; i++)
        {
            content[i].SetActive(false);
        }

        content[thisinv].SetActive(true);
    }
}
