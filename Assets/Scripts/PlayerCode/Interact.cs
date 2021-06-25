using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Interact : MonoBehaviour
{
    public SceneManager sceneManager;
    public GameManager gameManager;
    public GameObject NPCManager;
    private GameObject obj;
    public InputAction Use;
    public Text interactText;
    public GameObject player;
    public bool inRange = false;
    private void Start()
    {
        interactText.gameObject.SetActive(false);
    }
    void Update()
    {
        if (inRange)
        {
            interactText.text = obj.GetComponent<SceneManager>().UIText;
            interactText.gameObject.SetActive(true);
            if (obj.name == "SceneSwitchDoor")
            {
                if (Use.triggered) {
                    sceneManager.loadScene(obj.GetComponent<SceneManager>().nextSceneNum, obj.GetComponent<SceneManager>().position);
                    inRange = false;
                }
            }
            else if (obj.name == "Bed")
            {
                if (Use.triggered)
                {
                    gameManager.sleep();
                    inRange = false;
                }
            }
            else if (obj.name == "Wife" || obj.name == "Kid" || obj.name == "Boss")
            {
                if (Use.triggered)
                {
                    NPCManager.GetComponent<NPCManager>().displayDialogue(obj.name);
                }
            }
        }
        else
        {
            interactText.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Use")
        {
            inRange = true;
            obj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Use")
        {
            inRange = false;
            obj = null;
        }
    }

    private void OnEnable()
    {
        Use.Enable();
    }

    private void OnDisable()
    {
        Use.Disable();
    }
}
