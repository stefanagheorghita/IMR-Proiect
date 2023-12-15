using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDinosaurData", menuName = "DinosaurData")]
public class DinosaurData : ScriptableObject
{
    public string dinosaurName;
    public string description;
    public string historicalData;
    public GameObject dinosaurModel;

}
