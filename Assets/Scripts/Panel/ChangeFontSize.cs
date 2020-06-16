using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Leap.Unity.Interaction;

public class ChangeFontSize : MonoBehaviour
{

    public TextMeshProUGUI text;
    public InteractionSlider slider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change()
    {
        this.text.fontSize = slider.HorizontalSliderValue;
    }
}
