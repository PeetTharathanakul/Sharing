using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skilldetail : MonoBehaviour
{
    public KaijuSkill thisskill;
    public Image skillimg;
    public TextMeshProUGUI skillname;
    public TextMeshProUGUI skilldetail;
    // Start is called before the first frame update

    void Start()
    {
        Setdetail();
    }


    public void Setdetail()
    {
        skillimg.sprite = thisskill.Skillimg;
        skillname.text = thisskill.Skillname;
        skilldetail.text = thisskill.Skilldetails;
    }

}
