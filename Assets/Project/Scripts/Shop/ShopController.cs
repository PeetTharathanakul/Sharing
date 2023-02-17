using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    public ProductList P_List;
    public GameObject ShopContent;
    private GameObject p;
    [SerializeField] private GameObject ProductPrefab;
    [SerializeField] private List<ProductDetails> P_Details;


    // Start is called before the first frame update
    void Start()
    {
        P_Details.Clear();
        for (int i = 0; i < P_List.List.Length; i++)
        {
            p = Instantiate(ProductPrefab, ShopContent.transform);
            p.transform.parent = ShopContent.transform;
            p.TryGetComponent<ProductDetails>(out ProductDetails Details);
            P_Details.Add(Details);
            Details.thisproduct = P_List.List[i];
        }
    }
}
