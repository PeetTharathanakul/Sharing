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
        SuppliesList.AddRange(Resources.LoadAll<Items>("Shop/Consume"));
        GearList.AddRange(Resources.LoadAll<Items>("Shop/Gear"));
        MatList.AddRange(Resources.LoadAll<Items>("Shop/Materials"));
        SetInventory(SuppliesList);
        SetInventory(GearList);
        SetInventory(MatList);
    }

    void Start()
    {
        
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
                objlist.Add(r);
            }
        }
    }

    public void ShowInventory()
    {

    }
}
