using System.Collections.Generic;
public class Listener<T>
{
    private List<T> dataList;
    private int readIndex;

    public Listener()
    {
        this.dataList = new List<T>();
        this.readIndex = 0;
    }

    public void Listen(T data)
    {
        this.dataList.Add(data);
    }

    public List<T> Read()
    {
        if (readIndex == dataList.Count) return null;
        List<T> newList = this.dataList.GetRange(readIndex, dataList.Count - readIndex);
        readIndex = dataList.Count;
        return newList;
    }
}
