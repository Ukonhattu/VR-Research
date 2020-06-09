using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Keeps track of heatmap data.
/// </summary>
public class HeatmapLogger
{
    public List<DataPoint> DataArray { get; }

    public HeatmapLogger()
    {
        this.DataArray = new List<DataPoint>();
    }

    public void AddPoint(DataPoint point)
    {
        this.DataArray.Add(point);
    }

    public void SaveData()
    {
        HeatmapDataWriter.WriteAll(this.ToCSVArray());
    }

    private string[] ToCSVArray()
    {
        List<string> csvlist = new List<string>();
        csvlist.Add(this.GetCSVHeader());
        csvlist.AddRange(DataArray.Select(p => p.ToCSVString()));
        return csvlist.ToArray<string>();
    }

    private string GetCSVHeader()
    {
        return "x,y,z,size";
    }
}
