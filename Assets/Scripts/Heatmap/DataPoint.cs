using UnityEngine;


/// <summary>
/// One Point of data for heatmap.
/// </summary>
public class DataPoint
{
    public Vector3 Position { set; get; }
    public float Size { set; get; }

    public DataPoint(Vector3 position, float size)
    {
        this.Position = position;   
        this.Size = size;
    }

    override public string ToString()
    {
        return "X: " + this.Position.x + " Y: " + this.Position.y + "  z: " + this.Position.z + " Size: " + this.Size;
    }

    public string ToCSVString()
    {
        return this.Position.x + "," + this.Position.y + "," + this.Position.z + "," + this.Size;
    }
}
