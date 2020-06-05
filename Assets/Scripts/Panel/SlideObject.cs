using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class SlideObject : MonoBehaviour
{

    public enum Axis
    {
        x,
        y,
        z
    }

    public Axis axis;

    public InteractionSlider Slider;

    private Vector3 originalTransformPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalTransformPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slide()
    {
        float x = Slider.HorizontalSliderValue;
        switch(axis)
        {
            case Axis.x: gameObject.transform.position = new Vector3(originalTransformPosition.x * x, originalTransformPosition.y, originalTransformPosition.z);
                break;
            case Axis.y:
                gameObject.transform.position = new Vector3(originalTransformPosition.x, originalTransformPosition.y * x, originalTransformPosition.z);
                break;
            case Axis.z:
                gameObject.transform.position = new Vector3(originalTransformPosition.x, originalTransformPosition.y, (originalTransformPosition.z +1) * x * 100);
                Debug.Log("Z axis");
                break;
        }
    }
}
