using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KaiJuGame;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Create Items")]
[System.Serializable]
public class Items : ScriptableObject
{
    public string Name;
    public Sprite ItemSprite;
    public string Description;
    public int Value;
    public Rarity Rate;
    public ItemType itemtype;
    public Supplies itemsupplies;
    public Gear itemgear;

    public enum ItemType
    {
        None,
        Supplies,
        Gear,
        Material
    }

    [System.Serializable]
    public class Supplies
    {
        public Items SuppliesType;
        public int Value;
    }

    [System.Serializable]
    public class Gear
    {
        public bool IsEquip;
        public int Rank;
        public GearType type;
        public status[] stat;
    }
}


[System.Serializable]
public class status
{
    public string Stat;
    public int Value;
}

