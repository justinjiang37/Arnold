using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class interact : MonoBehaviour
{
    private bool showUI;
    private GameObject obj;
    public InputAction Use;
    public GameObject text;

    void Update() {
        if (showUI) {
            text.SetActive(true);
            if (Use.triggered) {
                Debug.Log("hi");
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
        }
    }

    private void OnEnable() {
        Use.Enable();
    }

    private void OnDisable() {
        Use.Disable();
    }
}
