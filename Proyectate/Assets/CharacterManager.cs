using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
 

public class CharacterManager : MonoBehaviour {

    public GameObject[] skin;
    public Color[] colors;

    public SpriteRenderer[] shoesContainer;

    public int colorId;

    GameObject[] gameObj;
    Texture2D[] textList;

    public string[] shoes;
    private string pathPreFix; 

	void Start () {
        string path = @"images\shoes\";
        pathPreFix = @"file://";
        shoes = System.IO.Directory.GetFiles(path, "*.png");
        return;


	    string dir = "Assets/images/shoes";
        string[] files = Directory.GetFiles(dir);
        foreach (string file in files)
            print(Path.GetFileName(file));
	}
    public void ChangeShoes(bool next)
    {
        StartCoroutine("LoadImages", Random.Range(0,3));
       foreach (SpriteRenderer spriteRenderer in shoesContainer)
        {
         //  spriteRenderer.sprite = 
        }
    }
    public void ChangeColor(bool next)
    {
        if (next)
            colorId++;
        else colorId--;
        if (colorId < 0) colorId = colors.Length-1;
        else if (colorId >= colors.Length) colorId = 0;

        SetColor();
    }
    public void SetColor()
    {
        print(" SetColor " + colorId);
        foreach (GameObject go in skin)
        {
            go.GetComponent<SpriteRenderer>().color = colors[colorId];
        }
    }


    private IEnumerator LoadImages(int id)
    {
        textList = new Texture2D[shoes.Length];

        string pathTemp = pathPreFix + shoes[id];
        WWW www = new WWW(pathTemp);
        yield return www;


        //Texture2D texTmp = new Texture2D(1024, 1024, TextureFormat.DXT1, false);
        //www.LoadImageIntoTexture(texTmp);


        //shoesContainer[0].material.mainTexture =  texTmp;



        Sprite sprite = new Sprite();
        sprite = Sprite.Create(www.texture, new Rect(0, 0, 100, 140), new Vector2(0, 0), 100.0f);

        shoesContainer[0].sprite = sprite;
       // renderer.material = mat;
    }
}
