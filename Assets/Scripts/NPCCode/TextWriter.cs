using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriter : MonoBehaviour
{
    public float delay = 0.05f;
    public string fullText;
    private string currentText = "";
    public GameObject chooseQ;
    public GameObject chooseE;
    public GameObject NPCDialogue;
    public GameObject NPCManager;
    public GameObject darkenScript;

    public void ShowText(string[] dialogue) {
        StartCoroutine(WritingEffect(dialogue));
    }
    IEnumerator WritingEffect(string[] dialogue)
    {
        darkenScript.GetComponent<DarkenScript>().Darken();
        yield return new WaitForSeconds(1.5f);
        NPCManager.GetComponent<NPCManager>().finishedWritingEffect = false;
        for (int z = 0; z < 3; z++) {
            fullText = dialogue[z];
            for (int i = 0; i <= fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                if (z == 0) {
                    NPCDialogue.SetActive(true);
                    NPCDialogue.GetComponent<Text>().text = currentText;
                }
                else if (z == 1)
                {
                    chooseQ.SetActive(true);
                    chooseQ.GetComponent<Text>().text = currentText;
                }
                else if (z == 2)
                {
                    chooseE.SetActive(true);
                    chooseE.GetComponent<Text>().text = currentText;
                }
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(1);
        }
        NPCManager.GetComponent<NPCManager>().finishedWritingEffect = true;
    }
}
