using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    [Header("Details")]
    public Type thisType;
    public float Maxpts;

    [Header("UI")]
    public Slider progressbar;
    public Text progessText;
    public Button[] rewardbutton;

    [Header("Object")]
    public GameObject content;
    [SerializeField] private GameObject QuestPrefab;
    [SerializeField] private List<Quest> QuestList;
    [HideInInspector] public List<GameObject> QuestObjList;
    [SerializeField] private ProgressReward P_Reward;
    private GameObject r;

    void Start()
    {
        QuestObjList.Clear();
        for (int i = 0; i < QuestList.Count; i++)
        {
            r = Instantiate(QuestPrefab, content.transform);
            r.TryGetComponent<QuestDetail>(out QuestDetail q);
            r.transform.parent = content.transform;
            q.thisquest = QuestList[i];
            q.SetDetail();
            QuestObjList.Add(r);
        }

        switch (thisType)
        {
            case Type.None:
                break;
            case Type.Daily:
                StartCoroutine(CheckProgress("Daily"));
                break;
            case Type.Weekly:
                StartCoroutine(CheckProgress("Weekly"));
                break;
            default:
                break;
        }
    }

    public void Forchecking(string condition)
    {
        int c = PlayerPrefs.GetInt(condition, 0);
        c += 1;
        PlayerPrefs.SetInt(condition, c);
    }

    IEnumerator CheckProgress(string type)
    {
        while (Checkpts(type) < Maxpts)
        {
            progessText.text = Checkpts(type) + "/" + Maxpts;
            progressbar.value = Checkpts(type) / Maxpts;
            ProgressReward(type);
            yield return null;
        }
        progressbar.value = 1;
        progessText.text = Maxpts + "/" + Maxpts;
        ProgressReward(type);
        yield return null;
    }

    private float Checkpts(string type)
    {
        return PlayerPrefs.GetInt(type, 0);
    }

    public void ProgressReward(string type)
    {
        for (int i = 0; i < P_Reward.RewardList.Length; i++)
        {
            if(Checkpts(type) >= P_Reward.RewardList[i].Progressrequire && !P_Reward.RewardList[i].IsClaim)
            {
                rewardbutton[i].interactable = true;
            }
            else
            {
                rewardbutton[i].interactable = false;
            }
        }
    }

    public void GetReward(int num)
    {
        Reward.current.rewardlist.Clear();
        Reward.current.rewardvalue.Clear();
        var p = P_Reward.RewardList[num];
        p.IsClaim = true;
        rewardbutton[num].interactable = false;
        for (int i = 0; i < p.RewardItems.Length; i++)
        {
            Reward.current.rewardlist.Add(p.RewardItems[i].RewardItems);
            Reward.current.rewardvalue.Add(p.RewardItems[i].Value);
            p.RewardItems[i].RewardItems.Value += p.RewardItems[i].Value;
        }
        Reward.current.RewardSet();
    }
}

public enum Type
{
    None,
    Daily,
    Weekly,
}
