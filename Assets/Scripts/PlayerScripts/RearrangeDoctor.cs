using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearrangeDoctor : MonoBehaviour
{
    // legs
    public SpriteRenderer left_leg;
    public SpriteRenderer right_leg;
    public SpriteRenderer left_shin;
    public SpriteRenderer right_shin;
    public SpriteRenderer left_foot;
    public SpriteRenderer right_foot;

    // match
    public SpriteRenderer match;

    // head
    public SpriteRenderer head;
    public SpriteRenderer hair;

    //arms
    public SpriteRenderer right_arm;
    public SpriteRenderer left_arm;
    public SpriteRenderer right_forearm;
    public SpriteRenderer left_forearm;

    // body
    public SpriteRenderer body;
    public SpriteRenderer front_layers;


    public void front()
    {
        // legs
        left_leg.sortingOrder = 6;
        right_leg.sortingOrder = 5;
        left_shin.sortingOrder = 4;
        right_shin.sortingOrder = 3;
        left_foot.sortingOrder = 2;
        right_foot.sortingOrder = 1;

        // match
        match.sortingOrder = 15;

        // head
        head.sortingOrder = 10;
        hair.sortingOrder = 9;

        //arms
        right_arm.sortingOrder = 13;
        left_arm.sortingOrder = 11;
        right_forearm.sortingOrder = 14;
        left_forearm.sortingOrder = 12;

        // body
        body.sortingOrder = 8;
        front_layers.sortingOrder = 7;
    }

    public void back()
    {

        // legs
        left_leg.sortingOrder = 10;
        right_leg.sortingOrder = 9;
        left_shin.sortingOrder = 8;
        right_shin.sortingOrder = 7;
        left_foot.sortingOrder = 6;
        right_foot.sortingOrder = 5;

        // match
        match.sortingOrder = 0;

        // head
        head.sortingOrder = 11;
        hair.sortingOrder = 14;

        //arms
        right_arm.sortingOrder = 2;
        left_arm.sortingOrder = 4;
        right_forearm.sortingOrder = 1;
        left_forearm.sortingOrder = 3;

        // body
        body.sortingOrder = 13;
        front_layers.sortingOrder = 12;
    }
}
