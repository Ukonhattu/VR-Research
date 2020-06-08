using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Keeps track of heatmap data.
/// </summary>
public class HeatmapLogger
{
    public List<DataPoint> DataArray { get; }

    public HeatmapLogger(int sizeX, int sizeY)
    {
        this.DataArray = new List<DataPoint>();
    }

    public void AddPoint(DataPoint point)
    {
        this.DataArray.Add(point);
    }
}
