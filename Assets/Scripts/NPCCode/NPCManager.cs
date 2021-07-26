using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NPCManager : MonoBehaviour
{
    public GameObject sceneManager;
    public GameObject Wife;
    public GameObject Child;
    public GameObject Boss;
    public bool isInteracting;
    public GameObject chooseQ;
    public GameObject chooseE;
    public GameObject NPCDialogue;
    public bool finishedWritingEffect = false;
    // keep track of positions
    private void Start() {
        chooseE.SetActive(false);
        chooseQ.SetActive(false);
        NPCDialogue.SetActive(false);
    }
    public void destroyUI() {
        chooseE.SetActive(false);
        chooseQ.SetActive(false);
        NPCDialogue.SetActive(false);
    }
    public void sleep() {
        Wife.GetComponent<WifeScript>().sleep();
        Child.GetComponent<ChildScript>().sleep();
        Boss.GetComponent<BossScript>().sleep();

    }
    public bool NPCinteract (GameObject obj) {
        if (obj.name == "Wife" && !Wife.GetComponent<WifeScript>().interacted) {
            return true;
        }
        if (obj.name == "Child" && !Child.GetComponent<ChildScript>().interacted)
        {
            return true;
        }
        if (obj.name == "Boss" && !Boss.GetComponent<BossScript>().interacted)
        {
            return true;
        }
        return false;
    }

    public void displayDialogue(string name)
    {
        isInteracting = true;
        if (name == "Wife")
        {
            Wife.GetComponent<WifeScript>().showDialogue();
        }
        else if (name == "Child")
        {
            Child.GetComponent<ChildScript>().showDialogue();
        }
        else if (name == "Boss")
        {
            Boss.GetComponent<BossScript>().showDialogue();
        }
    }

    public void showNPC() {
        if (Wife.GetComponent<WifeScript>().NPCSceneNum == sceneManager.GetComponent<SceneManager>().currentSceneNum)
        {
            Wife.SetActive(true);
        }
        else
        {
            Wife.SetActive(false);
        }
        if (Child.GetComponent<ChildScript>().NPCSceneNum == sceneManager.GetComponent<SceneManager>().currentSceneNum)
        {
            Child.SetActive(true);
        }
        else
        {
            Child.SetActive(false);
        }
        if (Boss.GetComponent<BossScript>().NPCSceneNum == sceneManager.GetComponent<SceneManager>().currentSceneNum)
        {
            Boss.SetActive(true);
        }
        else
        {
            Boss.SetActive(false);
        }

    }
    public void changeWifeKidSceneNum() {
        Wife.GetComponent<WifeScript>().changeNPCSceneNum();
        Child.GetComponent<ChildScript>().changeNPCSceneNum();
    }
    public void changeBossSceneNum()
    {
        Boss.GetComponent<BossScript>().changeNPCSceneNum();
    }
    public void resetPositions()
    {
        Wife.GetComponent<WifeScript>().setPosition();
        Child.GetComponent<ChildScript>().setPosition();
        Boss.GetComponent<BossScript>().setPosition();
    }

    public void changeInteracted() {
        Wife.GetComponent<WifeScript>().interacted = false;
        Child.GetComponent<ChildScript>().interacted = false;
        Boss.GetComponent<BossScript>().interacted = false;
    }
}
