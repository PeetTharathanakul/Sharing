using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    public GameObject content;
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
    }

    public void Forchecking(string condition)
    {
        int c = PlayerPrefs.GetInt(condition, 0);
        c += 1;
        PlayerPrefs.SetInt(condition, c);
    }
}
