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

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        readImages();
        Debug.Log("Loaded");
        this.spriteRenderer.sprite = Sprite.Create(images[0], new Rect(0, 0, images[0].width, images[0].height), new Vector2(0.5f, 0.5f));
        Debug.Log(images.Length);
        
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
        Debug.Log(fileNames.Length);
        for (int i = 0; i < fileNames.Length; i++)
        {
            Debug.Log(fileNames[i].Split('.')[0]);
            images[i] = Resources.Load<Texture2D>(PATH + fileNames[i].Split('/').Last().Split('.')[0]);
            Debug.Log(images[i]);
        }

    }
}
