using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemContent : MonoBehaviour
{
    private Itemlist list;
    public Text LvText;
    public GameObject Content;
    public GameObject itemprefab;
    private GameObject thisitem;

    private void Start()
    {
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
            thisgroup.isClaim = list.BattlePassList[i].isClaim;
            thisgroup.lvl = list.BattlePassList[i].Level;
            thisgroup.normalitem = list.BattlePassList[i].normalItem;
            thisgroup.premiumitem = list.BattlePassList[i].premiumItem;
        }
    }
}
