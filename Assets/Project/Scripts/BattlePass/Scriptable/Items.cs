using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "BattlePass/Items")]
[System.Serializable]
public class Items : ScriptableObject
{
    public string Name;
    public Sprite ItemSprite;
    public string Description;
    public int Value;
}

