using System.Collections;
using System.Collections.Generic;
using KaiJuGame;
using UnityEngine;

[CreateAssetMenu(fileName = "Kaiju", menuName = "Create Stats")]
public class KaiJuBase : ScriptableObject
{
    [SerializeField] FACTION faction;
    [Header("Name")]
    [SerializeField] private string name;

    [Space(10)]
    [Header("Health")]
    [SerializeField] float maxHp;

    [Space(10)]
    [Header("Bonus")]
    [SerializeField] float bonusHp;
    [SerializeField] float bonus_p_atk;
    [SerializeField] float bonus_m_atk;
    [SerializeField] float bonus_p_def;
    [SerializeField] float bonus_m_def;

    [Space(10)]
    [Header("Stats")]
    [SerializeField] float p_atk;
    [SerializeField] float p_def;
    [SerializeField] float m_atk;
    [SerializeField] float m_def;
    [SerializeField] float dodge;
    [SerializeField] float hit = 100;
    [SerializeField] float cri = 10;

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
    [SerializeField] Rarity Rare;
    [SerializeField] float Rank;

    public string Name { get => name; set => name = value; }

    public float MaxHp
    {
        get => maxHp;
        set => maxHp = value;
    }
    public float Attack { get => p_atk; set => p_atk = value; }
    public float Defense { get => p_def; set => p_def = value; }
    public float SpAttack { get => m_atk; set => m_atk = value; }
    public float SpDefense { get => m_def; set => m_def = value; }
    public float Dodge { get => faction == FACTION.PLAYER ? dodge: 1; set => dodge = value; }
    public bool IsSpAttack
    {
        get
        {
            return m_atk > 0;
        }
    }

    public bool IsSpDefense
    {
        get
        {
            return m_def > 0;
        }
    }
    public float Critical { get => cri; set => cri = value; }
    public float Speed { get => speed; set => speed = value; }
    public float BaseHp { get => bonusHp; set => bonusHp = value; }
    public float Level { get => level; set => level = value; }
    public float Accuracy { get => hit; set => hit = value; }

    public bool CheckHitPercentage(KaiJuBase opponent, KaiJuBase attacker)
    {
        var total = attacker.Accuracy - opponent.Dodge;
        int rnd = Random.Range(1, Mathf.RoundToInt(total));

        Debug.Log("rnd  " + rnd + "  acc  " + attacker.Accuracy + "dodge   " + opponent.Dodge + "  cal " + Mathf.RoundToInt(total));
        if (total <= 0)
        {
            Debug.Log("zero chance %  ");
            return Random.Range(0, 3) <= 1;
        }        
        return true;
    }

    public float GetDefense(KaiJuBase opponent, KaiJuBase attacker)
    {
        if (attacker.IsSpAttack)
        {
            return opponent.m_def <= 0 ? opponent.p_def / 1.1f : opponent.m_def;
        }
        return opponent.p_def;
    }

    public float GetAttack(KaiJuBase opponent, KaiJuBase attacker)
    {
        if (opponent.IsSpAttack)
        {
            return attacker.m_atk <= 0 ? attacker.p_atk / 1.1f : attacker.m_atk;
        }
        return attacker.p_atk;
    }

    private bool TryToHit(KaiJuBase opp, KaiJuBase attacker)
    {
        var a_hit = attacker.hit;
        var b_dodge = opp.dodge;
        var rate = a_hit - b_dodge;
        var rand = Random.Range(1, 100);
        Debug.Log("ran   " + rand + " a   " + a_hit + "b   " + b_dodge + " rate   " + rate);
        if (rand <= rate)
        {
            return true;
        }
       
        return false;
    }


    public float TakeDamage(KaiJuBase opponent, KaiJuBase attacker, bool isDark = false)
    {
        var atk = GetAttack(opponent,attacker);
        var def = GetDefense(opponent,attacker);

        float attack = opponent.IsSpAttack ? attacker.SpAttack : attacker.Attack;
        float defense = opponent.IsSpAttack ? opponent.SpDefense : opponent.Defense;
        float modifiers = Random.Range(1, 51);
        float a = (atk - def);
        int damage = Mathf.FloorToInt((a * modifiers * 1)/100);
        Debug.Log("calcurator of" + " Defender "+ opponent.Name + " VS "+  " Attacker " + attacker.Name + "ATK : " + atk + "   " + "DEF : " + def + " = " + a * modifiers * 1);

        if (!isDark)
        {
            if (!TryToHit(opponent, attacker))
            {
                return 0;
            }
        }


        return damage;
    }


    private float GetDarklod(float value)
    {
        return Random.Range(value / 2, value);
    }   

    [ContextMenu("CreateLevelGrowth")]
    public int FormulaLevelExponent(int level)
    {
        var multiply = (level * 25);
        var absolute = Mathf.RoundToInt(multiply + 200);
        Debug.Log("expo  " + Mathf.RoundToInt(multiply + 200));
        return absolute;
    }

    public int CP
    {
        get
        {
            var P1 = (m_atk * 1.5f) + (1 + (Accuracy - 45) + maxHp) + (1 + p_def) + (1 + m_def);
            //Debug.Log($" {(spAttack * 1.5f)} + {(1 + (accuracy - 45) + maxHp)} + {(1 + defense)} + {(1 + spDefense) } = {P1/4}");
            //var P2 = Mathf.FloorToInt(1 + spGear + gear + 1 + gear + 2 + gear + 3 + skillLevel);
            return (int)(P1/4);
        }
    }

    public bool IsCritical()
    {
        return Random.Range(0, 100) < 10;
    }

    public float GetSkillLevel(int skLv)
    {
        Dictionary<int, float> keySkill = new Dictionary<int, float>();
        return keySkill[skLv];
    }
    //base stats
}









