using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GearDetail : MonoBehaviour
{
    public Items thisitem;

    public Image itemsprite;
    public Image itemframe;
    public GameObject itemselect;
    [SerializeField] private Sprite[] frameset;

    public void Setdetails()
    {
        itemsprite.sprite = thisitem.ItemSprite;
        switch (thisitem.Rate)
        {
            case KaiJuGame.Rarity.CM:
                itemframe.sprite = frameset[0];
                break;
            case KaiJuGame.Rarity.UN_CM:
                itemframe.sprite = frameset[1];
                break;
            case KaiJuGame.Rarity.RARE:
                itemframe.sprite = frameset[2];
                break;
            case KaiJuGame.Rarity.EPIC:
                itemframe.sprite = frameset[3];
                break;
            case KaiJuGame.Rarity.LG:
                itemframe.sprite = frameset[4];
                break;
            default:
                break;
        }
    }

    public void Setthis()
    {
        if (KaijuItem.current.Gear)
        {
            KaijuItem.current.Gear.GetComponent<GearDetail>().itemselect.SetActive(false);
        }
        KaijuItem.current.Gear = gameObject;
        itemselect.SetActive(true);
    }
    
}
