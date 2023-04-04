using System.Collections.Generic;

namespace KaiJuGame
{
    public enum EffectType
    {
        TAP,
        TAP_EXTRA,
        AUTO,
        AUTO_EXTRA,
        BULLETS,
        TEXT_DAMAGED,
        BOMB
    }
    public enum GameStage
    {
        NONE,
        INIT,
        SKILL,
        BATTLE,
        REST,
        DECIDE,
        PASS,
        VICTORY,
        LOSE
    }

    public enum CharacterState { Spawn, Chase, UsingAbility }

    public enum Rarity { CM, UN_CM, RARE, EPIC, LG }

    public enum AnimationBehevior
    {
        idle,
        attack,
        skill,
        damaged,
        dead
    }

    public enum GachaType { CHAR, ITEM };

    public interface IDamage
    {
        void Damage(float dmg);
    }
    public enum FACTION
    {
        PLAYER,
        ENEMY,
        BUILDING,
        FUEL
    }

    public enum LevelType
    {
        KAIJU,
        DARKLOD,
    }
    public enum StateSelect { NONE, SELECT, DEPLOY }

    public enum BaseMajor
    {
        Gradiator,
        Destroyer,
        Feather,
        Enemy_T,
        Enemy_H
    }
    public enum TypeStats { HP, P_ATK, P_DEF, MOVE, CRI, DOGE, M_ATK, M_DEF, ATK_SPD }

    public enum Stats
    {
       experiences,
       character
    }

    [System.Serializable]
    public class LevelSetting
    {
        public List<float> listValue;
    }

    public interface IProgression
    {
        float ATK();
        float DEF();
        BaseMajor BaseMajor();
    }

    public enum SkillPos { head, body, feet }
}
