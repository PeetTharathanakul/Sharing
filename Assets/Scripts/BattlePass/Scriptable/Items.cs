using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "BattlePass/Items")]
public class Items : ScriptableObject
{
    public ItemDetails[] Item;
}

[System.Serializable]
public class ItemDetails
{
    public string Name;
    public Sprite ItemSprite;
    public string Description;
    public int Value;
}
