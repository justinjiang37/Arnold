using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class interact : MonoBehaviour
{
    private bool showUI;
    private GameObject obj;
    public InputAction Use;
    public GameObject text;
    public GameManager manager;
    public GameObject player;

    void Update() {
        // if player near a interactable
        if (showUI) {
            // Switch to next scene if door
            if (obj.name == "SceneSwitchDoor") {
                text.SetActive(true);
                if (Use.triggered) {
                    if (manager.isReturning == true) {
                        manager.lastScene();
                        // if reached first scene
                        if (manager.sceneNum == 0) {
                            manager.isReturning = false;
                        }
                        SceneManager.LoadScene(manager.sceneNum);
                    }

                    else {
                        manager.nextScene();
                        // if reached last scene
                        if (manager.sceneNum == 6) {
                            manager.isReturning = true;
                        }
                        SceneManager.LoadScene(manager.sceneNum);
                    }
                        obj.SetActive(false);
                        showUI = false;
                    }
                }
                else {
                    text.SetActive(false);
                }

                if (obj.name!="SceneSwitchDoor") {
                    text.SetActive(true);
                    if (Use.triggered) {
                        showUI = false;
                    }
                }
                else {
                    text.SetActive(false);
                }
            }

        else {
            text.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Use") {
            showUI = true;
            obj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Use") {
            showUI = false;
            obj = other.gameObject;
        }
    }

    private void OnEnable() {
        Use.Enable();
    }

    private void OnDisable() {
        Use.Disable();
    }
}
