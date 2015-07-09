using UnityEngine;
using System.Collections;

public class Disciplinas : MonoBehaviour {
    
    public void Select(int id)
    {
        Data.Instance.settings.SetDisciplina(id);
        Data.Instance.LoadLevel("Customizer");
    }
}
