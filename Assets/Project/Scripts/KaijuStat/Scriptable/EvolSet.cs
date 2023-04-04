using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Evole", menuName = "Evole/EvoleList")]
public class EvolSet : ScriptableObject
{
    public Ranklist[] Ranklist;
}

[System.Serializable]
public class Ranklist
{
    public int Rank;
    public SubRank[] Sublist;
}

[System.Serializable]
public class SubRank
{
    public int KaijuMat;
    public int GoldValue;
}

