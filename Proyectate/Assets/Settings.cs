﻿using System;
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

    public void SetDisciplina(int id)
    {
        print("SET " + id);
        disciplina = disciplinas[id];
    }

}
