using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemDetails : MonoBehaviour , IPointerClickHandler
{
    public Items thisitem;
    public Toggle itemToggle;
    public TextMeshProUGUI valuetext;

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemController.current.SetItemDetail(thisitem);
        //throw new System.NotImplementedException();
    }

    public void SetDetail(bool claim, int value)
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
        if(valuetext)
            valuetext.text = "x" + value;
    }

    
}
