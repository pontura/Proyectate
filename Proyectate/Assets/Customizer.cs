using UnityEngine;
using System.Collections;

public class Customizer : MonoBehaviour {

    public CharacterManager characterManager;
    private ClothesSettings clothesSettings;
    private SavedSettings savedSettings;

	void Start () {
        Events.OnCustomizerButtonPrevClicked += OnCustomizerButtonPrevClicked;
        Events.OnCustomizerButtonNextClicked += OnCustomizerButtonNextClicked;

        
        clothesSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;

        savedSettings.CreateRandomPlayer();

        characterManager.SetCloth(clothesSettings.faces, savedSettings.myPlayerSettings.face);
        characterManager.SetCloth(clothesSettings.hairs, savedSettings.myPlayerSettings.hair);
        characterManager.SetCloth(clothesSettings.legs, savedSettings.myPlayerSettings.bottom);
        characterManager.SetCloth(clothesSettings.shoes, savedSettings.myPlayerSettings.shoes);
        characterManager.SetCloth(clothesSettings.tops, savedSettings.myPlayerSettings.body);
        characterManager.SetCloth(clothesSettings.glasses, savedSettings.myPlayerSettings.glasses);
        characterManager.SetColor(savedSettings.myPlayerSettings.color);
	}
    void OnDestroy()
    {
        Events.OnCustomizerButtonPrevClicked -= OnCustomizerButtonPrevClicked;
        Events.OnCustomizerButtonNextClicked -= OnCustomizerButtonNextClicked;
    }
    void OnCustomizerButtonNextClicked(int id)
    {
        Clicked(id, true);
    }
    void OnCustomizerButtonPrevClicked(int id)
    {
        Clicked(id, false);
    }
    void Clicked(int id, bool next)
    {
        //print("Clicked: " + id + " - next: " + next);
        switch (id)
        {
            case 1:
                characterManager.ChangeColor(next);
                break;
            case 2:
                characterManager.ChangeHair(next);
                break;
            case 3:
                characterManager.ChangeFaces(next);
                break;
            case 4:
                characterManager.ChangeTop(next);
                break;
            case 5:
                characterManager.ChangeLegs(next);
                break;
            case 6:
                characterManager.ChangeShoes(next);
                break;
            case 7:
                characterManager.ChangeGlasses(next);
                break;
        }
        Resources.UnloadUnusedAssets();
    }
    public void Ready()
    {
        Data.Instance.LoadLevel("NameRequest");
    }
    public void Back()
    {
        Data.Instance.LoadLevel("Disciplinas");
    }
}
