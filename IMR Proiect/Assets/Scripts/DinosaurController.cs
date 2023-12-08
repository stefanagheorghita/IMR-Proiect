using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurController : MonoBehaviour
{
    public DinosaurData tRexData;
    public DinosaurData brontosaurusData;
    public DinosaurData triceratopsData;
    public DinosaurData stegosaurusData;
    public DinosaurData velociraptorData;
    public DinosaurData pachycephalosaurusData;

    void Start()
    {
        DisplayDinosaurInformation(tRexData);
        DisplayDinosaurInformation(brontosaurusData);
        DisplayDinosaurInformation(triceratopsData);
        DisplayDinosaurInformation(stegosaurusData);
        DisplayDinosaurInformation(velociraptorData);
        DisplayDinosaurInformation(pachycephalosaurusData);
    }

    void DisplayDinosaurInformation(DinosaurData dinosaur)
    {
        if (dinosaur != null)
        {
            Debug.Log($"Dinosaur Name: {dinosaur.dinosaurName}");
            Debug.Log($"Description: {dinosaur.description}");
            Debug.Log($"Historical Data: {dinosaur.historicalData}");
            // 3D model
        }
        else
        {
            Debug.LogWarning("DinosaurData is null.");
        }
    }

}
