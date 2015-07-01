using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
 

public class CharacterManager : MonoBehaviour {

    public List<string> shoes;
    public int shoesId;

    public List<string> tops;
    public int topsId;

    public GameObject[] skin;
    public Color[] colors;
    public int colorId;

    public SpriteRenderer[] shoesContainer;

    

    GameObject[] gameObj;
    Texture2D[] textList;

    
    private string pathPreFix;



	void Start () {
        LoadArray(shoes, @"images\shoes\");
        LoadArray(tops, @"images\top\");
	}

    private void LoadArray(List<string> arr, string path)
    {
        pathPreFix = @"file://";
        string lastName = "";
        foreach (string name in System.IO.Directory.GetFiles(path, "*.png"))
        {
           
            if (lastName != name)
            {
                arr.Add(name);
                lastName = name;
            }
        }
    }
    public void ChangeShoes(bool next)
    {
        shoesId = ChangeCloth(shoes, next, shoesId);
    }
    public int ChangeCloth(List<string> arr, bool next, int idNum)
    {
        if (next) idNum++;
        else idNum--;
        if (idNum < 0) idNum = arr.Count - 1;
        else if (idNum > arr.Count) idNum = 0;
        StartCoroutine("LoadImages", idNum);
        return idNum;
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
        textList = new Texture2D[shoes.Count];

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
