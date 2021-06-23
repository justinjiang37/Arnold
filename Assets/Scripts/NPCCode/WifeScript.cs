using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Specialized;
public class WifeScript : MonoBehaviour
{
    // the string is the possible dialogue that the wife says when interacted
    // the int at the end is the decrease in Arnold's sanity level when said
    public Dictionary<string, int> wifeLevelThreeDialogue =
        new Dictionary<string, int>()
        {
            {"Hey honey, Don't flip with Henry alright? We you're income right now for the mortgage. \n Just learn to put up with him for now.", 1},
            {"Are you sure you want to go to work today? Henry doesn't seem to be putting up with you.", 2}
        };
    public List<string> wifeLevelThreeResponse = new List<string>()
    {

        "I'll take care of things on that end, don't worry about it.",
        "I know moneys tight! You don't need to keep annoying me about it!",
        "It's alright, I'll keep it in check.",
        "What do YOU know about him.",
    };
    public List<int> wifeLevelThreeEffect = new List<int>() { 5, 9, 4, 12};


    // Wife Tolerance on Arnold
    private int tolerance = 30;
    public GameObject gameManager;
    Vector3 position = new Vector3();
    void Start() {
        if (tolerance >= 20)
        {
            position = new Vector3(0, 5, 0);
        }
        else if (tolerance >= 10 && tolerance < 20)
        {
            levelTwo();
        }
        else if (tolerance > 0 && tolerance < 10)
        {
            levelOne();
        }
        else if (tolerance <= 0)
        {
            levelZero();
        }
        this.gameObject.transform.position = position;
    }

    public void showDialogue() {
        if (tolerance >= 20) {
            levelThree();
        }
        else if (tolerance >= 10 && tolerance < 20) {
            levelTwo();
        }
        else if (tolerance > 0 && tolerance < 10) {
            levelOne();
        }
        else if (tolerance <= 0) {
            levelZero();
        }
    }
    public void levelThree ()
    {
    }
    public void levelTwo()
    {

    }
    public void levelOne()
    {

    }
    public void levelZero()
    {

    }
    public void changeWifeTolerance()
    {

    }

    public void changeArnoldTolerance()
    {

    }

}
