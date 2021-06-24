using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int currentSceneNum;
    public int nextSceneNum;
    public Vector3 position;
    public string UIText;
    public GameObject UI;
    public GameObject player;
    public GameObject sceneManage;
    public GameObject gameManager;
    public GameObject npcManager;
    public Animator transition;

    public void loadScene(int nextSceneNum, Vector3 newPosition)
    {
        StartCoroutine(LoadNextScene(nextSceneNum, newPosition));
    }

    IEnumerator LoadNextScene(int nextSceneNum, Vector3 newPosition)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);
        player.transform.position = newPosition;
        currentSceneNum = nextSceneNum;
        npcManager.GetComponent<NPCManager>().resetPositions();
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneNum);

        transition.SetTrigger("End");
    }

////////////////////////////////////////////////////
////////// Start Animation will be DIFFERENT ///////
////////////////////////////////////////////////////
    public void loadStartScene(int nextSceneNum, Vector3 newPosition)
    {
        StartCoroutine(LoadStartScene(nextSceneNum, newPosition));
    }

    IEnumerator LoadStartScene(int nextSceneNum, Vector3 newPosition)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);
        player.transform.position = newPosition;
        currentSceneNum = nextSceneNum;
        npcManager.GetComponent<NPCManager>().resetPositions();
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneNum);

        transition.SetTrigger("End");
    }
}
