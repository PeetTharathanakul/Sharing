using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectionController : MonoBehaviour
{
    public List<KaiJuBase> StatList;
    public List<GameObject> CollectList;

    public GameObject Collection;
    public GameObject Content;
    public GameObject CollectPrefab;
    private GameObject c;

    public static CollectionController current;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        SetCollection();
    }

    public void SetCollection()
    {
        var r = Resources.LoadAll<KaiJuBase>("Stat");
        for (int i = 0; i < r.Length; i++)
        {
            StatList.Add(r[i]);
        }

        for (int i = 0; i < StatList.Count; i++)
        {
            c = Instantiate(CollectPrefab, Content.transform);
            c.transform.parent = Content.transform;
            CollectList.Add(c);
            c.TryGetComponent<CollectionDetail>(out CollectionDetail detail);
            detail.thisBase = StatList[i];
            detail.Setdetail();
        }
    }

    public void Sorting()
    {
        List<KaiJuBase> l;
        l = StatList.OrderByDescending(StatList => StatList.CP).ToList();
        StatList = l;

        for (int i = 0; i < StatList.Count; i++)
        {
            CollectList[i].TryGetComponent<CollectionDetail>(out CollectionDetail detail);
            detail.thisBase = StatList[i];
            detail.Setdetail();
        }
    }

    public void SortGroup(string Base)
    {
        string check = "";
        for (int i = 0; i < CollectList.Count; i++)
        {
            CollectList[i].TryGetComponent<CollectionDetail>(out CollectionDetail detail);
            switch (detail.thisBase.Major)
            {
                case KaiJuGame.BaseMajor.Gradiator:
                    check = "Gradiator";
                    break;
                case KaiJuGame.BaseMajor.Destroyer:
                    check = "Destroyer";
                    break;
                case KaiJuGame.BaseMajor.Feather:
                    check = "Feather";
                    break;
                default:
                    break;
            }

            if(Base == check)
            {
                CollectList[i].SetActive(true);
            }
            else
            {
                CollectList[i].SetActive(false);
            }
        }
    }
}
