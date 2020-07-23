using System;
using UnityEngine;

public class PanelEventArgs : EventArgs
{
    public GameObject Panel { get; }

    public PanelEventArgs(GameObject panel)
    {
        this.Panel = panel;
    }
}
