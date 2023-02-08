using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    public GameObject content;
    public Type thisType;
    public float Maxpts;
    public Slider progressbar;
    public Text progessText;
    [SerializeField] private GameObject QuestPrefab;
    [SerializeField] private List<Quest> QuestList;
    public List<GameObject> QuestObjList;
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
            yield return null;
        }
        progressbar.value = 1;
        progessText.text = Maxpts + "/" + Maxpts;
        yield return null;
    }

    private float Checkpts(string type)
    {
        return PlayerPrefs.GetInt(type, 0);
    }
}

public enum Type
{
    None,
    Daily,
    Weekly,
}
