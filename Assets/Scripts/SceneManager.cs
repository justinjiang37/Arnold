using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int nextSceneNum;
    public Vector3 position;
    public string UIText;
    public GameObject UI;
    public GameObject player;
    public GameObject sceneManage;
    public GameObject gameManager;
    public void loadScene(int nextSceneNum, GameObject door)
    {
        // animation to go through door - > black screen until other side
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneNum);
        player.transform.position = door.GetComponent<SceneManager>().position;
    }
}
