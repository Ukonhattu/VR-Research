
/// <summary>
/// One Point of data for heatmap.
/// </summary>
public class DataPoint
{
    public int X { set; get; }
    public int Y { set; get; }
    public float Size { set; get; }

    public DataPoint(int x, int y, float size)
    {
        this.X = x;
        this.Y = y;
        this.Size = size;
    }

    override public string ToString()
    {
        return "X: " + this.X + " Y: " + this.Y + " Size: " + this.Size;
    }
}
