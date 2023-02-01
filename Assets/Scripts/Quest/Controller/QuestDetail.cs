using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDetail : MonoBehaviour
{
    public Quest thisquest;
    public Text Name;
    public Text[] Description;
    [SerializeField] private Button QuestButton;
    [SerializeField] private Slider Progression;
    [SerializeField] private GameObject RewardContent;
    [SerializeField] private GameObject RewardPrefab;
    private float CurrentCondition;

    private void Start()
    {
        QuestButton.interactable = false;
        SetDetail();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDetail()
    {
        Name.text = thisquest.name;
        Description[0].text = thisquest.Description;
        CurrentCondition = PlayerPrefs.GetInt(thisquest.Condition, 0);
        Description[1].text = CurrentCondition + "/" + thisquest.ConditionValue;
        Progression.value = CurrentCondition/thisquest.ConditionValue;
        ProgressionCheck();
        for (int i = 0; i < thisquest.rewards.Length; i++)
        {
            var r = Instantiate(RewardPrefab, RewardContent.transform);
            r.transform.parent = RewardContent.transform;
            r.TryGetComponent<ItemDetails>(out ItemDetails thisitem);
            thisitem.thisitem = thisquest.rewards[i].RewardItems;
            thisitem.SetDetail(thisquest.IsClaim);
        }
    }

    public void ProgressionCheck()
    {
        if(CurrentCondition >= thisquest.ConditionValue)
        {
            QuestButton.interactable = true;
            Progression.gameObject.SetActive(false);
        }
    }

    public void GetReward()
    {

    }
}
