using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;


public class KaijuEvol : MonoBehaviour
{
    private KaiJuBase thisBase;
    private CustomBaseStats customBaseStats;

    public EvolSet Matset;
    private Items KaijuMark;
    private int KaijuValue;
    private int GoldValue;

    [Header("UI")]
    public Image CharacterImage;
    public Image MatImage;
    public Image RankImage;
    public Image RareImage;
    public GameObject Total;
    [SerializeField] private Button EvolButton;
    [SerializeField] private TextMeshProUGUI[] MatText;
    [SerializeField] private TextMeshProUGUI[] BeforeText;
    [SerializeField] private TextMeshProUGUI[] AfterText;

    [Header("List")]
    [SerializeField] private Toggle[] SubRankSet;
    [SerializeField] private Sprite[] RankList;
    [SerializeField] private Sprite[] RareList;
    

    private void Start()
    {
        GameData.GOLDS = 100;
        //SetMat();
    }

    public void OnKaijuStateChanged(KaiJuBase kaiju, CustomBaseStats customBase)
    {
        thisBase = kaiju;
        customBaseStats = customBase;
        SetMat();
    }

    public void SetMat()
    {
        CharacterImage.sprite = thisBase.thissprite;
        KaijuMark = Resources.Load<Items>("Inventory/Materials/" + thisBase.Index);
        MatImage.sprite = KaijuMark.ItemSprite;

        Debug.Log("Rank  " + thisBase.Rank + " SubRank " + thisBase.SubRank);

        var modSubRank = thisBase.SubRank % 5;
        if(modSubRank == 0)
        {
            thisBase.SubRank = 1;
        }

        var mat = Matset.Ranklist[thisBase.Rank].Sublist[thisBase.SubRank];
        KaijuValue = mat.KaijuMat;
        GoldValue = mat.GoldValue;
        MatText[0].text = KaijuMark.Value + "/" + KaijuValue;
        MatText[1].text = GameData.GOLDS + "/" + GoldValue;
        switch (thisBase.Rare)
        {
            case KaiJuGame.Rarity.CM:
                RankImage.sprite = RareList[0];
                break;
            case KaiJuGame.Rarity.UN_CM:
                RankImage.sprite = RareList[1];
                break;
            case KaiJuGame.Rarity.RARE:
                RankImage.sprite = RareList[2];
                break;
            case KaiJuGame.Rarity.EPIC:
                RankImage.sprite = RareList[3];
                break;
            case KaiJuGame.Rarity.LG:
                RankImage.sprite = RareList[4];
                break;
            default:
                break;
        }
        SetRank();
        StartCoroutine(CostCheck());
    }

    public void SetRank()
    {
        Debug.Log("RankList  " + (thisBase.Rank - 1));
        RankImage.sprite = RankList[thisBase.Rank - 1];
        RankImage.SetNativeSize();
        for (int i = 0; i < SubRankSet.Length; i++)
        {
            SubRankSet[i].isOn = false;
            if (thisBase.SubRank > i)
            {
                SubRankSet[i].isOn = true;
            }
        }
    }

    IEnumerator CostCheck()
    {
        EvolButton.interactable = false;
        while (KaijuMark.Value < KaijuValue || GameData.GOLDS < GoldValue)
        {
            yield return null;
        }
        EvolButton.interactable = true;
    }

    public void Evoling()
    {
        KaijuMark.Value -= KaijuValue;
        GameData.GOLDS -= GoldValue;
        SetTextRuntime();
        SetMat();
    }

    [ContextMenu("TestText")]
    public void SetTextRuntime()
    {

        Stats newStats = customBaseStats.GetEnvole(thisBase.Rank,thisBase.SubRank);

        thisBase.SubRank += 1;
        if (thisBase.SubRank%5 == 0)
        {
            thisBase.Rank += 1;
        }

        Stats nextStats = customBaseStats.GetEnvole(thisBase.Rank, thisBase.SubRank);

        var cCP = (nextStats.ATK - newStats.ATK);
        var cDEF = (nextStats.DEF - newStats.DEF);
        var cHP = (nextStats.HP - newStats.HP);
        var cSPD = (nextStats.SPD - newStats.SPD);

        Stats totalStats = new Stats(cCP,cDEF,cHP,cSPD);

        BeforeText[0].text = "" + newStats.ATK;
        BeforeText[1].text = "" + newStats.DEF;
        BeforeText[2].text = "" + newStats.HP;
        BeforeText[3].text = "" + newStats.SPD;

        AfterText[0].text = "" + nextStats.ATK;
        AfterText[1].text = "" + nextStats.DEF;
        AfterText[2].text = "" + nextStats.HP;
        AfterText[3].text = "" + nextStats.SPD;

        Debug.Log($"Before ATK = {newStats.ATK} || After = {nextStats.ATK} Calculate = {totalStats.ATK} \n" +
            $"Before DEF = {newStats.DEF} || After = {nextStats.DEF} Calculate = {totalStats.DEF} \n" +
            $"Before HP = {newStats.HP} || After = {nextStats.HP} Calculate = {totalStats.HP} \n" +
            $"Before SPD = {newStats.SPD} || After = {nextStats.SPD} Calculate = {totalStats.SPD} \n");
        Total.SetActive(true);
    }
}
