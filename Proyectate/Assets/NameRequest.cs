using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameRequest : MonoBehaviour {

    public Text inputField;
    public CharacterManager characterManager;
    private ClothesSettings clothesSettings;
    private SavedSettings savedSettings;

	void Start () {
        clothesSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;
        characterManager.SetCloth(clothesSettings.faces, savedSettings.myPlayerSettings.face);
        characterManager.SetCloth(clothesSettings.hairs, savedSettings.myPlayerSettings.hair);
        characterManager.SetCloth(clothesSettings.legs, savedSettings.myPlayerSettings.bottom);
        characterManager.SetCloth(clothesSettings.shoes, savedSettings.myPlayerSettings.shoes);
        characterManager.SetCloth(clothesSettings.tops, savedSettings.myPlayerSettings.body);
        characterManager.SetCloth(clothesSettings.glasses, savedSettings.myPlayerSettings.glasses);
        characterManager.SetColor(savedSettings.myPlayerSettings.color);
	}
	public void Ready()
    {
        if (inputField.text.Length > 0)
        {
            savedSettings.myPlayerSettings.username = inputField.text;            
            Data.Instance.savedSettings.LoadSavedPlayers();
            Data.Instance.savedSettings.AddPlayer();
            Data.Instance.LoadLevel("Classroom");
        }
    }
    public void Back()
    {
         Data.Instance.LoadLevel("Customizer");
    }
}
