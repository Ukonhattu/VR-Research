using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class ImageContoller : MonoBehaviour
{

    

    private const string PATH = "images/";
    private const string FULL_PATH = "Assets/Resources/" + PATH;

    private List<Texture2D> images;

    private MeshRenderer targetRenderer;

    private int textureIndex;


    // Start is called before the first frame update
    void Start()
    {
        this.images = new List<Texture2D>();
        this.targetRenderer = gameObject.GetComponent<MeshRenderer>();
        readImagesFromDir(1);
        this.textureIndex = 0;
        this.targetRenderer.material.mainTexture = images[this.textureIndex];
        this.scalePlane();
        UnityHttpListener.NewImageEvent += handleNewImage;
    }

    private void readImagesFromDir(int count = 0)
    {
        string[] fileNames = Directory.GetFiles(FULL_PATH);
        fileNames = fileNames.ToList<string>().Where(x => !x.EndsWith(".meta")).ToArray<string>();
        int end = count == 0 ? fileNames.Length : count;
        for (int i = 0; i < end; i++)
        {
            images.Add(Resources.Load<Texture2D>(PATH + fileNames[i].Split('/').Last().Split('.')[0]));
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

    void handleNewImage(object sender, ImageDataArgs a)
    {
        images.Add(Resources.Load<Texture2D>(a.ImageData.ImagePath));
    }
    

 }

