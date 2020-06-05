using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ImageContoller : MonoBehaviour
{
    private const string PATH = "images/";
    private const string FULL_PATH = "Assets/Resources/" + PATH;

    private Sprite[] images;

    private SpriteRenderer spriteRenderer;

    private int spriteIndex;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        readImages();
        this.spriteIndex = 0;
        this.spriteRenderer.sprite = images[this.spriteIndex];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void readImages()
    {
        string[] fileNames = Directory.GetFiles(FULL_PATH);
        fileNames = fileNames.ToList<string>().Where(x => !x.EndsWith(".meta")).ToArray<string>();
        images = new Sprite[fileNames.Length];
        for (int i = 0; i < fileNames.Length; i++)
        {
            Texture2D temp = Resources.Load<Texture2D>(PATH + fileNames[i].Split('/').Last().Split('.')[0]);
            images[i] = Sprite.Create(temp, new Rect(0, 0, temp.width, temp.height), new Vector2(0.5f, 0.5f));
        }

    }

    public void NextImage()
    {
        this.spriteIndex = (this.spriteIndex + 1) % this.images.Length;
        this.spriteRenderer.sprite = images[this.spriteIndex];
        Debug.Log(this.spriteIndex);
    }

    public void PreviousImage()
    {
        this.spriteIndex = (this.spriteIndex - 1) < 0 ? this.images.Length - 1 : this.spriteIndex - 1;
        this.spriteRenderer.sprite = images[this.spriteIndex];
    }
}
