using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Sanity Instances
    public float currentSanity = 99.0f;
    public float maxSanity = 100.0f;
    public int familyToleranceLevel = 0;
    public int workToleranceLevel = 0;
    public SceneManager sceneManager;
    public int daysPassed;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void sleep() {
        DaysPassed += 1;
        // animation for sleep
        // lighting change when wake up
    }

}
