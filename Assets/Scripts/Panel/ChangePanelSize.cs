using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Leap.Unity.Interaction;

public class ChangePanelSize : MonoBehaviour
{
    

    private GameObject targetPanel;

    public InteractionSlider slider;

    // Start is called before the first frame update
    void Awake()
    {
        GazeTargetPanel.NewTargetPanel += OnNewTargetPanel;
    }

    private void OnDestroy()
    {
        GazeTargetPanel.NewTargetPanel -= OnNewTargetPanel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnNewTargetPanel(System.Object sender, PanelEventArgs a)
    {
        this.targetPanel = a.Panel;
    }

    public void WidthPlus()
    {
        if (targetPanel == null) return;
        RectTransform rect = targetPanel.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        RectTransform textRect = targetPanel.GetComponentInChildren<Text>().GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.rect.width + 10, rect.rect.height);
        textRect.sizeDelta = new Vector2(textRect.rect.width + 10, textRect.rect.height);
        BoxCollider col = targetPanel.GetComponent<BoxCollider>();
        col.size += new Vector3(.005f, 0, 0);  

    }

    public void WidthMinus()
    {
        if (targetPanel == null) return;
        RectTransform rect = targetPanel.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        RectTransform textRect = targetPanel.GetComponentInChildren<Text>().GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.rect.width - 10, rect.rect.height);
        textRect.sizeDelta = new Vector2(textRect.rect.width - 10, textRect.rect.height);
        BoxCollider col = targetPanel.GetComponent<BoxCollider>();
        col.size -= new Vector3(.005f, 0, 0);
    }

    public void HeightPlus()
    {
        if (targetPanel == null) return;
        RectTransform rect = targetPanel.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        RectTransform textRect = targetPanel.GetComponentInChildren<Text>().GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.rect.width, rect.rect.height + 10);
        textRect.sizeDelta = new Vector2(textRect.rect.width, textRect.rect.height + 10);
        BoxCollider col = targetPanel.GetComponent<BoxCollider>();
        col.size += new Vector3(0, .005f, 0);
    }

    public void HeightMinus()
    {
        if (targetPanel == null) return;
        RectTransform rect = targetPanel.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        RectTransform textRect = targetPanel.GetComponentInChildren<Text>().GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.rect.width, rect.rect.height - 10);
        textRect.sizeDelta = new Vector2(textRect.rect.width, textRect.rect.height - 10);
        BoxCollider col = targetPanel.GetComponent<BoxCollider>();
        col.size -= new Vector3(0, .005f, 0);
    }

    public void ChangeFontSize()
    {
        if (targetPanel == null) return;
        targetPanel.GetComponentInChildren<Text>().fontSize = (int)slider.HorizontalSliderValue;
    }
}
