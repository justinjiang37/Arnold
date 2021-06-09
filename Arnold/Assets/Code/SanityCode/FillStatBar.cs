using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatBar : MonoBehaviour
{
    public playerComfort sanity;
    public Image fillImage;
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }


    void Update()
    {
        if (slider.value <= 0.0f) {
            fillImage.enabled = false;
        }
        if (slider.value > 0f && !fillImage.enabled){
            fillImage.enabled = true;
        }
        float fillValue = sanity.currentComfort / sanity.maxComfort;
        slider.value = fillValue;

    }
}
