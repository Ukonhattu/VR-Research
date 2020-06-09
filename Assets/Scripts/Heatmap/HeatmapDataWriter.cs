/// <summary>
/// Write data to a file.
/// Default file is Data/gazelog-{timestamp}.csv
/// </summary>
public static class HeatmapDataWriter
{
    public static void WriteAll(string[] data)
    {
        System.IO.File.WriteAllLines(getFileName(), data);
    }

    private static string getFileName()
    {
        return string.Format(@"Data/gazelog-{0}.csv", System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
    }
}
