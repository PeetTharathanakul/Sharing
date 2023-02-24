using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryController : MonoBehaviour
{
    [Header("ItemList")]
    public List<Items> ConsumeList;
    public List<Items> GearList;
    public List<Items> MatList;

    [Header("Objects")]
    private GameObject r;
    public GameObject content;
    public GameObject ItemPrefab;
    [HideInInspector] public List<GameObject> ConsumeObj;
    [HideInInspector] public List<GameObject> GearObj;
    [HideInInspector] public List<GameObject> MatObj;

    public static InventoryController current;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        SetInventory(ConsumeList);
    }

    public void SetInventory(List<Items> thislist)
    {
        List<GameObject> objlist;
        if (thislist == ConsumeList)
        {
            objlist = ConsumeObj;
        }
        else if(thislist == GearList)
        {
            objlist = GearObj;
        }
        else
        {
            objlist = MatObj;
        }

        for (int i = 0; i < thislist.Count; i++)
        {
            if (thislist[i].Value > 0)
            {
                r = Instantiate(ItemPrefab, content.transform);
                r.transform.parent = content.transform;
                objlist.Add(r);
            }
        }
    }

}
