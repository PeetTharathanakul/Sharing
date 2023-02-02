using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Create Quest")]
[System.Serializable]
public class Quest : ScriptableObject
{
    [Header("Details")]
    public string Name;
    public QuestType questType;
    public string Description;
    public string Condition;
    public float ConditionValue;

    [Header("Reward")]
    public bool IsClaim;
    public int QuestPoint;
    public RewardList[] rewards;
}

public enum QuestType
{
    Daily,
    Weekly,
    Main,
    Progression,
    BattlePass
}

[System.Serializable]
public class RewardList
{
    public Items RewardItems;
    public int Value;
}
