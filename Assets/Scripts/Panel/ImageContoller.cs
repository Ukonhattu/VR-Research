using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ImageContoller : MonoBehaviour
{
    private const string PATH = "images/";
    private const string FULL_PATH = "Assets/Resources/" + PATH;

    private Texture2D[] images;

    private MeshRenderer targetRenderer;

    private int textureIndex;

    // Start is called before the first frame update
    void Start()
    {
        this.targetRenderer = gameObject.GetComponent<MeshRenderer>();
        readImages();
        this.textureIndex = 0;
        this.targetRenderer.material.mainTexture = images[this.textureIndex];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void readImages()
    {
        string[] fileNames = Directory.GetFiles(FULL_PATH);
        fileNames = fileNames.ToList<string>().Where(x => !x.EndsWith(".meta")).ToArray<string>();
        images = new Texture2D[fileNames.Length];
        for (int i = 0; i < fileNames.Length; i++)
        {
            images[i] = Resources.Load<Texture2D>(PATH + fileNames[i].Split('/').Last().Split('.')[0]);
        }

    }

    public void NextImage()
    {
        this.textureIndex = (this.textureIndex + 1) % this.images.Length;
        this.targetRenderer.material.mainTexture = images[this.textureIndex];
        Debug.Log(this.textureIndex);
    }

    public void PreviousImage()
    {
        this.textureIndex = (this.textureIndex - 1) < 0 ? this.images.Length - 1 : this.textureIndex - 1;
        this.targetRenderer.material.mainTexture = images[this.textureIndex];
    }
}
