using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideObject : MonoBehaviour
{

    public enum Axis
    {
        x,
        y,
        z
    }

    public Axis axis;

    public GameObject Target;

    private Transform originalTransform;
    // Start is called before the first frame update
    void Start()
    {
        originalTransform = Target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slide(float x)
    {
        Debug.Log("Sliding");
        Debug.Log(x);
        switch(axis)
        {
            case Axis.x: Target.transform.position = new Vector3(originalTransform.position.x * x, originalTransform.position.y, originalTransform.position.z);
                break;
            case Axis.y:
                Target.transform.position = new Vector3(originalTransform.position.x, originalTransform.position.y * x, originalTransform.position.z);
                break;
            case Axis.z:
                Target.transform.position = new Vector3(originalTransform.position.x, originalTransform.position.y, originalTransform.position.z * x * 100);
                break;
        }
    }
}
