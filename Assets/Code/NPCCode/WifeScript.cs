using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WifeScript : MonoBehaviour
{
    private Dictionary<string, List<string>> levelOne;
    private Dictionary<string, List<string>> levelTwo;
    private Dictionary<string, List<string>> levelThree;
    public string yellingDialogue = "";

    public int level = 1;

    // Update is called once per frame
    void Update()
    {

    }

    public Dictionary<string, List<string>> getLevel(int level) {
        if (level == 1) {
            return levelOne;
        }
        if (level == 2) {
            return levelTwo;
        }
        return levelThree;
    }
}
