using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChildScript : MonoBehaviour
{

    // LEVEL 3
    // the string is the possible dialogue that the child says when interacted
    public List<string> childLevelThreeDialogue = new List<string>()
    {
        "Hey honey, Don't flip with Henry alright? We you're income right now for the mortgage. Just learn to put up with him for now.",
        "Are you sure you want to go to work today? Henry doesn't seem to be putting up with you."
    };
    // Affect on Arnold
    public List<int> childLevelThreeDialogueEffect = new List<int>(){18, 20};
    // last int of each dict represents the amount that the child's tolerance ON anrold will decrease
    public List<string> childLevelThreeResponse = new List<string>()
    {

        "I'll take care of things on that end, don't worry about it.",
        "I know moneys tight! You don't need to keep annoying me about it!",
        "It's alright, I'll keep it in check.",
        "What do YOU know about him.",
    };
    // Affect on child
    public List<int> childLevelThreeEffect = new List<int>(){6, 10, 5, 12};

    // LEVEL 2
    public List<string> childLevelTwoDialogue = new List<string>()
    {
        "There's a new spa that opened up down town. Tifanny and I are going to enjoy our selves today.",
        "You look like you need a hair cut."
    };
    public List<int> childLevelTwoDialogueEffect = new List<int>() { 23, 21 };
    public List<string> childLevelTwoResponse = new List<string>()
    {

        "I'm not made of money, you know.",
        "Watch how much you spend.",
        "I hate people touching my hair.",
        "It looks fine to me.",
    };
    public List<int> childLevelTwoEffect = new List<int>() { 7, 9, 8, 4 };

    // LEVEL 1
    public List<string> childLevelOneDialogue = new List<string>()
    {
        "Why can't you get a promotion?",
        "I wish you were more like Tiffany's husband."
    };
    public List<int> childLevelOneDialogueEffect = new List<int>() { 27, 30 };
    // last int of each dict represents the amount that the child's tolerance ON anrold will decrease
    public List<string> childLevelOneResponse = new List<string>()
    {

        "SHUT UP!",
        "Stop acting like a bitch.",
        "Why can't YOU act more like Tiffany?",
        "You've changed...",
    };
    public List<int> childLevelOneEffect = new List<int>() { 12, 15, 12, 8 };

    // child Tolerance on Arnold
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
    private List<int> childEffect;
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
                changechildTolerance(childEffect[0]);
            }
            else if (E.triggered && npcManager.GetComponent<NPCManager>().finishedWritingEffect) {
                npcManager.GetComponent<NPCManager>().destroyUI();
                Debug.Log("chose right");
                interacted = true;
                npcManager.GetComponent<NPCManager>().isInteracting = false;
                darkenScript.GetComponent<DarkenScript>().Lighten();
                // Change Arnold Sanity
                changeArnoldTolerance(arnoldEffect);
                changechildTolerance(childEffect[1]);
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
            string[] temp = {childLevelThreeDialogue[0], childLevelThreeResponse[0], childLevelThreeResponse[1]};
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = childLevelThreeDialogueEffect[0];
            childEffect = new List<int> { childLevelThreeEffect[0], childLevelThreeEffect[1]};
        }
        else {
            string[] temp = { childLevelThreeDialogue[1], childLevelThreeResponse[2], childLevelThreeResponse[3] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = childLevelThreeDialogueEffect[1];
            childEffect = new List<int> { childLevelThreeEffect[2], childLevelThreeEffect[3]};
        }
    }
    public void levelTwo()
    {
        dialogueNum = Random.Range(0, 2);
        // call text Writer
        if (dialogueNum == 0)
        {
            string[] temp = { childLevelTwoDialogue[0], childLevelTwoResponse[0], childLevelTwoResponse[1] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = childLevelTwoDialogueEffect[0];
            childEffect = new List<int>{childLevelTwoEffect[0], childLevelTwoEffect[1]};
        }
        else
        {
            string[] temp = { childLevelTwoDialogue[1], childLevelTwoResponse[2], childLevelTwoResponse[3] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = childLevelTwoDialogueEffect[1];
            childEffect = new List<int> { childLevelTwoEffect[2], childLevelTwoEffect[3]};
        }
    }
    public void levelOne()
    {
        dialogueNum = Random.Range(0, 2);
        // call text Writer
        if (dialogueNum == 0)
        {
            string[] temp = { childLevelOneDialogue[0], childLevelOneResponse[0], childLevelOneResponse[1] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = childLevelOneDialogueEffect[0];
            childEffect = new List<int> { childLevelOneEffect[0], childLevelOneEffect[1]};
        }
        else
        {
            string[] temp = { childLevelOneDialogue[1], childLevelOneResponse[2], childLevelOneResponse[3] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = childLevelOneDialogueEffect[1];
            childEffect = new List<int> { childLevelOneEffect[2], childLevelOneEffect[3]};
        }
    }
    public void levelZero()
    {

    }


    public void changechildTolerance(int change)
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
