using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WifeScript : MonoBehaviour
{
    // have the parameters INSIDE of the lists
    // find best data structure please;
    // Wife Tolerance on Arnold
    private int tolerance = 30;

    public void showDialogue() {
        if (tolerance >= 20) {
            levelThree();
        }
        else if (tolerance >= 10 && tolerance < 20) {
            levelTwo();
        }
        else if (tolerance > 0 && tolerance < 10) {
            levelOne();
        }
        else if (tolerance <= 0) {
            levelZero();
        }
    }
    public void levelThree ()
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

    // TESTESTESSS :)

}
