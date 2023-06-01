using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillcutin : MonoBehaviour
{
    public GameObject Cutprefab;
    public List<Animation> Cutinanimation;
    public List<Sprite> Shapesprite;
    public Image Cutinimg;
    public ParticleSystem Cutinparticle;

    public void Cutin(int index)
    {
        Cutinimg.sprite = Shapesprite[index];
        //Cutinparticle.shape.shapeType. = Shapesprite[index];
    }

}
