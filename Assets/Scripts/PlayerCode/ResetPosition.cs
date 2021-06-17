using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public GameObject Player;
    public void ChangePosition (Vector3 position)
    {
        Player.transform.position = position;
    }


}
