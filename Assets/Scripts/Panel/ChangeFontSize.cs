using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
using UnityEngine.UI;

public class ChangeFontSize : MonoBehaviour
{

    public Text text;
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
        this.text.fontSize = (int)slider.HorizontalSliderValue;
    }
}
