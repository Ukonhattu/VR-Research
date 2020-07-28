using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
public class HandMagnet : MonoBehaviour
{
    public LeapProvider leapProvider;

    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.SetWidth(laserWidth, laserWidth);
    }

    // Update is called once per frame
    void Update()
    {
        List<Leap.Hand> hands = leapProvider.CurrentFrame.Hands;
        for (int i = 0; i < hands.Count; i++) {

            if (hands[i].IsLeft)
            {
                Vector3 start = UnityVectorExtension.ToVector3(hands[i].PalmPosition);
                Vector3 dir = UnityVectorExtension.ToVector3(hands[i].PalmNormal);
                //ShootLaserFromTargetPosition(start, dir, 5f); //visible ray

                Ray ray = new Ray(start, dir);

                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    HandMagnetMovable target = raycastHit.collider.gameObject.GetComponent<HandMagnetMovable>();

                    if (target != null)
                    {
                        target.MoveTowards(start);
                    }
                }
            }
            if (hands[i].IsRight)
            {
                Vector3 start = UnityVectorExtension.ToVector3(hands[i].PalmPosition);
                Vector3 dir = UnityVectorExtension.ToVector3(hands[i].PalmNormal);
                //ShootLaserFromTargetPosition(start, dir, 5f); //visible ray

                Ray ray = new Ray(start, dir);

                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    HandMagnetMovable target = raycastHit.collider.gameObject.GetComponent<HandMagnetMovable>();

                    if (target != null)
                    {
                        target.MoveFurther(start, dir);
                    }
                }
            }
        }

    }   

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }
}
