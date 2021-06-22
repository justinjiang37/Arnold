using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject title;
    public GameObject startButton;
    public GameObject sceneManager;
    public GameObject start;
    public void PlayGame () {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        title.SetActive(false);
        startButton.SetActive(false);
    }
}
