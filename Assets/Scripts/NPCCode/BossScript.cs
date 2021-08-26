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
        "It is 10 past 9, please start crunching the numbers for Jerry's Law Firm immediately.",
        "I understand your family is important, but Jerry's Law Firms needs those numbers by the end of the day."
    };
    // Affect on Arnold
    public List<int> bossLevelThreeDialogueEffect = new List<int>() { 22, 18 };

    public List<string> bossLevelThreeResponse = new List<string>()
    {
        "Sorry, I will make sure to get here on time tommorow.",
        "There was traffic, ok?",
        "My family is none of your concern.",
        "Sorry, I will make sure to get here on time tommorow.",
    };
    // Affect on boss
    public List<int> bossLevelThreeEffect = new List<int>() { 6, 12, 12, 6 };

    // LEVEL 2
    public List<string> bossLevelTwoDialogue = new List<string>()
    {
        "The Law Firm Called, the numbers are incorrect.",
        "Please redo the numbers, the Law Firm called and tehy insisted it was incorrect."
    };
    public List<int> bossLevelTwoDialogueEffect = new List<int>() { 23, 17 };
    public List<string> bossLevelTwoResponse = new List<string>()
    {

        "What? ok I will try again.",
        "I'll get to it later.",
        "I'll try.",
        "I triple checked them. I'm sure they are not wrong.",
    };
    public List<int> bossLevelTwoEffect = new List<int>() { 7, 11, 5, 13 };

    // LEVEL 1
    public List<string> bossLevelOneDialogue = new List<string>()
    {
        "We lost Jerry's Law Firm. You moron.",
        "Heard Jerry's is already looking for a new Accounting Co. Nice job dumbass."
    };
    public List<int> bossLevelOneDialogueEffect = new List<int>() { 30, 30 };
    public List<string> bossLevelOneResponse = new List<string>()
    {
        "I'm sorry...",
        "Fuck you.",
        "Well, Jerry's loss.",
        "Fuck you.",
    };
    public List<int> bossLevelOneEffect = new List<int>() { 6, 12, 6, 12 };

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
    public GameObject player;
    private int choice;
    private int arnoldEffect;
    private List<int> bossEffect;
    //the number of the scene that the NPC is suppose to be in
    public int NPCSceneNum = 5;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        // This is for updating the different tolerance levels NOT showing UI
        // All UI code in endorsed in side of the different lvel functions and tghe TextWriter Script
        if (npcManager.GetComponent<NPCManager>().isInteracting)
        {
            if (Q.triggered && npcManager.GetComponent<NPCManager>().finishedWritingEffect)
            {
                npcManager.GetComponent<NPCManager>().destroyUI();
                player.GetComponent<PlayerControl>().UnFreezePosition();
                interacted = true;
                npcManager.GetComponent<NPCManager>().isInteracting = false;
                darkenScript.GetComponent<DarkenScript>().Lighten();
                // Change Arnold Sanity
                changeArnoldTolerance(arnoldEffect);
                changebossTolerance(bossEffect[0]);
            }
            else if (E.triggered && npcManager.GetComponent<NPCManager>().finishedWritingEffect)
            {
                npcManager.GetComponent<NPCManager>().destroyUI();
                player.GetComponent<PlayerControl>().UnFreezePosition();
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
    public void changeNPCSceneNum()
    {
        if (tolerance >= 20)
        {
            NPCSceneNum = 5;
        }
        else if (tolerance >= 10 && tolerance < 20)
        {
            NPCSceneNum = 5;
        }
        else if (tolerance > 0 && tolerance < 10)
        {
            NPCSceneNum = 5;
        }
        else
        {
            NPCSceneNum = 5;
        }
    }
    public void setPosition()
    {
        if (tolerance >= 20)
        {
            position = new Vector3(40, 1, 33);
            this.gameObject.transform.position = position;

        }
        else if (tolerance >= 10 && tolerance < 20)
        {
            position = new Vector3(-26, 1, 13);
            this.gameObject.transform.position = position;

        }
        else if (tolerance > 0 && tolerance < 10)
        {
            position = new Vector3(40, 1, 33);
            this.gameObject.transform.position = position;
        }

    }
    public void levelThree()
    {
        dialogueNum = Random.Range(0, 2);
        // call text Writer
        if (dialogueNum == 0)
        {
            string[] temp = { bossLevelThreeDialogue[0], bossLevelThreeResponse[0], bossLevelThreeResponse[1] };
            Debug.Log(temp[0]);
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = bossLevelThreeDialogueEffect[0];
            bossEffect = new List<int> { bossLevelThreeEffect[0], bossLevelThreeEffect[1] };
        }
        else
        {
            string[] temp = { bossLevelThreeDialogue[1], bossLevelThreeResponse[2], bossLevelThreeResponse[3] };
            Debug.Log(temp[0]);
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = bossLevelThreeDialogueEffect[1];
            bossEffect = new List<int> { bossLevelThreeEffect[2], bossLevelThreeEffect[3] };
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
            bossEffect = new List<int> { bossLevelTwoEffect[0], bossLevelTwoEffect[1] };
        }
        else
        {
            string[] temp = { bossLevelTwoDialogue[1], bossLevelTwoResponse[2], bossLevelTwoResponse[3] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = bossLevelTwoDialogueEffect[1];
            bossEffect = new List<int> { bossLevelTwoEffect[2], bossLevelTwoEffect[3] };
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
            bossEffect = new List<int> { bossLevelOneEffect[0], bossLevelOneEffect[1] };
        }
        else
        {
            string[] temp = { bossLevelOneDialogue[1], bossLevelOneResponse[2], bossLevelOneResponse[3] };
            textWriter.GetComponent<TextWriter>().ShowText(temp);
            arnoldEffect = bossLevelOneDialogueEffect[1];
            bossEffect = new List<int> { bossLevelOneEffect[2], bossLevelOneEffect[3] };
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
