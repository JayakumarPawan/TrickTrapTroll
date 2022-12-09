using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class Deck : MonoBehaviour
{
    [SerializeField] List<Card> deck = new List<Card>();
    private Vector3[] cardpos = {new Vector3(-436f, -243.8f, 0), new Vector3(-436f, -245f, 0), new Vector3(-436f, -246.2f, 0)};
    [SerializeField] Button c1;
    [SerializeField] Button c2;
    [SerializeField] Button c3;
    private int selectIndex;

    public List<Card> choose = new List<Card>();

    public void draw3(){
        while(choose.Count <3){
            choose.Add(deck[deck.Count - 1]); 
            deck.RemoveAt(deck.Count - 1);
        }
        for(int i =0; i < 3; i++){
            this.choose[i].transform.localPosition = cardpos[i];
        }
    }

    public void select1(){
        selectIndex = 0;
    }
    public void select2(){
        selectIndex = 1;
    }
    public void select3(){
        selectIndex = 2;
    }
    public Card draw(){
        if(selectIndex != -1 && choose.Count > selectIndex){
            Card ret = choose[selectIndex];
            choose.RemoveAt(selectIndex);
            return ret;
        }
        return null;
    }


}