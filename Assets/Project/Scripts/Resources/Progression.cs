using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Progression", menuName = "Create Progression")]
public class Progression : ScriptableObject
{
    [SerializeField] List<float> levels = new List<float>();
    [SerializeField] float dummyPoint;
    float last;

    [ContextMenu("Gen")]
    public void Genarate()
    {
        levels.Add(500);
        last = levels[0];
        for (int i = 1; i < dummyPoint; i++)
        {
            levels.Add(Mathf.CeilToInt(last * 1.3f));
            last = levels[i];
        }
    }


    public float GetEXP(int i)
    {
        return levels[i];
    }

    public float GetPredicate(float expCompare)
    {
        var level =levels.Find(f => f >= expCompare);
        return level;
    }

    public float GetLevel(float expCompare)
    {
        var indexLevel = levels.FindIndex(f => f >= expCompare);
        return indexLevel;
    }
}
