using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGroup : MonoBehaviour
{
    public bool isClaim;
    public int lvl;
    public Text lvltext;
    public Items normalitem;
    public int normaleValue;
    public Items premiumitem;
    public int premiumValue;
    public ItemDetails[] itemlist;
    public Button button;

    private void Start()
    {
        lvltext.text = "" + lvl;
        itemlist[0].thisitem = normalitem;
        itemlist[1].thisitem = premiumitem;
        itemlist[0].SetDetail(isClaim, normaleValue);
        itemlist[1].SetDetail(isClaim, premiumValue);
    }

    private void Update()
    {
        if (Battlepass.current.level >= lvl && !Battlepass.current.list.BattlePassList[lvl - 1].isClaim)
        {
            button.interactable = true;
        }
        else if(Battlepass.current.level < lvl || Battlepass.current.list.BattlePassList[lvl - 1].isClaim)
        {
            button.interactable = false;
        }
    }

    public void ClaimReward()
    {
        Battlepass.current.list.BattlePassList[lvl - 1].isClaim = true;
        isClaim = Battlepass.current.list.BattlePassList[lvl - 1].isClaim;
        Debug.Log("itemget" + lvl);
        itemlist[0].itemToggle.isOn = true;
        normalitem.Value += normaleValue;
        if (Battlepass.current.Premium)
        {
            Debug.Log("P_itemget" + lvl);
            premiumitem.Value += premiumValue;
            itemlist[1].itemToggle.isOn = true;
        }
        
    }
}
