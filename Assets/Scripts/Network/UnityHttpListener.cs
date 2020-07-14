using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Net;
using System.Threading;

public class UnityHttpListener : MonoBehaviour
{

    public NetworkConfig networkConfig;

    private HttpListener listener;
    private Thread listenerThread;

    private ImageData newImage = null;


    public static event EventHandler<ImageDataArgs> NewImageEvent;

    void Start()
    {
        listener = new HttpListener();
        listener.Prefixes.Add(networkConfig.host + ":" + networkConfig.port + "/");
        listener.Prefixes.Add(networkConfig.ip + ":" + networkConfig.port + "/");
        listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
        listener.Start();

        listenerThread = new Thread(startListener);
        listenerThread.Start();
        Debug.Log("Server Started");
    }

    void Update()
    {
        if (newImage != null)
        {
            ImageDataArgs eventData = new ImageDataArgs(newImage);
            newImage = null;
            NewImageEvent?.Invoke(this, eventData);
        }
    }

    private void startListener()
    {
        while (true)
        {
            var result = listener.BeginGetContext(ListenerCallback, listener);
            result.AsyncWaitHandle.WaitOne();
        }
    }

    private void ListenerCallback(IAsyncResult result)
    {
        var context = listener.EndGetContext(result);

        Debug.Log("Method: " + context.Request.HttpMethod);
        Debug.Log("LocalUrl: " + context.Request.Url.LocalPath);

        if (context.Request.QueryString.AllKeys.Length > 0)
            foreach (var key in context.Request.QueryString.AllKeys)
            {
                Debug.Log("Key: " + key + ", Value: " + context.Request.QueryString.GetValues(key)[0]);
            }

        if (context.Request.HttpMethod == "POST")
        {
            Thread.Sleep(1000);
            var data_text = new StreamReader(context.Request.InputStream,
                                context.Request.ContentEncoding).ReadToEnd();
            Debug.Log(data_text);
            ImageData imageData = (ImageData)new NetworkObject(data_text).GetObject();
            this.newImage = imageData;
        }

        context.Response.Close();
    }

}