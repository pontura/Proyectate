using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Settings : MonoBehaviour {

    [Serializable]
    public class DisciplinaData
    {
        [SerializeField]
        public string name;
        public string desc;
    }

    public List<DisciplinaData> disciplinas;

    public DisciplinaData disciplina;

    public int disciplinaId;

    public DisciplinaData GetDisciplina()
    {
        return disciplinas[disciplinaId];
    }
    public void SetDisciplina(int id)
    {
        this.disciplinaId = id;
        disciplina = disciplinas[id];
    }
    public int GetNextDisciplina()
    {
        disciplinaId++;
        if (disciplinaId > disciplinas.Count - 1)
            disciplinaId = 0;
        return disciplinaId;
    }

}
