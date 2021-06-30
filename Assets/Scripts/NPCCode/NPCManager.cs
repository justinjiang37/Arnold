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
    public bool NPCinteract (GameObject obj) {
        if (obj.name == "Wife" && !Wife.GetComponent<WifeScript>().interacted) {
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

    public void resetPositions()
    {
        if (Wife.GetComponent<WifeScript>().setPosition() == sceneManager.GetComponent<SceneManager>().currentSceneNum)
        {
            Wife.SetActive(true);
        }
        else
        {
            Wife.SetActive(false);
        }
    }

    public void changeInteracted() {
        Wife.GetComponent<WifeScript>().interacted = false;
    }
}
