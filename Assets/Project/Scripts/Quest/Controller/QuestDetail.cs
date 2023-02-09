using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDetail : MonoBehaviour
{
    [Header("Detail")]
    public Quest thisquest;
    public Text Name;
    public Text[] Description;

    [Header("Reward")]
    public GameObject RewardContent;
    public GameObject RewardPrefab;
    public List<ItemDetails> RewardList;

    [Header("UI")]
    public Button QuestButton;
    [SerializeField] private Slider Progression;
    public GameObject Fade;
    private GameObject r;
    private float CurrentCondition;

    public void SetDetail()
    {
        Name.text = thisquest.name;
        Description[0].text = thisquest.Description;
        CheckCondition();
        Progression.value = CurrentCondition/thisquest.ConditionValue;
        
        for (int i = 0; i < thisquest.rewards.Length; i++)
        {
            r = Instantiate(RewardPrefab, RewardContent.transform);
            r.TryGetComponent<ItemDetails>(out ItemDetails thisitem);
            RewardContent.transform.parent = thisitem.transform;
            RewardList.Add(thisitem);
            thisitem.thisitem = thisquest.rewards[i].RewardItems;
            thisitem.SetDetail(thisquest.IsClaim);
        }
        StartCoroutine(ProgressionCheck());
    }

    private float CheckCondition()
    {
        CurrentCondition = PlayerPrefs.GetInt(thisquest.Condition, 0);
        return CurrentCondition;
    }

    public IEnumerator ProgressionCheck()
    {
        while (!thisquest.IsClaim)
        {
            if (CheckCondition() >= thisquest.ConditionValue && !thisquest.IsClaim)
            {
                QuestButton.interactable = true;
                Progression.gameObject.SetActive(false);
            }
            else
            {
                Description[1].text = CurrentCondition + "/" + thisquest.ConditionValue;
                Progression.value = CurrentCondition / thisquest.ConditionValue;
                QuestButton.interactable = false;
            }
            yield return null;
        }
        Fade.SetActive(true);
        QuestButton.interactable = false;
        Progression.gameObject.SetActive(false);
        gameObject.transform.SetAsLastSibling();
    }

    public void GetReward()
    {
        if(thisquest.QuestPoint > 0)
        {
            ProgressReward();
        }
        thisquest.IsClaim = true;
        Reward.current.rewardlist.Clear();
        for (int i = 0; i < RewardList.Count; i++)
        {
            RewardList[i].SetDetail(thisquest.IsClaim);
            Reward.current.rewardlist.Add(RewardList[i].thisitem);
            Debug.Log("Getitems" + i);
        }
        Reward.current.RewardSet();
    }

    public void ProgressReward()
    {
        int i;
        switch (thisquest.questType)
        {
            case QuestType.Daily:
                i = PlayerPrefs.GetInt("Daily", 0) + thisquest.QuestPoint;
                PlayerPrefs.SetInt("Daily", i);
                break;
            case QuestType.Weekly:
                i = PlayerPrefs.GetInt("Weekly", 0) + thisquest.QuestPoint;
                PlayerPrefs.SetInt("Weekly", i);
                break;
            case QuestType.BattlePass:
                //Battlepass.current.ProgressCheck(thisquest.QuestPoint);
                break;
            default:
                break;
        }
    }
}
