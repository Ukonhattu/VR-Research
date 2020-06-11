using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Keeps track of heatmap data.
/// </summary>
public class HeatmapLogger
{
    public List<DataPoint> DataArray { get; }
    public MeshRenderer Target { get; }

    public HeatmapLogger(MeshRenderer target)
    {
        this.Target = target;
        this.DataArray = new List<DataPoint>();
    }

    public void AddPoint(DataPoint point)
    {
        this.DataArray.Add(point);
    }

    public void SaveData()
    {
        HeatmapDataWriter.WriteAll(this.ToCSVArray(), this.infoJSON());
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

    private string infoJSON()
    {
        Bounds bounds = Target.bounds;
        string imgname = Target.material.mainTexture.name;
        return $"{{ \"centerX\":{bounds.center.x}, \"centerY\":{bounds.center.y},  " +
            $"\"sizeX\":{bounds.size.x}, \"sizeY\":{bounds.size.y}," +
            $" \"image\":\"{imgname}\" }}";
    }
}
