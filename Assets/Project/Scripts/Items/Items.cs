using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Consume itemconsume;
    public Gear itemgear;

    public enum ItemType
    {
        None,
        Consume,
        Gear,
        Material
    }

    [System.Serializable]
    public class Consume
    {
        public string ConsumeType;
        public int Value;
    }

    [System.Serializable]
    public class Gear
    {
        public status[] stat;
    }
}


public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    SuperRare,
    UltraRare
}

[System.Serializable]
public class status
{
    public string Stat;
    public int Value;
}

