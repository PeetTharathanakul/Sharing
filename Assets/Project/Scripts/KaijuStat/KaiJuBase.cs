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

    [Space(10)]
    [Header("EXP")]
    [SerializeField] float level;

    [Header("Rate")]
    [SerializeField] public Rarity Rare;
    [SerializeField] public int Rank;
    [SerializeField] public Sprite thissprite;

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

    public bool IsReadyDoge()
    {
        int rnd = Random.Range(1, 100);
        Debug.Log("Dodge random  " + rnd + " >  " + (100 - dodge));
        return rnd > (100 - dodge);
    }

    public bool IsReadyCritical()
    {
        int rnd = Random.Range(1, 100);
        Debug.Log("Cri random  " + rnd + " >  "  + (100 - cri));
        return rnd > (100 - cri);
    }

    public float GetDefense()
    {
        // P.ATK(1.0) + rand(1, (P.ATK(0.85) / 20))
        return IsSpDefense? mDef + Random.Range(1, ((pDef * 0.85f) / 20)) : pDef + Random.Range(1, ((pDef * 0.85f) / 20));
    }

    public float GetAttack(KaiJuBase attacker)
    {
        // P.ATK(1.0) + rand(1, (P.ATK(0.85) / 20))
        return attacker.IsSpAttack ? attacker.mAtk + Random.Range(1, ((attacker.pAtk * 0.85f) / 20)) : attacker.pAtk + Random.Range(1,((attacker.pAtk * 0.85f) / 20));
    }

    [ContextMenu("CreateLevelGrowth")]
    public int FormulaLevelExponent(int level)
    {
        var multiply = (level * 25);
        var absolute = Mathf.RoundToInt(multiply + 200);
        Debug.Log("expo  " + Mathf.RoundToInt(multiply + 200));
        return absolute;
    }

    public float CP => IsSpAttack? (mAtk* 60 * ((atk_spd) / 100)) * 0.001f: (pAtk* 60 * ((atk_spd) / 100)) * 0.001f;
  
    public float GetSkillLevel(int skLv)
    {
        Dictionary<int, float> keySkill = new Dictionary<int, float>();
        return keySkill[skLv];
    }

    public int DamageCalcurate(KaiJuBase attacker, bool isDark = false)
    {
        if (IsReadyDoge())
        {
            Debug.Log("Miss ");
            return 0;
        }
        else
        {
            var atk = GetAttack(attacker);
            var def = GetDefense();
            float modifiers = atk - def;
            int damage = Mathf.FloorToInt(modifiers);
            Debug.Log("calcurator of" + " Defender " + Name + " VS " + " Attacker " + attacker.Name + "ATK : " + atk + "   " + "DEF : " + def + " = " + modifiers);

            return IsReadyCritical() ? damage *= 2:damage;
        }
    }

    public float GetEXP(KaiJuBase attacker)
    {
        float atk = GetAttack(attacker);

        return (atk * 60 * ((ATK_SPD) / 100)) * 0.001f;
    }
}