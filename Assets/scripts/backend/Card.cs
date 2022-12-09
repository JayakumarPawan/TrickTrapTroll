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

    // public void updatePower(int newPower){
    //     power = newPower;
    //     atkDisplayer.Text = newPower.ToString();
    // }

}