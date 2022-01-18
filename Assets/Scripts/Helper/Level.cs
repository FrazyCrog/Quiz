using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Level
{ 
    [SerializeField] private int countRows; // кол-во строк

    public int CountRows => countRows;
}
