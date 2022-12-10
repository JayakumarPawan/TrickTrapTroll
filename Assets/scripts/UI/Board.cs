using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class Board : MonoBehaviour{

    // position
    public Vector3[] leftcardpos = {new Vector3(-433.7f, -243.5f, 0), 
                                    new Vector3(-432.02f, -243.5f, 0),
                                    new Vector3(-430.349f, -243.5f, 0),
                                    new Vector3(-433.7f, -245f, 0),
                                    new Vector3(-432.02f, -245f, 0),
                                    new Vector3(-430.349f, -245f, 0),
                                    new Vector3(-433.7f, -246.6f, 0),
                                    new Vector3(-432.02f, -246.6f, 0),
                                    new Vector3(-430.349f, -246.6f, 0)};
    public Vector3[] rightcardpos = {new Vector3(-432.88f, -243.5f, 0), 
                                    new Vector3(-431.2f, -243.5f, 0),
                                    new Vector3(-429.529f, -243.5f, 0),
                                    new Vector3(-432.88f, -245f, 0),
                                    new Vector3(-431.2f, -245f, 0),
                                    new Vector3(-429.529f, -245f, 0),
                                    new Vector3(-432.88f, -246.6f, 0),
                                    new Vector3(-431.2f, -246.6f, 0),
                                    new Vector3(-429.529f, -246.6f, 0)}; 
    public List<Area> Areas = new List<Area>();

    //select buttons
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;
    public Button b6;
    public Button b7;
    public Button b8;
    public Button b9;

    private int select = -1;

    public void b1OnClick(){
        select = 0;
        Debug.Log("board button 1 clicked");
    } 
    public void b2OnClick(){
        select = 1;
        Debug.Log("board button 2 clicked");
    } 
    public void b3OnClick(){
        select = 2;
        Debug.Log("board button 3 clicked");
    } 
    public void b4OnClick(){
        select = 3;
        Debug.Log("board button 4 clicked");
    } 
    public void b5OnClick(){
        select = 4;
        Debug.Log("board button 5 clicked");
    } 
    public void b6OnClick(){
        select = 5;
        Debug.Log("board button 6 clicked");
    } 
    public void b7OnClick(){
        select = 6;
        Debug.Log("board button 7 clicked");
    } 
    public void b8OnClick(){
        select = 7;
        Debug.Log("board button 8 clicked");
    } 
    public void b9OnClick(){
        select = 8;
        Debug.Log("board button 9 clicked");
    } 


    //game functions
    public void play(Card c, int id){
        if(select == -1){
            Debug.Log("board error: no index was selected");
            return;
        }

        if(c.id == 1){
            c.transform.localPosition = leftcardpos[select];
            Areas[select].CardArea[0] = c;
            Areas[select].AreaPower +=c.power;
            Debug.Log("board added p1 card to area " + select);
        }
        else if (c.id == 2){
            c.transform.localPosition = rightcardpos[select];
            Areas[select].CardArea[1] = c;
            Areas[select].AreaPower -=c.power;
            Debug.Log("board added p2 card to area " + select);
        }

    }

    // score stuff
    public int p1_score = 0;
    public int p2_score = 0;

    public TextMesh p1ScoreDisplayer;
    public TextMesh p2ScoreDisplayer;

    
    List<List<int>> patterns = new List<List<int>>{ new List<int>{0, 1, 2},
                                                    new List<int>{3, 4, 5},
                                                    new List<int>{6, 7, 8},
                                                    new List<int>{0, 3, 6},
                                                    new List<int>{1, 4, 7},
                                                    new List<int>{2, 5, 8},
                                                    new List<int>{0, 4, 8},
                                                    new List<int>{2, 4, 6}};
    public void UpdateScore()
    {
        for(int i = 0; i < 8; i++){
            bool p1controls = true;
            bool p2controls = true;
            int region_power = 0;
            for(int j = 0; j < 3; j++){
                if(Areas[i].CardArea[0] == null)
                    p1controls = false;
                if(Areas[i].CardArea[1] == null)
                    p2controls = false;
                region_power += Areas[i].AreaPower;
            }

            if(p1controls && region_power > 0){
                p1_score += region_power;
                Debug.Log("P1 scored in region: "+string.Join( ",", patterns[i]));
            }
            if(p2controls && region_power < 0){
                p2_score -= region_power;
                Debug.Log("P2 scored in region: "+string.Join( ",", patterns[i]));
            }
        }
        p1ScoreDisplayer.text = p1_score.ToString();
        p2ScoreDisplayer.text = p2_score.ToString();
    }


}