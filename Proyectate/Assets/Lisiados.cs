using UnityEngine;
using System.Collections;

public class Lisiados : MonoBehaviour {

    public GameObject lisiado1;
    public GameObject lisiado2;
    public GameObject lisiado3;
    private int id;

    void Start()
    {
        SetOff();
    }
	void SetOff () {
        lisiado1.SetActive(false);
        lisiado2.SetActive(false);
        lisiado3.SetActive(false);
	}
    public void SetOn()
    {
        SetOff();
        id = Data.Instance.settings.disciplinaId;
        if(id == 1)
            lisiado1.SetActive(true);
        if (id == 2)
            lisiado2.SetActive(true);
        if (id == 3)
            lisiado3.SetActive(true);
    }
}
