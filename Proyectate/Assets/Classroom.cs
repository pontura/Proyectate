using UnityEngine;
using System.Collections;

public class Classroom : MonoBehaviour {

    [SerializeField]
    public GameObject NameLabel;
    public GameObject CharactersContainer;
    private ClothesSettings clothesSettings;
    private SavedSettings savedSettings;

	void Start () {
        clothesSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;
        AddPlayers();
	}
    public void Replay()
    {
        Data.Instance.LoadLevel("Slides");
    }
    public void Email()
    {
        GetComponent<EmailRequest>().Open();
    }
    void AddPlayers()
    {
        int id = 1;
        foreach (CharacterManager characterManager in CharactersContainer.GetComponentsInChildren<CharacterManager>())
        {
            AddClothes(characterManager, id);
            id++;
        }
    }
    void AddClothes(CharacterManager characterManager, int id)
    {
        
        SavedSettings.PlayerSettings playerSettings = savedSettings.GetClothes(Data.Instance.settings.disciplinaId, id);        
        if (playerSettings != null)
        {
            print("AddClothes username: " + id + " " + playerSettings.username);
            characterManager.SetCloth(clothesSettings.faces, playerSettings.face);
            characterManager.SetCloth(clothesSettings.hairs, playerSettings.hair);
            characterManager.SetCloth(clothesSettings.legs, playerSettings.bottom);
            characterManager.SetCloth(clothesSettings.shoes, playerSettings.shoes);
            characterManager.SetCloth(clothesSettings.tops, playerSettings.body);
            characterManager.SetCloth(clothesSettings.glasses, playerSettings.glasses);
            characterManager.SetColor(playerSettings.color);

            GameObject newNameLabel = Instantiate(NameLabel);
            newNameLabel.transform.SetParent(CharactersContainer.transform);
            newNameLabel.transform.localPosition = characterManager.gameObject.transform.parent.localPosition;
            newNameLabel.transform.localScale = Vector3.one;
            newNameLabel.GetComponentInChildren<TextMesh>().text = playerSettings.username;
            
        }
        else
        {
            characterManager.gameObject.SetActive(false);
        }
    }
}
