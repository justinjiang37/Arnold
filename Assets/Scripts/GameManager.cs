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
    public int overallSituation = 0;
    public int volume = 5;
    // overall sit determines the enviorment changes and what the mood feels like
    // has 3 ovls
    // 0 -> relaxed
    // 1 -> tight
    // 2 -> anxious

    // Arnold's Tolerance on others
    public int familyToleranceLevel = 0;
    public int workToleranceLevel = 0;
    public SceneManager sceneManager;
    public int daysPassed = 0;
    public GameObject npcManager;
    public bool slept = true;
    public Animator sleeper;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update() {
        overallSituation = (familyToleranceLevel + workToleranceLevel)/2;
    }
    public void sleep() {
        slept = true;
        daysPassed += 1;
        StartCoroutine(sleepAnimation());
    }

    IEnumerator sleepAnimation()
    {
        sleeper.SetTrigger("Start");

        yield return new WaitForSeconds(1);
        npcManager.GetComponent<NPCManager>().changeBossSceneNum();
        npcManager.GetComponent<NPCManager>().changeWifeKidSceneNum();
        npcManager.GetComponent<NPCManager>().resetPositionsFamily();
        npcManager.GetComponent<NPCManager>().changeInteracted();
        npcManager.GetComponent<NPCManager>().showNPC();

        sleeper.SetTrigger("End");
    }

}
