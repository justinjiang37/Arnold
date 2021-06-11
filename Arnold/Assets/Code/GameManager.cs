using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Sanity Instances
    public float currentComfort = 99.0f;
    public float maxComfort = 100.0f;
    public InputAction test;

    void Update()
    {

        if (test.triggered)
        {
            Debug.Log("hi");
            currentComfort = currentComfort - 1.0f;
        }
        Debug.Log(currentComfort);
        Debug.Log(maxComfort);
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
