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
        pathPreFix = @"file://";
        clothSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;
      //  GetComponent<Animation>().Play("shoes1");
    }
    public void Idle()
    {
        GetComponent<Animator>().Play("Idle1");
    }
    public void ChangeShoes(bool next)
    {
        savedSettings.myPlayerSettings.shoes = ChangeCloth(clothSettings.shoes, next, savedSettings.myPlayerSettings.shoes);
        GetComponent<Animator>().Play("shoes1");
    }
    public void ChangeTop(bool next)
    {
        savedSettings.myPlayerSettings.body = ChangeCloth(clothSettings.tops, next, savedSettings.myPlayerSettings.body);
        GetComponent<Animator>().Play("top1");
    }
    public void ChangeHair(bool next)
    {
        savedSettings.myPlayerSettings.hair = ChangeCloth(clothSettings.hairs, next, savedSettings.myPlayerSettings.hair);
        GetComponent<Animator>().Play("hair1");
    }
    public void ChangeLegs(bool next)
    {
        savedSettings.myPlayerSettings.bottom = ChangeCloth(clothSettings.legs, next, savedSettings.myPlayerSettings.bottom);
        GetComponent<Animator>().Play("bottom1");
    }
    public void ChangeFaces(bool next)
    {
        savedSettings.myPlayerSettings.face = ChangeCloth(clothSettings.faces, next, savedSettings.myPlayerSettings.face);
        GetComponent<Animator>().Play("hair1");
    }
    private string pathTemp;
    public int ChangeCloth(List<string> arr, bool next, int idNum)
    {
        if (next) idNum++;
        else idNum--;
        if (idNum < 0) idNum = arr.Count - 1;
        else if (idNum > arr.Count-1) idNum = 0;

        SetCloth(arr, idNum);

        return idNum;
    }
    public void SetCloth(List<string> arr, int idNum)
    {
        pathPreFix = @"file://";
        clothSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;

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
    }
    public void ChangeColor(bool next)
    {
        if (next)
            savedSettings.myPlayerSettings.color++;
        else savedSettings.myPlayerSettings.color--;
        if (savedSettings.myPlayerSettings.color < 0) savedSettings.myPlayerSettings.color = colors.Length - 1;
        else if (savedSettings.myPlayerSettings.color >= colors.Length) savedSettings.myPlayerSettings.color = 0;

        SetColor(savedSettings.myPlayerSettings.color);
    }
    public void SetColor(int colorID)
    {
        foreach (GameObject go in skin)
        {
            go.GetComponent<SpriteRenderer>().color = colors[colorID];
        }
    }


    private IEnumerator LoadImages(SpriteRenderer spriteContainer)
    {
       // print("loading: " + pathTemp);
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
