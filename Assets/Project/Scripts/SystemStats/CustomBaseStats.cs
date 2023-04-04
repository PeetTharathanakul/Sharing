using System.Collections;
using System.Collections.Generic;
using KaiJuGame;
using UnityEngine;

[CreateAssetMenu(fileName ="custom base stats")]
public class CustomBaseStats : ScriptableObject
{    
    public TypeStats typeStats;
    public BaseMajor baseMajor;

    [Space(10)]
    [Header("BaseStats")]
    public BaseStaticStats HP;
    public BaseStaticStats ATK;
    public BaseStaticStats DEF;
    public BaseStaticStats Move;
    public BaseStaticStats CRI;
    public BaseStaticStats DOGE;
    public BaseStaticStats M_ATK;
    public BaseStaticStats M_DEF;
    public BaseStaticStats ATK_SPD;

    [Space(10)]
    [Header("FormulaProgression")]
    public List<float> listHP = new List<float>();
    public List<float> listP_ATK = new List<float>();
    public List<float> listP_DEF = new List<float>();
    public List<float> listMOVE = new List<float>();
    public List<float> listCRI = new List<float>();
    public List<float> listDOGE = new List<float>();
    public List<float> listM_ATK = new List<float>();
    public List<float> listM_DEF = new List<float>();
    public List<float> listATK_SPD = new List<float>();

    public int step = 1;
    public int rank = 1;

    [SerializeField]private float rateMove = 0.005f;
    [SerializeField]private bool isMagic = false;

    [ContextMenu("GenerateStats")]
    public void GenarateHP()
    {
        for (int i = 0; i < 30; i++)
        {
            switch (typeStats)
            {
                case TypeStats.HP:
                listHP.Add(HP.Formular(i,step));
                    break;
                case TypeStats.P_ATK:
                    listP_ATK.Add(ATK.Formular(i, step));
                    break;
                case TypeStats.P_DEF:
                    listP_DEF.Add(DEF.Formular(i, step));
                    break;
                case TypeStats.MOVE:
                    listMOVE.Add(Move.FormularMove(i,rateMove, step));
                    break;
                case TypeStats.CRI:
                    listCRI.Add(CRI.Formular(i, step));
                    break;
                case TypeStats.DOGE:
                    listDOGE.Add(DOGE.Formular(i, step));
                    break;
                case TypeStats.M_ATK:
                    listM_ATK.Add(M_ATK.Formular(i, step));
                    break;
                case TypeStats.M_DEF:
                    listM_DEF.Add(M_DEF.Formular(i, step));
                    break;
                case TypeStats.ATK_SPD:
                    listATK_SPD.Add(ATK_SPD.FormularATK_SPD(i, step));
                    break;
            }
        }
    }

    public float GetStatsLevel(TypeStats type, int customRank = 0, int customStep = 0)
    {
        rank = customRank;
        step = customStep;
        switch (type)
        {
            case TypeStats.HP:
                return HP.Formular(rank,step);
            case TypeStats.P_ATK:
                return ATK.Formular(rank, step);
            case TypeStats.M_ATK:
                return M_ATK.Formular(rank, step);
            case TypeStats.P_DEF:
                return DEF.Formular(rank, step);
            case TypeStats.M_DEF:
                return M_DEF.Formular(rank, step);
            case TypeStats.MOVE:
                return Move.FormularMove(rank,rateMove, step);
            case TypeStats.DOGE:
                return DOGE.Formular(rank, step);
            case TypeStats.CRI:
                return CRI.Formular(rank, step);
            case TypeStats.ATK_SPD:
                return ATK_SPD.FormularATK_SPD(rank, step);
        }
        return 0;
    }

    public float ModifireDMG(int baseDamage)
    {
        return (baseDamage * 1.1f);
    }

    #region Envole
    public Stats GetEnvole(int rank, int stepRank)
    {
        // A = base value rank
        // B = next rank

        var _pATK = GetRank(rank, stepRank, TypeStats.P_ATK);
        var _mATK = GetRank(rank, stepRank, TypeStats.M_ATK);
        var _pDEF = GetRank(rank, stepRank, TypeStats.P_DEF);
        var _mDEF = GetRank(rank, stepRank, TypeStats.M_DEF);
        var _HP = GetRank(rank, stepRank, TypeStats.HP);
        var _atkSPD = GetRank(rank, stepRank, TypeStats.ATK_SPD);

        var newCP = GetCP(_mATK, _atkSPD, _pATK);

        Stats afterStats = new Stats(newCP, _pDEF, _HP, _atkSPD);
        return afterStats;
    }

    public float GetRank(int rank, int stepRank, TypeStats typeStats)
    {
        return GetStatsLevel(typeStats, rank, stepRank);
    }

    public float GetCP(float mATK, float atk_SPD, float pATK)
    {
        return isMagic ? (mATK * 60 * ((atk_SPD) / 100)) * 0.1f : (pATK * 60 * ((atk_SPD) / 100)) * 0.1f;
    }
    #endregion
}

[System.Serializable]
public class BaseStaticStats
{
    public int value;
    public float rate;

    public float Formular(int levelProgress, int step)
    {
        return value + (value * rate * (levelProgress + 1)) + ((value * step) * 0.1f);
    }

    public float FormularMove(int levelProgress, float rateMove, int step)
    {
        return value + (value * rate * (levelProgress + 1)) + ((value * step) * rateMove);
    }


    public float FormularATK_SPD(int levelProgress, int step)
    {
        return value + (value * rate * (levelProgress + 1)) + ((value * step) * 0.0025f);
    }
}

