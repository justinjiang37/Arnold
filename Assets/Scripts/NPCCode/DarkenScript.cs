using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkenScript : MonoBehaviour
{
    public Animator DarkenDialogue;
    public void Darken() {
        StartCoroutine(DarkenAnimation());
    }

    IEnumerator DarkenAnimation()
    {
        DarkenDialogue.SetTrigger("Darken");

        yield return new WaitForSeconds(0.1f);
    }

    public void Lighten()
    {
        StartCoroutine(LightenAnimation());
    }

    IEnumerator LightenAnimation()
    {
        DarkenDialogue.SetTrigger("Lighten");

        yield return new WaitForSeconds(0.1f);
    }
}
