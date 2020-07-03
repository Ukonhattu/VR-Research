using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ImageContoller : MonoBehaviour
{
    private const string PATH = "images/";
    private const string FULL_PATH = "Assets/Resources/" + PATH;

    private List<Texture2D> images;

    private MeshRenderer targetRenderer;

    private int textureIndex;

    private Listener<ImageEventData> imageDataListener;

    // Start is called before the first frame update
    void Start()
    {
        this.targetRenderer = gameObject.GetComponent<MeshRenderer>();
        readImagesFromDir();
        this.textureIndex = 0;
        this.targetRenderer.material.mainTexture = images[this.textureIndex];
        this.scalePlane();
        this.imageDataListener = new Listener<ImageEventData>();
        this.images = new List<Texture2D>();
        Observer.Instance.Subscribe(this.imageDataListener);       
    }

    // Update is called once per frame
    void Update()
    {
        readImagesFromListener();   
    }

    private void readImagesFromDir()
    {
        string[] fileNames = Directory.GetFiles(FULL_PATH);
        fileNames = fileNames.ToList<string>().Where(x => !x.EndsWith(".meta")).ToArray<string>();
        for (int i = 0; i < fileNames.Length; i++)
        {
            images.Add(Resources.Load<Texture2D>(PATH + fileNames[i].Split('/').Last().Split('.')[0]));
        }

    }

    private void readImagesFromListener()
    {
        List<ImageEventData> data = this.imageDataListener.Read();
        if (data != null && data.Count > 0)
        {
            foreach(ImageEventData eventData in data)
            {
                images.Add(Resources.Load<Texture2D>(eventData.ImageData.ImagePath));
            }
        }
    }

    public void NextImage()
    {
        this.textureIndex = (this.textureIndex + 1) % this.images.Count;
        this.targetRenderer.material.mainTexture = images[this.textureIndex];
        this.scalePlane();
    }

    public void PreviousImage()
    {
        this.textureIndex = (this.textureIndex - 1) < 0 ? this.images.Count - 1 : this.textureIndex - 1;
        this.targetRenderer.material.mainTexture = images[this.textureIndex];
        this.scalePlane();
    }

    private void scalePlane()
    {
        this.targetRenderer.gameObject.transform.localScale = new Vector3(images[this.textureIndex].width / 1000f, 1f, images[this.textureIndex].height / 1000f);
    }
}
