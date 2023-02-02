using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List", menuName = "BattlePass/Items List")]
public class Itemlist : ScriptableObject
{
   public BPList[] BattlePassList;

    [ContextMenu("Clear")]
    public void Clear()
    {
        foreach (BPList list in BattlePassList)
        {
            list.isClaim = false;
            list.currentpts = 0;
        }
    }
}

[System.Serializable]
public class BPList
{
    public float currentpts;
    public int Level;
    public bool isClaim;
    public Items normalItem;
    public Items premiumItem;
}
