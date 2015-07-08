using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;


public class EmailRequest : MonoBehaviour
{

    public GameObject signal;
    public Text inputField;
    public CharacterManager characterManager;
    private ClothesSettings clothesSettings;
    private SavedSettings savedSettings;

    void Start()
    {
        signal.SetActive(false);
        clothesSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;
        characterManager.SetCloth(clothesSettings.faces, savedSettings.myPlayerSettings.face);
        characterManager.SetCloth(clothesSettings.hairs, savedSettings.myPlayerSettings.hair);
        characterManager.SetCloth(clothesSettings.legs, savedSettings.myPlayerSettings.bottom);
        characterManager.SetCloth(clothesSettings.shoes, savedSettings.myPlayerSettings.shoes);
        characterManager.SetCloth(clothesSettings.tops, savedSettings.myPlayerSettings.body);
        characterManager.SetColor(savedSettings.myPlayerSettings.color);
    }
    public void Ready()
    {
        if (inputField.text.Length > 0)
        {
            if (IsValidEmail(inputField.text)) 
                Data.Instance.LoadLevel("Slides");
            else
                signal.SetActive(true);
        }
    }
    public void Back()
    {
        Data.Instance.LoadLevel("Slides");
    }
    bool IsValidEmail(string strIn)
    {
        return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
    }
}
