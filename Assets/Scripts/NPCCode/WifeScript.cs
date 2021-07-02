using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WifeScript : MonoBehaviour
{

    // LEVEL 3
    // the string is the possible dialogue that the wife says when interacted
    public List<string> wifeLevelThreeDialogue = new List<string>()
    {
        "Hey honey, Don't flip with Henry alright? We you're income right now for the mortgage. Just learn to put up with him for now.",
        "Are you sure you want to go to work today? Henry doesn't seem to be putting up with you."
    };
    // Affect on Arnold
    public List<int> wifeLevelThreeDialogueEffect = new List<int>(){18, 20};
    // last int of each dict represents the amount that the wife's tolerance ON anrold will decrease
    public List<string> wifeLevelThreeResponse = new List<string>()
    {

        "I'll take care of things on that end, don't worry about it.",
        "I know moneys tight! You don't need to keep annoying me about it!",
        "It's alright, I'll keep it in check.",
        "What do YOU know about him.",
    };
    // Affect on Wife
    public List<int> wifeLevelThreeEffect = new List<int>(){6, 10, 5, 12};

    // LEVEL 2
    public List<string> wifeLevelTwoDialogue = new List<string>()
    {
        "There's a new spa that opened up down town. Tifanny and I are going to enjoy our selves today.",
        "You look like you need a hair cut."
    };
    public List<int> wifeLevelTwoDialogueEffect = new List<int>() { 23, 21 };
    public List<string> wifeLevelTwoResponse = new List<string>()
    {

        "I'm not made of money, you know.",
        "Watch how much you spend.",
        "I hate people touching my hair.",
        "It looks fine to me.",
    };
    public List<int> wifeLevelTwoEffect = new List<int>() { 7, 9, 8, 4 };

    // LEVEL 1
    public List<string> wifeLevelOneDialogue = new List<string>()
    {
        "Why can't you get a promotion?",
        "I wish you were more like Tiffany's husband."
    };
    public List<int> wifeLevelOneDialogueEffect = new List<int>() { 27, 30 };
    // last int of each dict represents the amount that the wife's tolerance ON anrold will decrease
    public List<string> wifeLevelOneResponse = new List<string>()
    {

        "SHUT UP!",
        "Stop acting like a bitch.",
        "Why can't YOU act more like Tiffany?",
        "You've changed...",
    };
    public List<int> wifeLevelOneEffect = new List<int>() { 12, 15, 12, 8 };

    // Wife Tolerance on Arnold
    private int tolerance = 30;
    public GameObject npcManager;
    Vector3 position = new Vector3();
    private int dialogueNum; // determines which
    public bool interacted = false;
    public InputAction Q;
    public InputAction E;
    public GameObject textWriter;
    public GameObject darkenScript;


    private void Start() {
        this.gameObject.SetActive(false);
    }

    private void Update() {
        // This is for updating the different tolerance levels NOT showing UI
        // All UI code in endorsed in side of the different lvel functions and tghe TextWriter Script
        if (npcManager.GetComponent<NPCManager>().isInteracting) {
            if (Q.triggered && npcManager.GetComponent<NPCManager>().finishedWritingEffect) {
                npcManager.GetComponent<NPCManager>().destroyUI();
                // chose left option
                Debug.Log("chose left");
                interacted = true;
                npcManager.GetComponent<NPCManager>().isInteracting = false;
                darkenScript.GetComponent<DarkenScript>().Lighten();
            }
            else if (E.triggered && npcManager.GetComponent<NPCManager>().finishedWritingEffect) {
                npcManager.GetComponent<NPCManager>().destroyUI();
                // chose right option
                Debug.Log("chose right");
                interacted = true;
                npcManager.GetComponent<NPCManager>().isInteracting = false;
                darkenScript.GetComponent<DarkenScript>().Lighten();
            }
        }
    }

    public void showDialogue()
    {
        if (tolerance >= 20)
        {
            levelThree();
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
    }

    public int setPosition()
    {
        if (tolerance >= 20)
        {
            position = new Vector3(16.5f, 1, -5);
            this.gameObject.transform.position = position;
            return 1;
        }
        else if (tolerance >= 10 && tolerance < 20)
        {
            position = new Vector3(0, 5, 0);
            this.gameObject.transform.position = position;
            return 2;
        }
        else if (tolerance > 0 && tolerance < 10)
        {
            position = new Vector3(0, 5, 0);
            this.gameObject.transform.position = position;
            return 4;
        }
        else
        {
            // follow
            return 0;
        }
    }
    public void levelThree()
    {
        dialogueNum = Random.Range(0, 2);
        // call text Writer
        if(dialogueNum == 0) {
            string[] temp = {wifeLevelThreeDialogue[0], wifeLevelThreeResponse[0], wifeLevelThreeResponse[1]};
            textWriter.GetComponent<TextWriter>().ShowText(temp);
        }
        else {
            string[] temp = { wifeLevelThreeDialogue[1], wifeLevelThreeResponse[2], wifeLevelThreeResponse[3] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
        }
    }
    public void levelTwo()
    {
        dialogueNum = Random.Range(0, 2);
        // call text Writer
        if (dialogueNum == 0)
        {
            string[] temp = { wifeLevelTwoDialogue[0], wifeLevelTwoResponse[0], wifeLevelTwoResponse[1] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
        }
        else
        {
            string[] temp = { wifeLevelTwoDialogue[1], wifeLevelTwoResponse[2], wifeLevelTwoResponse[3] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
        }
    }
    public void levelOne()
    {
        dialogueNum = Random.Range(0, 2);
        // call text Writer
        if (dialogueNum == 0)
        {
            string[] temp = { wifeLevelOneDialogue[0], wifeLevelOneResponse[0], wifeLevelOneResponse[1] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
        }
        else
        {
            string[] temp = { wifeLevelOneDialogue[1], wifeLevelOneResponse[2], wifeLevelOneResponse[3] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
        }
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
    private void OnEnable()
    {
        Q.Enable();
        E.Enable();
    }

    private void OnDisable()
    {
        Q.Disable();
        E.Disable();
    }

}
