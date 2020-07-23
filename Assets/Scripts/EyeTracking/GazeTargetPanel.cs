using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GazeTargetPanel : MonoBehaviour
{
    public static event EventHandler<PanelEventArgs> NewTargetPanel;

    public void OnGazeRayHit() {
        NewTargetPanel?.Invoke(this, new PanelEventArgs(this.gameObject));
    }
}
