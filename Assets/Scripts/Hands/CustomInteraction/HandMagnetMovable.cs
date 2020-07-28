using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMagnetMovable : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTowards(Vector3 target)
    {
        if (Vector3.Distance(transform.position, target) > 0.4f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }

    public void MoveFurther(Vector3 target, Vector3 direction)
    {
        float distance = Vector3.Distance(transform.position, target);
        if ( distance > 0.45f)
        {
            float step = speed * Time.deltaTime;
            transform.position += direction * step;
        }
    }
}
