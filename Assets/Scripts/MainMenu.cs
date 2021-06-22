using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject title;
    public GameObject startButton;
    public GameObject sceneManager;
    public void PlayGame () {
        sceneManager.GetComponent<SceneManager>().loadScene(1, new Vector3(0,1,0));
        title.SetActive(false);
        startButton.SetActive(false);
    }
}
