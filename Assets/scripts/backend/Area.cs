using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class Area : MonoBehaviour
{
    public string AreaName;
    public int AreaNumber;
    public SpriteRenderer sprite;
    public string effect_description;
 
    public Card[] CardArea = new Card[2];

    public int AreaPower = 0;
    public Area(int a){
        AreaNumber = a;
    }




}