using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int nextSceneNum;

    public void loadScene(int nextSceneNum)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneNum);
    }
}
