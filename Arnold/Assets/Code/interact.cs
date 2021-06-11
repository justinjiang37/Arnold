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
    public int sceneNum = 1;

    void Update() {
        // if player near a interactable
        if (showUI) {
            text.SetActive(true);
            if (Use.triggered) {
                // Switch to next scene if door
                if (obj.name == "SceneSwitchDoor") {
                    // if reached last scene
                    sceneNum += 1;
                    if (sceneNum == 7) {
                        sceneNum = 0;
                        Debug.Log(sceneNum);
                    }
                    SceneManager.LoadScene(sceneNum);
                }
                obj.SetActive(false);
                showUI = false;
            }
        } else {
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
