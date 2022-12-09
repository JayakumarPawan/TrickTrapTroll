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
                                    new Vector3(-432.02f, -245, 0),
                                    new Vector3(-430.349f, -245, 0),
                                    new Vector3(-433.7f, -246.6, 0),
                                    new Vector3(-432.02f, -246.6, 0),
                                    new Vector3(-430.349f, -246.6, 0)};
    public Vector3[] rightcardpos = {new Vector3(-432.88f, -243.5f, 0), 
                                    new Vector3(-431.2f, -243.5f, 0),
                                    new Vector3(-429.529f, -243.5f, 0),
                                    new Vector3(-432.88f, -245f, 0),
                                    new Vector3(-431.2f, -245f, 0),
                                    new Vector3(-429.529f, -245f, 0),
                                    new Vector3(-432.88f, -246.6f, 0),
                                    new Vector3(-431.2f, -246.6f, 0),
                                    new Vector3(-429.529f, -246.6f, 0)}; 

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
    } 
    public void b2OnClick(){
        select = 1;
    } 
    public void b3OnClick(){
        select = 2;
    } 
    public void b4OnClick(){
        select = 3;
    } 
    public void b5OnClick(){
        select = 4;
    } 
    public void b6OnClick(){
        select = 5;
    } 
    public void b7OnClick(){
        select = 6;
    } 
    public void b8OnClick(){
        select = 7;
    } 
    public void b9OnClick(){
        select = 8;
    } 


    //game functions
    public void play(Card c, int id){
        if(select == -1)
            return;

        if(c.id == 1){
            c.transform.localPosition = leftcardpos[select];
            areas[select][0] = c;
            areas.AreaPower +=c.power;
        }
        else if (c.id == 2){
            c.transform.localPosition = rightcardpos[select];
            areas[select][0] = c;
            areas.AreaPower -=c.power;
        }

    }

    // score stuff
    public int p1_score = 0;
    public int p2_score = 0;

    List<Area> areas = new List<Area>{  new Area(1), new Area(2), new Area(3),
                                        new Area(4), new Area(5), new Area(6),
                                        new Area(7), new Area(8), new Area(9)};
    List<List<int>> patterns = new List<List<int>>{ new List<int>{0, 1, 2},
                                                    new List<int>{3, 4, 5},
                                                    new List<int>{6, 7, 8},
                                                    new List<int>{0, 3, 6},
                                                    new List<int>{1, 4, 7},
                                                    new List<int>{2, 5, 8},
                                                    new List<int>{0, 4, 8},
                                                    new List<int>{2, 4, 6}};
    public void updateScore()
    {
        for(int i = 0; i < 8; i++){
            bool p1controls = true;
            bool p2controls = true;
            int region_power = 0;
            for(int j = 0; j < 3; j++){
                if(areas[i].CardArea[0] == null)
                    p1controls = false;
                if(areas[i].CardArea[1] == null)
                    p2controls = false;
                region_power += areas[i].AreaPower;
            }

            if(p1controls && region_power > 0){
                p1_score += region_power;
            }
            if(p2controls && region_power < 0){
                p2_score -= region_power;
            }
        }
    }


}