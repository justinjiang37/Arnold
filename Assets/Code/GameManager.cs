using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Sanity Instances
    public float currentSanity = 99.0f;
    public float maxSanity = 100.0f;
    public InputAction test;
    public int sceneNum = 0;
    // fix put on each scene door
    public bool isReturning = false;
    public int familyToleranceLevel = 0;
    public int workToleranceLevel = 0;
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (test.triggered)
        {
            currentSanity = currentSanity - 1.0f;
        }
    }
    public void lastScene() {
        sceneNum -= 1;
    }
    public void nextScene() {
        sceneNum += 1;
    }
    public void reset() {
        sceneNum = 0;
    }
    private void OnEnable()
    {
        test.Enable();
    }
    private void OnDisable()
    {
        test.Disable();
    }
}
