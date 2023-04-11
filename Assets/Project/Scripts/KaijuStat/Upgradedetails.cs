using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgradedetails : MonoBehaviour
{
    public Items thisitem;
    public int Upgradevalue;

    [Header("UI")]
    public Image itemimage;
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private TextMeshProUGUI ItemValue;
    [SerializeField] private Button thisbutton;

    public void SetDetail()
    {
        itemimage.sprite = thisitem.ItemSprite;
        ItemName.text = thisitem.Name;
        ItemValue.text = "Owned: "  + thisitem.Value;
        if(thisitem.Value <= 0)
        {
            thisbutton.interactable = false;
        }
    }

    public void useitem()
    {
        thisitem.Value -= 1;
        KaijuUpgrade.current.Upgradecal(Upgradevalue);
        SetDetail();
    }
}
