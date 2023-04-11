using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KaijuUpgrade : MonoBehaviour
{
    public KaiJuBase thisbase;
    public UpgradeSet upgradeset;
    public CustomBaseStats Custombase;
    public GameObject content;
    private GameObject o; 
    [SerializeField] private int Maxlvl;
    [SerializeField] private Progression UpgradeValue;
    [SerializeField] private GameObject Statobj;
    [SerializeField] private GameObject itemprefab;

    [Header("UI")]
    public Slider Progressbar;
    public TextMeshProUGUI Progresstext;
    public TextMeshProUGUI Characterlvl;
    [SerializeField] private TextMeshProUGUI[] BeforeText;
    [SerializeField] private TextMeshProUGUI[] AfterText;

    public static KaijuUpgrade current;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        Setcontent();
    }

    private void OnEnable()
    {
        SetText();
    }

    private void SetText()
    {
        Progressbar.value = thisbase.CurrentExp / UpgradeValue.GetEXP(Mathf.CeilToInt(thisbase.Level - 1));
        Progresstext.text = thisbase.CurrentExp + "/" + UpgradeValue.GetEXP(Mathf.CeilToInt(thisbase.Level - 1));
        Characterlvl.text = "Lv." + thisbase.Level;
    }

    private void Setcontent()
    {
        for (int i = 0; i < upgradeset.set.Length; i++)
        {
            o = Instantiate(itemprefab, content.transform);
            o.transform.parent = content.transform;
            o.TryGetComponent<Upgradedetails>(out Upgradedetails detail);
            detail.thisitem = upgradeset.set[i].Upitem;
            detail.Upgradevalue = upgradeset.set[i].value;
            detail.SetDetail();
        }
    }

    public void Upgradecal(int value)
    {
        if((value + thisbase.CurrentExp) < UpgradeValue.GetEXP(Mathf.CeilToInt(thisbase.Level - 1)))
        {
            thisbase.CurrentExp += value;
        }
        else
        {
            thisbase.SetConfigStats(Custombase, Mathf.CeilToInt(thisbase.Level));
            BeforeText[0].text = "" + thisbase.Attack;
            BeforeText[1].text = "" + thisbase.Defense;
            BeforeText[2].text = "" + thisbase.MaxHp;
            BeforeText[3].text = "" + thisbase.Speed;
            Debug.Log(thisbase.Level);
            while (value > 0)
            {
                thisbase.CurrentExp += value;
                value = Mathf.CeilToInt(thisbase.CurrentExp - UpgradeValue.GetEXP(Mathf.CeilToInt(thisbase.Level - 1)));
                if (thisbase.Level != Maxlvl && thisbase.CurrentExp >= UpgradeValue.GetEXP(Mathf.CeilToInt(thisbase.Level - 1)))
                {
                    thisbase.Level += 1;
                    thisbase.CurrentExp = 0;
                }
            }
            Debug.Log(thisbase.Level);
            thisbase.SetConfigStats(Custombase, Mathf.CeilToInt(thisbase.Level));
            AfterText[0].text = "" + thisbase.Attack;
            AfterText[1].text = "" + thisbase.Defense;
            AfterText[2].text = "" + thisbase.MaxHp;
            AfterText[3].text = "" + thisbase.Speed;

            Statobj.SetActive(true);
        }
        SetText();
        
    }

}
