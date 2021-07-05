using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{

    // LEVEL 3
    // the string is the possible dialogue that the boss says when interacted
    public List<string> bossLevelThreeDialogue = new List<string>()
    {
        "Hey honey, Don't flip with Henry alright? We you're income right now for the mortgage. Just learn to put up with him for now.",
        "Are you sure you want to go to work today? Henry doesn't seem to be putting up with you."
    };
    // Affect on Arnold
    public List<int> bossLevelThreeDialogueEffect = new List<int>(){18, 20};
    // last int of each dict represents the amount that the boss's tolerance ON anrold will decrease
    public List<string> bossLevelThreeResponse = new List<string>()
    {

        "I'll take care of things on that end, don't worry about it.",
        "I know moneys tight! You don't need to keep annoying me about it!",
        "It's alright, I'll keep it in check.",
        "What do YOU know about him.",
    };
    // Affect on boss
    public List<int> bossLevelThreeEffect = new List<int>(){6, 10, 5, 12};

    // LEVEL 2
    public List<string> bossLevelTwoDialogue = new List<string>()
    {
        "There's a new spa that opened up down town. Tifanny and I are going to enjoy our selves today.",
        "You look like you need a hair cut."
    };
    public List<int> bossLevelTwoDialogueEffect = new List<int>() { 23, 21 };
    public List<string> bossLevelTwoResponse = new List<string>()
    {

        "I'm not made of money, you know.",
        "Watch how much you spend.",
        "I hate people touching my hair.",
        "It looks fine to me.",
    };
    public List<int> bossLevelTwoEffect = new List<int>() { 7, 9, 8, 4 };

    // LEVEL 1
    public List<string> bossLevelOneDialogue = new List<string>()
    {
        "Why can't you get a promotion?",
        "I wish you were more like Tiffany's husband."
    };
    public List<int> bossLevelOneDialogueEffect = new List<int>() { 27, 30 };
    // last int of each dict represents the amount that the boss's tolerance ON anrold will decrease
    public List<string> bossLevelOneResponse = new List<string>()
    {

        "SHUT UP!",
        "Stop acting like a bitch.",
        "Why can't YOU act more like Tiffany?",
        "You've changed...",
    };
    public List<int> bossLevelOneEffect = new List<int>() { 12, 15, 12, 8 };

    // boss Tolerance on Arnold
    private int tolerance = 30;
    public GameObject npcManager;
    public GameObject gameManager;
    Vector3 position = new Vector3();
    private int dialogueNum; // determines which
    public bool interacted = false;
    public InputAction Q;
    public InputAction E;
    public GameObject textWriter;
    public GameObject darkenScript;
    private int choice;
    private int arnoldEffect;
    private List<int> bossEffect;
    //the number of the scene that the NPC is suppose to be in
    public int NPCSceneNum = 2;

    private void Start() {
        this.gameObject.SetActive(false);
    }

    private void Update() {
        // This is for updating the different tolerance levels NOT showing UI
        // All UI code in endorsed in side of the different lvel functions and tghe TextWriter Script
        if (npcManager.GetComponent<NPCManager>().isInteracting) {
            if (Q.triggered && npcManager.GetComponent<NPCManager>().finishedWritingEffect) {
                npcManager.GetComponent<NPCManager>().destroyUI();
                interacted = true;
                npcManager.GetComponent<NPCManager>().isInteracting = false;
                darkenScript.GetComponent<DarkenScript>().Lighten();
                // Change Arnold Sanity
                changeArnoldTolerance(arnoldEffect);
                changebossTolerance(bossEffect[0]);
            }
            else if (E.triggered && npcManager.GetComponent<NPCManager>().finishedWritingEffect) {
                npcManager.GetComponent<NPCManager>().destroyUI();
                Debug.Log("chose right");
                interacted = true;
                npcManager.GetComponent<NPCManager>().isInteracting = false;
                darkenScript.GetComponent<DarkenScript>().Lighten();
                // Change Arnold Sanity
                changeArnoldTolerance(arnoldEffect);
                changebossTolerance(bossEffect[1]);
            }
        }
    }
    public void sleep() {
        NPCSceneNum = 2;
        position = new Vector3(4, 1, 10);
        this.gameObject.transform.position = position;
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
    public void changeNPCSceneNum() {
        if (tolerance >= 20)
        {
            NPCSceneNum = 2;
        }
        else if (tolerance >= 10 && tolerance < 20)
        {
            NPCSceneNum = 2;
        }
        else if (tolerance > 0 && tolerance < 10)
        {
            NPCSceneNum = 4;
        }
        else
        {
            NPCSceneNum = 0;
        }
    }
    public void setPosition()
    {
        if (tolerance >= 20)
        {
            position = new Vector3(0, 1, 0);
            this.gameObject.transform.position = position;

        }
        else if (tolerance >= 10 && tolerance < 20)
        {
            position = new Vector3(0, 1, 0);
            this.gameObject.transform.position = position;

        }
        else if (tolerance > 0 && tolerance < 10)
        {
            position = new Vector3(1, 1, 1);
            this.gameObject.transform.position = position;
        }

    }
    public void levelThree()
    {
        dialogueNum = Random.Range(0, 2);
        // call text Writer
        if(dialogueNum == 0) {
            string[] temp = {bossLevelThreeDialogue[0], bossLevelThreeResponse[0], bossLevelThreeResponse[1]};
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = bossLevelThreeDialogueEffect[0];
            bossEffect = new List<int> { bossLevelThreeEffect[0], bossLevelThreeEffect[1]};
        }
        else {
            string[] temp = { bossLevelThreeDialogue[1], bossLevelThreeResponse[2], bossLevelThreeResponse[3] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = bossLevelThreeDialogueEffect[1];
            bossEffect = new List<int> { bossLevelThreeEffect[2], bossLevelThreeEffect[3]};
        }
    }
    public void levelTwo()
    {
        dialogueNum = Random.Range(0, 2);
        // call text Writer
        if (dialogueNum == 0)
        {
            string[] temp = { bossLevelTwoDialogue[0], bossLevelTwoResponse[0], bossLevelTwoResponse[1] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = bossLevelTwoDialogueEffect[0];
            bossEffect = new List<int>{bossLevelTwoEffect[0], bossLevelTwoEffect[1]};
        }
        else
        {
            string[] temp = { bossLevelTwoDialogue[1], bossLevelTwoResponse[2], bossLevelTwoResponse[3] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = bossLevelTwoDialogueEffect[1];
            bossEffect = new List<int> { bossLevelTwoEffect[2], bossLevelTwoEffect[3]};
        }
    }
    public void levelOne()
    {
        dialogueNum = Random.Range(0, 2);
        // call text Writer
        if (dialogueNum == 0)
        {
            string[] temp = { bossLevelOneDialogue[0], bossLevelOneResponse[0], bossLevelOneResponse[1] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = bossLevelOneDialogueEffect[0];
            bossEffect = new List<int> { bossLevelOneEffect[0], bossLevelOneEffect[1]};
        }
        else
        {
            string[] temp = { bossLevelOneDialogue[1], bossLevelOneResponse[2], bossLevelOneResponse[3] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = bossLevelOneDialogueEffect[1];
            bossEffect = new List<int> { bossLevelOneEffect[2], bossLevelOneEffect[3]};
        }
    }
    public void levelZero()
    {

    }


    public void changebossTolerance(int change)
    {
        tolerance -= change;
        Debug.Log(change);
        Debug.Log(tolerance);
    }

    public void changeArnoldTolerance(int change)
    {
        gameManager.GetComponent<GameManager>().currentSanity -= change;
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
