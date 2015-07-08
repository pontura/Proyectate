using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slides : MonoBehaviour
{
    public Text maskerTitle;
    public Animation anim;
    public Text titleLabel;
    public GameObject NameLabel;
    public GameObject[] CharactersContainer;
    private ClothesSettings clothesSettings;
    private SavedSettings savedSettings;
    private Settings settings;
    private int containerId;
    private bool started = false;

    void Start()
    {
        settings = Data.Instance.settings;        
        clothesSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;
        StartCoroutine("NextSlide");    
    }
    IEnumerator NextSlide()
    {
        settings.GetNextDisciplina();

        maskerTitle.text = settings.GetDisciplina().name;

        if (started)
        {
            anim.Play("SlidesMaskerOn");

            yield return new WaitForSeconds(2);
        }

            foreach (GameObject container in CharactersContainer)
                container.SetActive(false);
            containerId = Random.Range(0, CharactersContainer.Length);
            CharactersContainer[containerId].SetActive(true);
            titleLabel.text = settings.GetDisciplina().name;    
            AddPlayers();

        yield return new WaitForSeconds(1.5f);

        anim.Play("SlidesMaskerOff");

        started = true;

        yield return new WaitForSeconds(4);

            Resources.UnloadUnusedAssets();
            StartCoroutine("NextSlide"); 
        
    }
    public void StartGame()
    {
        Data.Instance.LoadLevel("Disciplinas");
    }
    void AddPlayers()
    {
        int id = 1;
        foreach (CharacterManager characterManager in CharactersContainer[containerId].GetComponentsInChildren<CharacterManager>())
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
            newNameLabel.transform.SetParent(CharactersContainer[containerId].transform);
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
