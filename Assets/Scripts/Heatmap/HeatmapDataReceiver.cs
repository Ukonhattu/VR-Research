﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatmapDataReceiver : MonoBehaviour
{
    private HeatmapLogger logger;
    private MeshRenderer target;

    private void Start()
    {
        this.target = gameObject.GetComponent<MeshRenderer>();
        this.logger = new HeatmapLogger(this.target);
    }

    public void ReceiveDataPoint(DataPoint dataPoint)
    {
        this.logger.AddPoint(dataPoint);
        //Debug.Log("Received DataPoint: " + dataPoint);
    }

    public void ReceivePosition(Vector3 position, float size)
    {
        DataPoint dataPoint = new DataPoint(position, size);
        this.ReceiveDataPoint(dataPoint);
    }

    public void SaveData()
    {
        this.logger.SaveData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.SaveData();
        }
    }
}
