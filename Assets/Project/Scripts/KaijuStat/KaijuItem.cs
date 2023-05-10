using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KaijuItem : MonoBehaviour
{
    public KaiJuBase thisbase;
    public GameObject content;
    public GameObject Gear;
    private GameObject o;
    private int check;

    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject itemprefab;
    [SerializeField] private List<Items> Gearlist;
    [SerializeField] private List<GearDetail> Gearobj; 

    [Header("UI")]
    public Image[] GearImg;

    public static KaijuItem current;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        Gearlist.AddRange(Resources.LoadAll<Items>("Inventory/Gear"));
        Setcontent();
        //SetGear();
    }

    public void OnKaijuStateChanged(KaiJuBase kaiju, CustomBaseStats customBase)
    {
        thisbase = kaiju;
        SetGear();
    }

    public void SetGear()
    {
        for (int i = 0; i < 4; i++)
        {
            if (thisbase.Kaijugear[i].Gear)
            {
                GearImg[i].sprite = thisbase.Kaijugear[i].Gear.ItemSprite;
                GearImg[i].gameObject.SetActive(GearImg[i].sprite != null);
            }
        }

    }

    public void Setcontent()
    {
        for (int i = 0; i < Gearlist.Count; i++)
        {
            o = Instantiate(itemprefab, content.transform);
            o.transform.parent = content.transform;
            o.TryGetComponent<GearDetail>(out GearDetail d);
            d.thisitem = Gearlist[i];
            Gearobj.Add(d);
            d.Setdetails();
        }
    }

    public void SetGearcontent(int slot)
    {
        for (int i = 0; i < Gearobj.Count; i++)
        {
            switch (Gearobj[i].thisitem.itemgear.type)
            {
                case KaiJuGame.GearType.offensive:
                    check = 0;
                    break;
                case KaiJuGame.GearType.defensive:
                    check = 1;
                    break;
                case KaiJuGame.GearType.support:
                    check = 2;
                    break;
                case KaiJuGame.GearType.special:
                    check = 3;
                    break;
            }
            if (check == slot)
                Gearobj[i].gameObject.SetActive(true);
            else
                Gearobj[i].gameObject.SetActive(false);
        }
        check = slot;
        popup.SetActive(true);
    }

    public void SetGearKaiju()
    {
        thisbase.Kaijugear[check].Gear = Gear.GetComponent<GearDetail>().thisitem;
        GearImg[check].sprite = Gear.GetComponent<GearDetail>().thisitem.ItemSprite;
        GearImg[check].gameObject.SetActive(GearImg[check].sprite != null);
    }

}
