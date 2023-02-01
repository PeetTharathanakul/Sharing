using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDetail : MonoBehaviour
{
    public Quest thisquest;
    public Text Name;
    public Text Description;
    [SerializeField] private Slider Progression;
    [SerializeField] private GameObject RewardContent;
    [SerializeField] private GameObject RewardPrefab;
    private float CurrentCondition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDetail()
    {
        Name.text = thisquest.name;
        Description.text = thisquest.Description;
        CurrentCondition = PlayerPrefs.GetInt(thisquest.Condition, 0);
        Progression.value = CurrentCondition/thisquest.ConditionValue;
        for (int i = 0; i < thisquest.rewards.Length; i++)
        {
            var r = Instantiate(RewardPrefab, RewardContent.transform);
            r.transform.parent = RewardContent.transform;
        }
    }
}
