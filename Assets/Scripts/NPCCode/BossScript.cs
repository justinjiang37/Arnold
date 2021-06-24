using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    // Tolerance on Arnold
    private int tolerance = 30;
    Vector3 position = new Vector3();

    public void showDialogue()
    {
        if (tolerance >= 20)
        {
            levelThree();
        }
        else if (tolerance >= 10 && tolerance < 20)
        {
            levelTwo();
        }
        else if (tolerance > 0 && tolerance < 10)
        {
            levelOne();
        }
        else if (tolerance <= 0)
        {
            levelZero();
        }
    }
    public int setPosition()
    {
        if (tolerance >= 20)
        {
            position = new Vector3(16.5f, 1, -5);
            this.gameObject.transform.position = position;
            return 1;
        }
        else if (tolerance >= 10 && tolerance < 20)
        {
            position = new Vector3(0, 5, 0);
            this.gameObject.transform.position = position;
            return 2;
        }
        else if (tolerance > 0 && tolerance < 10)
        {
            position = new Vector3(0, 5, 0);
            this.gameObject.transform.position = position;
            return 4;
        }
        else
        {
            // follow
            return 0;
        }
    }
    public void levelThree()
    {
        // displays level three dialogue
    }
    public void levelTwo()
    {

    }
    public void levelOne()
    {

    }
    public void levelZero()
    {

    }
    public void changeWifeTolerance()
    {

    }

    public void changeArnoldTolerance()
    {

    }
}
