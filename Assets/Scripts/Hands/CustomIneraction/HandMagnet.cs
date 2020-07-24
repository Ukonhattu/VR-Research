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
        Vector3 start = UnityVectorExtension.ToVector3(leapProvider.CurrentFrame.Hands[0].PalmPosition);
        Vector3 dir = UnityVectorExtension.ToVector3(leapProvider.CurrentFrame.Hands[0].PalmNormal);
        ShootLaserFromTargetPosition(start, dir, 5f);

        Leap.Unity.Pose pose = leapProvider.CurrentFrame.Hands[0].GetPalmPose();
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
