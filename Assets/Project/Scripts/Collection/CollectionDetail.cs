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
    public Image CharType;
    public TextMeshProUGUI CharName;
    public TextMeshProUGUI CharLv;
    public TextMeshProUGUI CharCP;
    [SerializeField] private Sprite[] FrameSet;
    [SerializeField] private Sprite[] RankSet;
    [SerializeField] private Sprite[] TypeSet;

    void Start()
    {
        //Setdetail();
    }

    public void Setdetail()
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

        switch (thisBase.Major)
        {
            case KaiJuGame.BaseMajor.Gradiator:
                CharType.sprite = TypeSet[0];
                break;
            case KaiJuGame.BaseMajor.Destroyer:
                CharType.sprite = TypeSet[1];
                break;
            case KaiJuGame.BaseMajor.Feather:
                CharType.sprite = TypeSet[2];
                break;
            default:
                break;
        }
        CharLv.text = "Lv." + thisBase.Level;
        CharName.text = thisBase.Name;
        CharCP.text = "" + thisBase.CP;
        CharRank.sprite = RankSet[thisBase.Rank - 1];
        CharRank.SetNativeSize();
    }
}
