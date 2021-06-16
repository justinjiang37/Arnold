using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int nextSceneNum;
    public GameObject UI;
    public GameObject player;
    public GameObject sceneManage;
    public GameObject gameManager;
    public GameObject interactChecker;

    public void loadScene(int nextSceneNum)
    {
        if (nextSceneNum == 0)
        {
            Destroy(UI);
            Destroy(player);
            Destroy(sceneManage);
            Destroy(gameManager);
        }
        // animation to go through door - > black screen until other side
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneNum);
        // call set position thing
    }
}
