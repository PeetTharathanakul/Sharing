using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectionDetail : MonoBehaviour
{
    public KaiJuBase thisBase;

    [Header ("UI")]
    public Image CharSprite;
    public Image CharFrame;
    public Image CharRank;
    [SerializeField] private Sprite[] FrameSet;
    [SerializeField] private Sprite[] RankSet;

    void Start()
    {
        Setdetail();
    }

    void Setdetail()
    {
        CharSprite.sprite = thisBase.thissprite;
        switch (thisBase.Rare)
        {
            case Rarity.Common:
                CharFrame.sprite = FrameSet[0];
                break;
            case Rarity.Uncommon:
                CharFrame.sprite = FrameSet[1];
                break;
            case Rarity.Rare:
                CharFrame.sprite = FrameSet[2];
                break;
            case Rarity.Epic:
                CharFrame.sprite = FrameSet[3];
                break;
            case Rarity.Legendary:
                CharFrame.sprite = FrameSet[4];
                break;
            default:
                break;
        }
        CharRank.sprite = RankSet[thisBase.Rank - 1];
    }
}
