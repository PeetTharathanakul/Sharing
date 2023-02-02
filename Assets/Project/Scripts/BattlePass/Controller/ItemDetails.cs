using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetails : MonoBehaviour
{
    public Items thisitem;
    public Toggle itemToggle;
    public Text valuetext;

    public void SetDetail(bool claim)
    {
        itemToggle.targetGraphic.GetComponent<Image>().sprite = thisitem.ItemSprite;
        if (claim)
        {
            itemToggle.isOn = true;
        }
        else
        {
            itemToggle.isOn = false;
        }
        valuetext.text = "x" + thisitem.Value;
    }
}
