using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Progressreward", menuName = "Quest/Creat Progress Reward")]
[System.Serializable]
public class ProgressReward : ScriptableObject
{
    public List[] RewardList;
    [ContextMenu("Clear")]
    public void Clear()
    {
        foreach (List list in RewardList)
        {
            list.IsClaim = false;
        }
    }
}

[System.Serializable]
public class List
{
    public float Progressrequire;
    public bool IsClaim;
    public RewardList[] RewardItems;
}
