using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameManager manager;

    private int isFirstDay;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (isFirstDay != 0)
        {
            if (manager.sceneNum == 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (manager.sceneNum == 6)
        {
            isFirstDay += 1;
        }
    }

}
