using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLoadScene : MonoBehaviour
{
    private int nextSceneNum;
    public GameObject player;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "LoadSceneTrigger")
        {
            nextSceneNum = other.gameObject.GetComponent<RoadTrigger>().nextSceneNum;
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneNum);
            player.transform.position = other.gameObject.GetComponent<RoadTrigger>().position;
        }
    }
}
