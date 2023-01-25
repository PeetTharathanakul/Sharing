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
    [SerializeField] private float Maxpts;
    public Itemlist list;
    public Slider progressbar;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        level = PlayerPrefs.GetInt("BPlvl", 1);
        ProgressbarCheck();
        LvlText.text = "Lv : " + level;
    }

    public void ProgressbarCheck()
    {
        float progress = list.BattlePassList[level - 1].currentpts / Maxpts;
        progressbar.value = progress;
        Debug.Log(progress);
    }

    public void ProgressCheck(int exp)
    {
        
        if(list.BattlePassList[level - 1].currentpts + exp < Maxpts)
        {
            list.BattlePassList[level - 1].currentpts += exp;
        }
        else
        {
            var expcal = exp;
            while(expcal > 0)
            {
                list.BattlePassList[level - 1].currentpts += expcal;
                expcal = Mathf.CeilToInt(list.BattlePassList[level - 1].currentpts - Maxpts);
                if(level != list.BattlePassList.Length)
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
