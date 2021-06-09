using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerComfort : MonoBehaviour
{
    public float currentComfort = 99.0f;
    public float maxComfort = 100.0f;
    public InputAction test;
    // Update is called once per frame
    void Update()
    {
        if (test.triggered) {
            currentComfort = currentComfort - 1.0f;
        }
    }
    public void decreaseComfort(float value) {
        currentComfort -= value;
    }
    public void increaseComfort(float value) {
        currentComfort += value;
    }
    public void fillComfort(float value) {
        currentComfort = 100f;
    }
    public void voidComfort(float value) {
        currentComfort = 0f;
    }
    private void OnEnable() {
        test.Enable();
    }
    private void OnDisable() {
        test.Disable();
    }
}
