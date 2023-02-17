using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemController : MonoBehaviour
{
    public GameObject ItemUI;
    public Items Item;
    [SerializeField] private Image ItemImage;
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private TextMeshProUGUI ItemDescription;
    [SerializeField] private TextMeshProUGUI ItemValue;
    public static ItemController current;

    private void Awake()
    {
        current = this;
    }

    public void SetItemDetail(Items thisi)
    {
        ItemUI.SetActive(true);
        ItemName.text = thisi.Name + "";
        ItemDescription.text = thisi.Description + "";
        ItemImage.sprite = thisi.ItemSprite;
        ItemValue.text = thisi.Value + "";
    }
}
