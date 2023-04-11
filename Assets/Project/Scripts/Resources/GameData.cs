using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    //public static PlayerData PlayerData;
    public static CurrencyType currencyType;
    private static int _level = 1;
    public static bool isTesting = false;
    private static int stageID = 0;
    private static int worldID = 0;
    private static int golds = 0;
    private static int gems = 0;
    private static int crystal = 0;

    private const string KEY_EXP_KAIJU = "EXP/KAIJU";
    private const string KEY_EXP_DARKLORD = "EXP/DARKLORD";
    private const string KEY_GEMS = "ASSETS/GEMS";
    private const string KEY_GOLD = "ASSETS/GOLD";
    private const string KEY_CRYSTAL = "ASSETS/CRYSTAL";
    private const string KEY_LEVEL = "PLAYER/LEVEL";
    private const string KEY_WORLD = "PLAYER/WORLD";
    private const string KEY_STAGE = "PLAYER/STAGE";

    private static int _exp_darkload = 1;
    private static int _exp_kaiju = 1;

    public static float DARKLORD
    {
        get { return PlayerPrefs.GetInt(KEY_EXP_DARKLORD) * 0.1f; }
        set { PlayerPrefs.SetInt(KEY_EXP_DARKLORD, _exp_darkload); }
    }

    public static float KAIJU
    {
        get { return PlayerPrefs.GetInt(KEY_EXP_KAIJU); }
        set { PlayerPrefs.SetInt(KEY_EXP_KAIJU, _exp_kaiju); }
    }

    public static int LEVEL
    {
        get { return PlayerPrefs.GetInt(KEY_LEVEL); }
        set { PlayerPrefs.SetInt(KEY_LEVEL, _level); }
    }

    public static int GEMS
    {
        get { return PlayerPrefs.GetInt(KEY_GEMS); }
        set { PlayerPrefs.SetInt(KEY_GEMS, value); }
    }

    public static int GOLDS
    {
        get { return PlayerPrefs.GetInt(KEY_GOLD); }
        set { PlayerPrefs.SetInt(KEY_GOLD, value); }
    }

    public static int CRYSTAL
    {
        get { return PlayerPrefs.GetInt(KEY_CRYSTAL); }
        set { PlayerPrefs.SetInt(KEY_CRYSTAL, crystal); }
    }

    public static int STAGE
    {
        get { return PlayerPrefs.GetInt(KEY_STAGE); }
        set {
            stageID = value;
            PlayerPrefs.SetInt(KEY_STAGE,stageID ); }
    }

    public static int WORLD
    {
        get { return PlayerPrefs.GetInt(KEY_WORLD); }
        set { PlayerPrefs.SetInt(KEY_WORLD, worldID); }
    }

}

