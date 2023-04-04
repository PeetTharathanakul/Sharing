using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;


public class KaijuEvol : MonoBehaviour
{
    public KaiJuBase thisBase;
    public CustomBaseStats customBaseStats;

    public EvolSet Matset;
    private Items KaijuMark;
    private int KaijuValue;
    private int GoldValue;

    [Header("UI")]
    public Image CharacterImage;
    public Image MatImage;
    public Image RankImage;
    [SerializeField] private TextMeshProUGUI[] MatText;
    [SerializeField] private Button EvolButton;
    [SerializeField] private Toggle[] SubRankSet;
    [SerializeField] private Sprite[] RankList;
    

    private void Start()
    {
        GameData.GOLDS = 100;
        SetMat();
    }

    public void SetMat()
    {
        CharacterImage.sprite = thisBase.thissprite;
        KaijuMark = Resources.Load<Items>("Inventory/Materials/" + thisBase.Name);
        MatImage.sprite = KaijuMark.ItemSprite;
        var mat = Matset.Ranklist[thisBase.Rank].Sublist[thisBase.SubRank];
        KaijuValue = mat.KaijuMat;
        GoldValue = mat.GoldValue;
        MatText[0].text = KaijuMark.Value + "/" + KaijuValue;
        MatText[1].text = GameData.GOLDS + "/" + GoldValue;
        SetRank();
        StartCoroutine(CostCheck());
    }

    public void SetRank()
    {
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
        thisBase.SubRank += 1;
        if (thisBase.SubRank >= 5)
        {
            thisBase.SubRank = 0;
            thisBase.Rank += 1;
        }
        SetMat();
    }

    [ContextMenu("TestText")]
    public void SetTextRuntime()
    {
        int rankUp = 2;
        int stepUp = 2;

        Stats newStats = customBaseStats.GetEnvole(rankUp,stepUp);
        Stats nextStats = customBaseStats.GetEnvole(rankUp + 1,stepUp + 1);

        var cCP = (nextStats.ATK - newStats.ATK);
        var cDEF = (nextStats.DEF - newStats.DEF);
        var cHP = (nextStats.HP - newStats.HP);
        var cSPD = (nextStats.SPD - newStats.SPD);

        Stats totalStats = new Stats(cCP,cDEF,cHP,cSPD);

        Debug.Log($"Before ATK = {newStats.ATK} || After = {nextStats.ATK} Calculate = {totalStats.ATK} \n" +
            $"Before DEF = {newStats.DEF} || After = {nextStats.DEF} Calculate = {totalStats.DEF} \n" +
            $"Before HP = {newStats.HP} || After = {nextStats.HP} Calculate = {totalStats.HP} \n" +
            $"Before SPD = {newStats.SPD} || After = {nextStats.SPD} Calculate = {totalStats.SPD} \n");
    }
}
