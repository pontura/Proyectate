using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Slides : MonoBehaviour
{
    public GameObject Logo;
    public GameObject Scene;

    public Lisiados[] lisiados;
    public GameObject namesContainer;
    public Aula aula;
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

    public List<CharacterManager> allCharacter;

    void Start()
    {
        settings = Data.Instance.settings;        
        clothesSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;
        vueltas = 0;
        StartCoroutine("NextSlide");
    }
    private int vueltas;
    IEnumerator NextSlide()
    {
        vueltas++;
        settings.GetNextDisciplina();
        maskerTitle.text = settings.GetDisciplina().name;
        
        if (!started)
        {
            maskerTitle.text = "PROYECTATE...";
            Logo.SetActive(true);
            Scene.SetActive(false);
            anim.Play("SlidesMaskerOff");
            yield return new WaitForSeconds(4);
            maskerTitle.text = settings.GetDisciplina().name;
            anim.Play("SlidesMaskerOn");
            yield return new WaitForSeconds(2);
            Logo.SetActive(false);
            Scene.SetActive(true);
            
        }
        else if (vueltas == 3)
        {
            vueltas = 0;
            maskerTitle.text = "PROYECTATE...";
            anim.Play("SlidesMaskerOn");
            yield return new WaitForSeconds(2);
            Logo.SetActive(true);
            Scene.SetActive(false);
            anim.Play("SlidesMaskerOff");
            yield return new WaitForSeconds(4);
            maskerTitle.text = settings.GetDisciplina().name;
             anim.Play("SlidesMaskerOn");
            yield return new WaitForSeconds(2);
            Logo.SetActive(false);
            Scene.SetActive(true);
        }
        else
        {

            anim.Play("SlidesMaskerOn");
            yield return new WaitForSeconds(2);

        }

        foreach (Lisiados lisiado in lisiados)
            lisiado.SetOn();

        if (allCharacter != null)
        {
            foreach (CharacterManager cm in allCharacter)
                cm.gameObject.SetActive(true);
            allCharacter.Clear();
        }

        aula.LoadSprite();

        foreach (Transform tr in namesContainer.GetComponent<Transform>())
            Destroy(tr.gameObject);

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
            allCharacter.Add(characterManager);
            AddClothes(characterManager, id);
            id++;
        }

    }
    void AddClothes(CharacterManager characterManager, int id)
    {
        SavedSettings.PlayerSettings playerSettings = savedSettings.GetClothes(Data.Instance.settings.disciplinaId, id);
        if (playerSettings != null)
        {
            characterManager.SetCloth(clothesSettings.faces, playerSettings.face);
            characterManager.SetCloth(clothesSettings.hairs, playerSettings.hair);
            characterManager.SetCloth(clothesSettings.legs, playerSettings.bottom);
            characterManager.SetCloth(clothesSettings.shoes, playerSettings.shoes);
            characterManager.SetCloth(clothesSettings.tops, playerSettings.body);
            characterManager.SetColor(playerSettings.color);

            GameObject newNameLabel = Instantiate(NameLabel);
            newNameLabel.transform.SetParent(namesContainer.transform);
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
