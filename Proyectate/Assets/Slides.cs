using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slides : MonoBehaviour
{
    public Text titleLabel;
    public GameObject NameLabel;
    public GameObject CharactersContainer;
    private ClothesSettings clothesSettings;
    private SavedSettings savedSettings;
    private Settings settings;

    void Start()
    {
        settings = Data.Instance.settings;        
        clothesSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;
        NextSlide();        
    }
    void NextSlide()
    {
        settings.GetNextDisciplina();
        AddPlayers();
        
        titleLabel.text = settings.GetDisciplina().name;

        Invoke("NextSlide", 4);
    }
    public void StartGame()
    {
        Data.Instance.LoadLevel("Disciplinas");
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
            characterManager.gameObject.SetActive(true);
            characterManager.SetCloth(clothesSettings.faces, playerSettings.face);
            characterManager.SetCloth(clothesSettings.hairs, playerSettings.hair);
            characterManager.SetCloth(clothesSettings.legs, playerSettings.bottom);
            characterManager.SetCloth(clothesSettings.shoes, playerSettings.shoes);
            characterManager.SetCloth(clothesSettings.tops, playerSettings.body);
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
