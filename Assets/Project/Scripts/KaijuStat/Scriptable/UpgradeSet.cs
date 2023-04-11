using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade/UpgradeList")]
public class UpgradeSet : ScriptableObject
{
    public thisset[] set;
}

[System.Serializable]
public class thisset
{
    public Items Upitem;
    public int value;
}
