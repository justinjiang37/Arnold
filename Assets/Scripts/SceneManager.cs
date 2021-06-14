using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int nextSceneNum;

    public void loadScene(int nextSceneNum)
    {
        // animation to go through door - > black screen until other side
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneNum);
    }
}
