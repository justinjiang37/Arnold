using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public SceneManager sceneManager;
    public GameManager gameManager;
    private GameObject obj;
    public InputAction Use;
    public GameObject text;
    public GameObject player;
    private bool inRange;
    private void Start()
    {
        text.SetActive(false);
    }
    void Update()
    {
        if (inRange)
        {
            if (obj.name == "SceneSwitchDoor")
            {
                if (Use.triggered) {
                    sceneManager.loadScene(obj.GetComponent<SceneManager>().nextSceneNum);
                    inRange = false;
                }
            }
            if (obj.name == "Bed")
            {
                if (Use.triggered)
                {
                    gameManager.sleep();
                    inRange = false;
                }
            }
            else
            {
                if (Use.triggered)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Use")
        {
            inRange = true;
            text.SetActive(true);
            obj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Use")
        {
            inRange = false;
            text.SetActive(false);
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