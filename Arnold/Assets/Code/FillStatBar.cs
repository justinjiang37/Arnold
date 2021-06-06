using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatBar : MonoBehaviour
{
    public playerComfort playerComfort;
    public Image fillImage;
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= 0.0f) {
            fillImage.enabled = false;
        }
        if (slider.value > 0f && !fillImage.enabled){
            fillImage.enabled = true;
        }
        float fillValue = playerComfort.currentComfort / playerComfort.maxComfort;
        Debug.Log(fillValue);
        slider.value = fillValue;

    }
}
