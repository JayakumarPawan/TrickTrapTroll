using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public Card[] cards = new Card[3];
    public int select = -1;
    public Vector3[] highlightpos = {new Vector3(-456.93f, -118.02f, 0), new Vector3(-455.83f, -118.02f, 0), new Vector3(-454.73f, -118.02f, 0)};
    [SerializeField] Vector3[] cardpos = {new Vector3(-433.64f, -248.7f, 0), new Vector3(-431.81f, -248.7f, 0), new Vector3(-429.95f, -248.7f, 0)};

    public int id;

    public GameObject deck;
    public GameObject board;

    public GameObject highlight;
    
    public Button button1;
    public Button button2;  
    public Button button3; 

    public Button Drawbutton;
    public Button Endbutton;
    public void button1OnClick(){
        select = 0;
        highlight.SetActive(true);
        highlight.GetComponent<Transform>().localPosition = highlightpos[0];
        Debug.Log("button 1 clicked");
    }
    public void button2OnClick(){
        select = 1;
        highlight.SetActive(true);
        highlight.GetComponent<Transform>().localPosition = highlightpos[1];
        Debug.Log("button 2 clicked");
    }
    public void button3OnClick(){
        select = 2;
        highlight.SetActive(true);
        highlight.GetComponent<Transform>().localPosition = highlightpos[2];
        Debug.Log("button 3 clicked");
    }
    public void draw(){
        if(select != -1){
            Card c = deck.GetComponent<Deck>().draw();
            if (c != null){
                c.transform.localPosition = cardpos[select];
                c.id = id;
                cards[select] = c;
                return;
            }
            Debug.Log("Drew a null card");
            return;
            
        }
        Debug.Log("Drew card from hand " + id.ToString());
        return;
        
    }

    public void play(){
        if(select != -1 && cards[select] != null){
            Card c = cards[select];
            cards[select] = null;
            board.GetComponent<Board>().play(c, this.id);
            Debug.Log("played card " + select.ToString() + " from player "+id.ToString());
            return;
        }
        Debug.Log("selected invalid card");
        return;
        
    }

}