using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
 

public class CharacterManager : MonoBehaviour {


    public GameObject[] skin;
    public Color[] colors;

    public SpriteRenderer[] shoesContainer;
    public SpriteRenderer[] BodyContainer;
    public SpriteRenderer[] Arm1Container;
    public SpriteRenderer[] Arm2Container;
    public SpriteRenderer[] Arm3Container;

    public SpriteRenderer[] HipContainer;
    public SpriteRenderer[] LegsContainer;

    public SpriteRenderer[] Hair1Container;
    public SpriteRenderer[] Hair2Container;

    public SpriteRenderer[] HeadContainer;
    

    GameObject[] gameObj;
    Texture2D[] textList;

    
    private string pathPreFix;
    private ClothesSettings clothSettings;
    private SavedSettings savedSettings;

    void Start()
    {
        clothSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;
    }
    public void ChangeShoes(bool next)
    {
        savedSettings.myPlayerSettings.shoes = ChangeCloth(clothSettings.shoes, next, savedSettings.myPlayerSettings.shoes);
    }
    public void ChangeTop(bool next)
    {
        savedSettings.myPlayerSettings.body = ChangeCloth(clothSettings.tops, next, savedSettings.myPlayerSettings.body);
    }
    public void ChangeHair(bool next)
    {
        savedSettings.myPlayerSettings.hair = ChangeCloth(clothSettings.hairs, next, savedSettings.myPlayerSettings.hair);
    }
    public void ChangeLegs(bool next)
    {
        savedSettings.myPlayerSettings.bottom = ChangeCloth(clothSettings.legs, next, savedSettings.myPlayerSettings.bottom);
    }
    public void ChangeFaces(bool next)
    {
        savedSettings.myPlayerSettings.face = ChangeCloth(clothSettings.faces, next, savedSettings.myPlayerSettings.face);
    }
    private string pathTemp;
    public int ChangeCloth(List<string> arr, bool next, int idNum)
    {
        pathPreFix = @"file://";
        if (next) idNum++;
        else idNum--;
        if (idNum < 0) idNum = arr.Count - 1;
        else if (idNum > arr.Count-1) idNum = 0;

        if (arr == clothSettings.shoes)
        {
            pathTemp = pathPreFix + clothSettings.shoes[idNum] + ".png";
            StartCoroutine("LoadImages", shoesContainer[0]);
            StartCoroutine("LoadImages", shoesContainer[1]);
        }
        else if (arr == clothSettings.faces)
        {
            pathTemp = pathPreFix + clothSettings.faces[idNum] + ".png";
            StartCoroutine("LoadImages", HeadContainer[0]);
        }
        else if (arr == clothSettings.tops)
        {
            pathTemp = pathPreFix + clothSettings.tops[idNum] + "_a.png";
            StartCoroutine("LoadImages", BodyContainer[0]);

            pathTemp = pathPreFix + clothSettings.tops[idNum] + "_b.png";
            StartCoroutine("LoadImages", Arm1Container[0]);
            StartCoroutine("LoadImages", Arm1Container[1]);

            pathTemp = pathPreFix + clothSettings.tops[idNum] + "_c.png";
            StartCoroutine("LoadImages", Arm2Container[0]);
            StartCoroutine("LoadImages", Arm2Container[1]);

            pathTemp = pathPreFix + clothSettings.tops[idNum] + "_d.png";
            StartCoroutine("LoadImages", Arm3Container[0]);
            StartCoroutine("LoadImages", Arm3Container[1]);
        }
        else if (arr == clothSettings.legs)
        {
            pathTemp = pathPreFix + clothSettings.legs[idNum] + "_a.png";
            StartCoroutine("LoadImages", HipContainer[0]);

            pathTemp = pathPreFix + clothSettings.legs[idNum] + "_b.png";
            StartCoroutine("LoadImages", LegsContainer[0]);
            StartCoroutine("LoadImages", LegsContainer[1]);
        }
        else if (arr == clothSettings.hairs)
        {
            pathTemp = pathPreFix + clothSettings.hairs[idNum] + "_a.png";
            StartCoroutine("LoadImages", Hair1Container[0]);

            pathTemp = pathPreFix + clothSettings.hairs[idNum] + "_b.png";
            StartCoroutine("LoadImages", Hair2Container[0]);
        }
        return idNum;
    }
    public void ChangeColor(bool next)
    {
        if (next)
            savedSettings.myPlayerSettings.color++;
        else savedSettings.myPlayerSettings.color--;
        if (savedSettings.myPlayerSettings.color < 0) savedSettings.myPlayerSettings.color = colors.Length - 1;
        else if (savedSettings.myPlayerSettings.color >= colors.Length) savedSettings.myPlayerSettings.color = 0;

        SetColor();
    }
    public void SetColor()
    {
        foreach (GameObject go in skin)
        {
            go.GetComponent<SpriteRenderer>().color = colors[savedSettings.myPlayerSettings.color];
        }
    }


    private IEnumerator LoadImages(SpriteRenderer spriteContainer)
    {
        print("loading: " + pathTemp);
        WWW www = new WWW(pathTemp);
        yield return www;

        if (www.error != null)
        {
            spriteContainer.sprite = null;
        } else
        {
            Sprite sprite = new Sprite();

            sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100.0f);

            spriteContainer.sprite = sprite;
        }
    }
}
