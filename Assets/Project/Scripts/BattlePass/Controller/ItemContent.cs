using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemContent : MonoBehaviour
{
    private Itemlist list;
    public GameObject Content;
    public GameObject itemprefab;
    private GameObject thisitem;
    public List<ItemGroup> ItemBPlist;
    public static ItemContent current;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        ItemBPlist.Clear();
        list = Battlepass.current.list;
        Creatitemlist();
    }

    public void Creatitemlist()
    {
        for (int i = 0; i < list.BattlePassList.Length; i++)
        {
            thisitem = Instantiate(itemprefab, Content.transform);
            thisitem.TryGetComponent<ItemGroup>(out ItemGroup thisgroup);
            Content.transform.parent = thisitem.transform;
            ItemBPlist.Add(thisgroup);
            thisgroup.isClaim = list.BattlePassList[i].isClaim;
            thisgroup.lvl = list.BattlePassList[i].Level;
            thisgroup.normalitem = list.BattlePassList[i].normalItem;
            thisgroup.normaleValue = list.BattlePassList[i].normalValue;
            thisgroup.premiumitem = list.BattlePassList[i].premiumItem;
            thisgroup.premiumValue = list.BattlePassList[i].premiumValue;
        }
    }
}
