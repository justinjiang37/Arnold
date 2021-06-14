using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameManager manager;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
