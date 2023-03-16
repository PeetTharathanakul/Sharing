using System.Collections;
using System.Collections.Generic;
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
        }
    }
}
