using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    public Items thisitem;

    [SerializeField] private Sprite[] itemframe;
    [SerializeField] private Image thisframe;
    [SerializeField] private Image itemsprite;
    [SerializeField] private TextMeshProUGUI itemvalue;
    private Button thisbutton;

    // Start is called before the first frame update
    void Start()
    {
        thisbutton = gameObject.GetComponent<Button>();
        SetDetail();
        thisbutton.onClick.AddListener(() => InventoryDetails.current.SetDetails(thisitem));
    }

    private void OnEnable()
    {
        if(thisitem)
            StartCoroutine(ValueUpdate());
    }

    private void SetDetail()
    {
        switch (thisitem.Rate)
        {
            case KaiJuGame.Rarity.CM:
                thisframe.sprite = itemframe[0];
                break;
            case KaiJuGame.Rarity.UN_CM:
                thisframe.sprite = itemframe[1];
                break;
            case KaiJuGame.Rarity.RARE:
                thisframe.sprite = itemframe[2];
                break;
            case KaiJuGame.Rarity.EPIC:
                thisframe.sprite = itemframe[3];
                break;
            case KaiJuGame.Rarity.LG:
                thisframe.sprite = itemframe[4];
                break;
            default:
                break;
        }

        itemsprite.sprite = thisitem.ItemSprite;
        StartCoroutine(ValueUpdate());

    }

    IEnumerator ValueUpdate()
    {
        while(thisitem.Value > 0)
        {
            itemvalue.text = "x" + thisitem.Value;
            yield return null;
        }
    }
}
