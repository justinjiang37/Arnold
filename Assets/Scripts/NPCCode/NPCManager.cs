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
    // keep track of positions
    private void Start() {
        chooseE.SetActive(false);
        chooseQ.SetActive(false);
    }
    public void displayDialogue(string name)
    {
        isInteracting = true;
        chooseE.SetActive(true);
        chooseQ.SetActive(true);
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
}
