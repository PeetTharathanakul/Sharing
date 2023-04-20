using System.Collections;
using System.Collections.Generic;
using KaiJuGame;
using UnityEngine;

[CreateAssetMenu(fileName = "Kaiju", menuName = "Create Stats")]
public class KaiJuBase : ScriptableObject
{
    [SerializeField] BaseMajor major;
    [SerializeField] FACTION faction;
    [Header("Name")]
    [SerializeField] private string kaijuName;

    [Space(10)]
    [Header("Health")]
    [SerializeField] float maxHp;

    [Space(10)]
    [Header("Stats")]
    [SerializeField] float pAtk;
    [SerializeField] float pDef;
    [SerializeField] float mAtk;
    [SerializeField] float mDef;
    [SerializeField] float dodge;
    [SerializeField] float cri = 10;
    [SerializeField] float atk_spd;

    [Space(10)]
    [Header("Ability")]
    [SerializeField] float speed;

    [Space(10)]
    [Header("Armor")]
    [SerializeField] float spGear;
    [SerializeField] float gear;
    public Gearset[] Kaijugear;

    [Space(10)]
    [Header("EXP")]
    [SerializeField] float level;
    public float CurrentExp;

    [Header("Rate")]
    public Rarity Rare;
    public int Rank = 0;
    public Sprite thissprite;
    public int SubRank = 5;

    public string Name { get => kaijuName; set => kaijuName = value; }

    public float MaxHp
    {
        get => maxHp;
        set => maxHp = value;
    }
    public float Attack { get => pAtk; set => pAtk = value; }
    public float Defense { get => pDef; set => pDef = value; }
    public float SpAttack { get => mAtk; set => mAtk = value; }
    public float SpDefense { get => mDef; set => mDef = value; }
    public float Dodge { get => dodge; set => dodge = value; }
    public float Armor { get => gear; set => gear = value; }
    public float ATK_SPD { get => atk_spd; set => atk_spd = value; }

    public bool IsSpAttack => mAtk > 0;

    public bool IsSpDefense => mDef > 0;

    public float Critical { get => cri; set => cri = value; }
    public float Speed { get => speed; set => speed = value; }
    public float Level { get => level; set => level = value; }
    public BaseMajor Major { get => major; set => major = value; }

    public void SetConfigStats(CustomBaseStats baseStats, int charaterLevel)
    {
        Major = baseStats.baseMajor;
        MaxHp = baseStats.GetStatsLevel(KaiJuGame.TypeStats.HP, charaterLevel);
        Attack = baseStats.GetStatsLevel(KaiJuGame.TypeStats.P_ATK, charaterLevel);
        Defense = baseStats.GetStatsLevel(KaiJuGame.TypeStats.P_DEF, charaterLevel);
        SpAttack = baseStats.GetStatsLevel(KaiJuGame.TypeStats.M_ATK, charaterLevel);
        SpDefense = baseStats.GetStatsLevel(KaiJuGame.TypeStats.M_DEF, charaterLevel);
        Critical = baseStats.GetStatsLevel(KaiJuGame.TypeStats.CRI, charaterLevel);
        Dodge = baseStats.GetStatsLevel(KaiJuGame.TypeStats.DOGE, charaterLevel);
        Speed = baseStats.GetStatsLevel(KaiJuGame.TypeStats.MOVE, charaterLevel);
        ATK_SPD = baseStats.GetStatsLevel(KaiJuGame.TypeStats.ATK_SPD, charaterLevel);
    }

    public bool IsReadyDoge(KaiJuBase opportunity)
    {
        int rnd = Random.Range(1, 100);
        Debug.Log("Dodge random  " + rnd + " >  " + (100 - opportunity.dodge));
        return rnd > (100 - opportunity.dodge);
    }

    public bool IsReadyCritical(KaiJuBase attacker)
    {
        int rnd = Random.Range(1, 100);
        Debug.Log("Cri random  " + rnd + " >  "  + (100 - attacker.cri));
        return rnd > (100 - attacker.cri);
    }

    public float GetAttack(KaiJuBase attacker)
    {
        var rndMATK = Random.Range(1, (mAtk * 0.85f) / 20);
        var rndATK = Random.Range(1, (pAtk * 0.85f) / 20);
        var _pATK = (pAtk * 1.0f);
        var _mATK = (mAtk * 1.0f);
        return attacker.IsSpAttack ? _mATK + rndMATK : _pATK + rndATK;
    }

    public float GetDefense(KaiJuBase attacker)
    {
        // P.ATK(1.0) + rand(1, (P.ATK(0.85) / 20))
        var rateP_DEF = (pDef * 0.85f) / 20;
        var rateM_DEF = (mDef * 0.85f) / 20;

        var rndMDEF = Random.Range(1, rateP_DEF);
        var rndDEF = Random.Range(1, rateM_DEF);
        var _pDEF = (pDef * 1.0f);
        var _mDEF = (mDef * 1.0f);

        //Debug.Log($"Defense Cals Step {kaijuName} \n" +
        //    $"base pDef {pDef} rate : {rateP_DEF}");
        //Debug.Log($"base mDef {mDef} rate :  {rateM_DEF}");

        //Debug.Log($"rnd_M_DEF {rndMDEF}");
        //Debug.Log($"rnd_P_DEF {rndDEF}");

        //Debug.Log($"cal M_DEF {_mDEF} => {_mDEF + rndMDEF}");
        //Debug.Log($"cal P_DEF {_pDEF} => {_pDEF + rndDEF}");

        return attacker.IsSpAttack ? _mDEF + rndMDEF : _pDEF + rndDEF;
    }

    [ContextMenu("CreateLevelGrowth")]
    public int FormulaLevelExponent(int level)
    {
        var multiply = (level * 25);
        var absolute = Mathf.RoundToInt(multiply + 200);
        Debug.Log("expo  " + Mathf.RoundToInt(multiply + 200));
        return absolute;
    }

    public float CP => IsSpAttack? (mAtk* 60 * ((atk_spd) / 100)) * 0.1f: (pAtk* 60 * ((atk_spd) / 100)) * 0.1f;


    public float GetSkillLevel(int skLv)
    {
        Dictionary<int, float> keySkill = new Dictionary<int, float>();
        return keySkill[skLv];
    }

    public float GetEXP(KaiJuBase attacker)
    {
        float atk = GetAttack(this);
        return (atk * 60 * ((ATK_SPD) / 100)) * 0.001f;
    }

    [System.Serializable]
    public class Gearset
    {
        public GearType type;
        public Items Gear;
    }
}

