using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class ClothesSettings : MonoBehaviour {

    public List<string> glasses;
    public List<string> shoes;
    public List<string> tops;
    public List<string> hairs;
    public List<string> legs;
    public List<string> faces;

	void Start () {
        LoadArray(glasses, @"images\glasses\");
        LoadArray(shoes, @"images\shoes\");
        LoadArray(tops, @"images\top\");
        LoadArray(hairs, @"images\hair\");
        LoadArray(legs, @"images\bottom\");
        LoadArray(faces, @"images\face\");
	}

    private void LoadArray(List<string> arr, string path)
    {
        string lastName = "";

        foreach (string name in System.IO.Directory.GetFiles(path, "*.png"))
        {
            String[] textSplit = name.Split("."[0])[0].Split("_"[0]);


            string realName = textSplit[0] + "_" + textSplit[1];
           // print(name + "           " + textSplit.Length);

            if (realName != lastName)
            {
                arr.Add(realName);
                lastName = realName;
            }
        }
    }
}
