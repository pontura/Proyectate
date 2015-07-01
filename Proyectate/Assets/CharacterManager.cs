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
    public SpriteRenderer[] BodyContainer;
    public SpriteRenderer[] Arm1Container;
    public SpriteRenderer[] Arm2Container;
    public SpriteRenderer[] Arm3Container;

    

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
            String[] textSplit = name.Split("."[0])[0].Split("_"[0]);
            if (textSplit[0] != lastName)
            {
                arr.Add(textSplit[0]);
                lastName = textSplit[0];
            }
        }
    }
    public void ChangeShoes(bool next)
    {
        shoesId = ChangeCloth(shoes, next, shoesId);
    }
    public void ChangeTop(bool next)
    {
        topsId = ChangeCloth(tops, next, topsId);
    }
    private string pathTemp;
    public int ChangeCloth(List<string> arr, bool next, int idNum)
    {
        if (next) idNum++;
        else idNum--;
        if (idNum < 0) idNum = arr.Count - 1;
        else if (idNum > arr.Count-1) idNum = 0;

        if (arr == shoes)
        {
            pathTemp = pathPreFix + shoes[idNum] + ".png";
            StartCoroutine("LoadImages", shoesContainer[0]);
            StartCoroutine("LoadImages", shoesContainer[1]);
        }
        else if (arr == tops)
        {
            pathTemp = pathPreFix + tops[idNum] + "_a.png";
            StartCoroutine("LoadImages", BodyContainer[0]);

            pathTemp = pathPreFix + tops[idNum] + "_b.png";
            StartCoroutine("LoadImages", Arm1Container[0]);
            StartCoroutine("LoadImages", Arm1Container[1]);

            pathTemp = pathPreFix + tops[idNum] + "_c.png";
            StartCoroutine("LoadImages", Arm2Container[0]);
            StartCoroutine("LoadImages", Arm2Container[1]);

            pathTemp = pathPreFix + tops[idNum] + "_d.png";
            StartCoroutine("LoadImages", Arm3Container[0]);
            StartCoroutine("LoadImages", Arm3Container[1]);
        }
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
        foreach (GameObject go in skin)
        {
            go.GetComponent<SpriteRenderer>().color = colors[colorId];
        }
    }


    private IEnumerator LoadImages(SpriteRenderer spriteContainer)
    {
        print("loading: " + pathTemp);
        WWW www = new WWW(pathTemp);
        yield return www;


        Sprite sprite = new Sprite();

        sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100.0f);

        spriteContainer.sprite = sprite;
       // renderer.material = mat;
    }
}
