using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using KaiJuGame;
public class EndGame : MonoBehaviour
{
    [SerializeField] private List<ItemDetails> rewards;
    [SerializeField] private List<Items> rewardsDrop;

    [SerializeField] private GameObject displayUI;
    [SerializeField] private GameObject tapContinue;
    [SerializeField] private Image progress;
    [SerializeField] private TMPro.TextMeshProUGUI currentStageText;
    [SerializeField] private TMPro.TextMeshProUGUI nextStageText;

    [SerializeField] private int dlevel;
    [SerializeField] private int kaijuLevel;
    [SerializeField] private float stageId = 0.1f;
    [SerializeField] private float xp = 0.1f;

    [SerializeField] private int currentEXP = 0;
    [SerializeField] private Progression progression;

    [SerializeField] private float fakeEXP;

    private void Start()
    {
        ActiveDisplayUI();
    }

    bool isUpgrade;
    public void ActiveDisplayUI()
    {
        displayUI.gameObject.SetActive(true);
        ShowReward();
    }

    private void AvatarIncreaseXp(Image _avatar)
    {
        /*Level darkLoad = GameManager.Instance.levelDarklod;
        int modifire = ((darkLoad.exp * GameData.LEVEL) / 10);
        int scorePercen = modifire / 10;*/
        progress.fillAmount = dlevel-0.1f;
        StartCoroutine(SliderFillTube(true,_avatar, dlevel));

    }

    IEnumerator SliderFillTube(bool isDarkloard,Image slider,float targetHp)
    {
        Debug.Log(" slider   " + slider.fillAmount +"  :   target " + targetHp);

        if (slider.fillAmount >= 1)
        {
            if (isDarkloard)
            {
                dlevel += 1;
                kaijuLevel = dlevel;
                slider.fillAmount = 0;
            }
        }

        while (slider.fillAmount < targetHp)
        {
            slider.fillAmount += .5f * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        slider.fillAmount = targetHp;      
        
    }

   
    [ContextMenu("TestSlider")]
    public void TestSlider()
    {
        var lastLevel = progress.fillAmount;
        var currentKaijuPro = GameData.KAIJU;
        var expProgession = progression.GetPredicate(currentKaijuPro);
        var getLevel = progression.GetLevel(currentKaijuPro);

        Debug.Log("predicate degree     "+fakeEXP + "     >>>    " + expProgession);
        Debug.Log("percentage     "+fakeEXP/expProgession);
        Debug.Log("level     "+ getLevel);

        StartCoroutine(SliderFillTube(true,progress, GetPercentageByExp(fakeEXP,expProgession)));
    }

    private float GetPercentageByExp(float expIncrease, float maxIncrease)
    {
        var rateExp = (expIncrease / maxIncrease);
        return rateExp;
    }

    private void ShowReward()
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            var ran = Random.Range(0, rewardsDrop.Count);
            rewards[i].thisitem = rewardsDrop[ran];
            rewardsDrop[ran].Value += 1;
            rewards[i].SetDetail(true, 0);
        }
        currentStageText.text = $"Lv.{2}";
        StartCoroutine(SliderFillTube(false, progress,.5f));
    }

}

