using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KaiJuGame;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skills/Create Skills")]
[System.Serializable]
public class KaijuSkill : ScriptableObject
{
    public string Skillname;
    public Sprite Skillimg;
    public string Skilldetails;
    public SkillType Type;
}
