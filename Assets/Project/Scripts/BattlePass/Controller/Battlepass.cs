using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battlepass : MonoBehaviour
{
    public static Battlepass current;
    public int level;
    public int BPpts;
    public Text LvlText;
    public bool Premium = false;
    [SerializeField] private float Maxpts;
    public Itemlist list;
    public Slider progressbar;
    public GameObject popup;
    public Button buttonPremium; 

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        if (IsPremium())
        {
            buttonPremium.interactable = false;
        }
        level = PlayerPrefs.GetInt("BPlvl", 1);
        ProgressbarCheck();
        LvlText.text = "Lv : " + level;
        
    }

    private bool IsPremium()
    {
        Premium = PlayerPrefs.GetInt("BPPremium", 0) == 1;
        return Premium;
    }

    public void ProgressbarCheck()
    {
        float progress = list.BattlePassList[level - 1].currentpts / Maxpts;
        progressbar.value = progress;
        Debug.Log(progress);
    }

    public void ProgressCheck(int exp)
    {
        if(level < list.BattlePassList.Length)
        {
            if (list.BattlePassList[level - 1].currentpts + exp < Maxpts)
            {
                list.BattlePassList[level - 1].currentpts += exp;
            }
            else
            {
                var expcal = exp;
                while (expcal > 0)
                {
                    list.BattlePassList[level - 1].currentpts += expcal;
                    expcal = Mathf.CeilToInt(list.BattlePassList[level - 1].currentpts - Maxpts);
                    if (level != list.BattlePassList.Length && list.BattlePassList[level - 1].currentpts >= Maxpts)
                    {
                        level += 1;
                        LvlText.text = "Lv : " + level;
                        PlayerPrefs.SetInt("BPlvl", level);
                    }
                }
            }
            ProgressbarCheck();
        }   
        
    }

    public void BuyPremium()
    {
        if(!IsPremium())
        {
            Premium = true;
            PlayerPrefs.SetInt("BPPremium", 1);
            for (int i = 0; i < level; i++)
            {
                if (ItemContent.current.ItemBPlist[i].isClaim)
                {
                    Debug.Log("P_itemget" + i);
                    ItemContent.current.ItemBPlist[i].itemlist[1].itemToggle.isOn = true;
                }
            }
            buttonPremium.interactable = false;
            popup.SetActive(true);
        }
        
    }
}
