using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    public int power;
    public int id; // 0 nobody, 1:p1, 2:p2
    [SerializeField] TextMesh atkDisplayer;
    [SerializeField] Transform transform;

    public void UpdatePower(int newPower){
        power = newPower;
        atkDisplayer.text = newPower.ToString();
    }

    public void OnStart(){
        UpdatePower(this.power);
    }

}