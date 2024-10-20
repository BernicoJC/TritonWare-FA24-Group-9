using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearrangeDoctorSide : MonoBehaviour
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

    //arms
    public SpriteRenderer torch_arm;
    public SpriteRenderer loose_arm;
    public SpriteRenderer right_forearm;
    public SpriteRenderer loose_forearm;
    public SpriteRenderer torch_forearm_flip;
    public SpriteRenderer torch_arm_flip;

    // body
    public SpriteRenderer body;


    public void left()
    {
        torch_forearm_flip.sortingOrder = 15;
        torch_arm_flip.sortingOrder = 14;

        head.sortingOrder = 13;
        body.sortingOrder = 12;

        right_leg.sortingOrder = 11;
        right_shin.sortingOrder = 10;
        right_foot.sortingOrder = 9;

        left_leg.sortingOrder = 8;
        left_shin.sortingOrder = 7;
        left_foot.sortingOrder = 6;

        right_forearm.sortingOrder = 5;
        torch_arm.sortingOrder = 4;

        loose_arm.sortingOrder = 3;
        loose_forearm.sortingOrder = 2;

        match.sortingOrder = 1;
    }

    public void right()
    {
        loose_forearm.sortingOrder = 15;
        loose_arm.sortingOrder = 14;

        head.sortingOrder = 13;
        body.sortingOrder = 12;

        left_leg.sortingOrder = 11;
        left_shin.sortingOrder = 10;
        left_foot.sortingOrder = 9;

        right_leg.sortingOrder = 8;
        right_shin.sortingOrder = 7;
        right_foot.sortingOrder = 6;

        match.sortingOrder = 5;

        torch_arm.sortingOrder = 4;
        right_forearm.sortingOrder = 3;

        torch_forearm_flip.sortingOrder = 2;
        torch_arm_flip.sortingOrder = 1;
    }
}
