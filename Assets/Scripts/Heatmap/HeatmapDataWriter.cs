using System.IO;

/// <summary>
/// Write data to a file.
/// Default file is Data/gazelog-{timestamp}.csv
/// </summary>
public static class HeatmapDataWriter
{
    public static void WriteAll(string[] data, string infoJSON)
    {
        string date = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        DirectoryInfo dir = Directory.CreateDirectory(string.Format(@"Data/Gazelog-{0}", date));
        File.WriteAllLines(dir.FullName + "/" + getCSVFileName(date), data);
        File.WriteAllText(dir.FullName + "/" + getJSONFileName(), infoJSON);
    }

    private static string getCSVFileName(string date)
    {
        return string.Format(@"gazelog-{0}.csv", date);
    }

    private static string getJSONFileName()
    {
        return "info.json";
    }
}
