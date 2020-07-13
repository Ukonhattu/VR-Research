using System;
public class ImageDataArgs : EventArgs
{
    public ImageData ImageData { get; }

    public ImageDataArgs(ImageData data)
    {
        ImageData = data;   
    }
}
