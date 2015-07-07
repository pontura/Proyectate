using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour
{
    public string username;
    public string email;

    const string PREFAB_PATH = "Data";
    private Fade fade;
    static Data mInstance = null;
    public Settings settings;
    public SavedSettings savedSettings;
    public ClothesSettings clothesSettings;

    public static Data Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<Data>();

                if (mInstance == null)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
                    mInstance = go.GetComponent<Data>();
                }
            }
            return mInstance;
        }
    }
    public void LoadLevel(string aLevelName)
    {
        LoadLevel(aLevelName, 0.5f, 0.5f, Color.black);
    }
    public void LoadLevel(string aLevelName, float aFadeOutTime, float aFadeInTime, Color aColor)
    {
        Time.timeScale = 1;
        fade.LoadLevel(aLevelName, aFadeOutTime, aFadeInTime, aColor);
    }
    void Awake()
    {
        fade = GetComponentInChildren<Fade>();

        fade.gameObject.SetActive(true);
        if (!mInstance)
            mInstance = this;
        //otherwise, if we do, kill this thing
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        settings = GetComponent<Settings>();
        savedSettings = GetComponent<SavedSettings>();
        clothesSettings = GetComponent<ClothesSettings>();

    }
    public void Reset()
    {

    }
}
