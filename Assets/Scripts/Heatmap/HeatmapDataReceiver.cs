using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatmapDataReceiver : MonoBehaviour
{
    private HeatmapLogger logger;

    private void Start()
    {
        this.logger = new HeatmapLogger();
    }

    public void ReceiveDataPoint(DataPoint dataPoint)
    {
        this.logger.AddPoint(dataPoint);
        Debug.Log("Received DataPoint: " + dataPoint);
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
