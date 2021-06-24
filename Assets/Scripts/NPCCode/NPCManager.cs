using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject sceneManager;
    public GameObject Wife;
    public GameObject Child;
    public GameObject Boss;
    // keep track of positions
    public void displayDialogue(string name)
    {
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
        Debug.Log("hi");
        if (Wife.GetComponent<WifeScript>().setPosition() == sceneManager.GetComponent<SceneManager>().currentSceneNum)
        {
            Wife.SetActive(true);
        }
        else
        {
            Wife.SetActive(false);
        }
        // if (Child.GetComponent<ChildScript>().setPosition() == sceneManager.GetComponent<SceneManager>().currentSceneNum)
        // {
        //     Child.SetActive(true);
        // }
        // else
        // {
        //     Child.SetActive(false);
        // }
        // if (Boss.GetComponent<BossScript>().setPosition() == sceneManager.GetComponent<SceneManager>().currentSceneNum)
        // {
        //     Boss.SetActive(true);
        // }
        // else
        // {
        //     Boss.SetActive(false);
        // }

    }
}
