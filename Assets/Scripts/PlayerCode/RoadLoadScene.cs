using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLoadScene : MonoBehaviour
{
    private int nextSceneNum;
    public GameObject player;
    private GameObject trigger;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "LoadSceneTrigger")
        {
            nextSceneNum = trigger.GetComponent<RoadTrigger>().nextSceneNum;
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneNum);
            player.transform.position = trigger.GetComponent<RoadTrigger>().position;
        }
    }
}
