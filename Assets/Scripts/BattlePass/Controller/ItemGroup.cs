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
    public Items premiumitem;
    [SerializeField] private ItemDetails[] itemlist;
    public Button button;

    private void Start()
    {
        lvltext.text = "" + lvl;
        itemlist[0].thisitem = normalitem;
        itemlist[1].thisitem = premiumitem;
        itemlist[0].SetDetail(isClaim);
        itemlist[1].SetDetail(isClaim);
    }

    private void Update()
    {
        if(Battlepass.current.level >= lvl)
        {
            button.interactable = true;
        }
        else if(Battlepass.current.level < lvl || isClaim)
        {
            button.interactable = false;
        }
    }

    public void ClaimReward()
    {
        
    }
}
