using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonCharacterNPCScript : MonoBehaviour
{
    public GameObject gameManager;
    private int NPCPosNum;

    private void Update() {
        NPCPosNum = gameManager.GetComponent<GameManager>().overallSituation;

        if (NPCPosNum == 0)
        {
            // contact to change position
        }
        if(NPCPosNum == 1)
        {
            // contact to change position
        }
        if (NPCPosNum == 2)
        {
            // contact to change position
        }
    }
}
