using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public List<Items> rewardlist;
    public List<int> rewardvalue;
    public GameObject content;
    public GameObject Rewardpopup;
    public GameObject itemprefab;
    public List<GameObject> contentlist;
    public GameObject r;
    public static Reward current;

    private void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    public void RewardSet()
    {
        Rewardpopup.SetActive(true);
        if(contentlist != null)
        {
            for (int i = 0; i < contentlist.Count; i++)
            {
                Destroy(contentlist[i]);
            }
        }

        for (int i = 0; i < rewardlist.Count; i++)
        {
            r = Instantiate(itemprefab, content.transform);
            contentlist.Add(r);
            r.TryGetComponent<ItemDetails>(out ItemDetails thisitem);
            content.transform.parent = thisitem.transform;
            thisitem.thisitem = rewardlist[i];
            thisitem.SetDetail(false, rewardvalue[i]);
        }
    }
}
