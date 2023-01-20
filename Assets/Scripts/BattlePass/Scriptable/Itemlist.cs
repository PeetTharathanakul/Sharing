using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List", menuName = "BattlePass/Items List")]
public class Itemlist : ScriptableObject
{
   public BPList[] BattlePassList;
}

[System.Serializable]
public class BPList
{
    public int Level;
    public Items normalItem;
    public bool normalClaim;
    public Items premiumItem;
    public bool premiumClaim;
}
