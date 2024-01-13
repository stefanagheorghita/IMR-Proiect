using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private List<string> collectedDinosaurs = new List<string>();

    private const string CollectedDinosaursKey = "CollectedDinosaurs";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.DeleteAll();
        LoadCollectedDinosaurs();
    }

    public void CollectDinosaur(string dinosaurName)
    {
    
        if (!collectedDinosaurs.Contains(dinosaurName))
        {
            Debug.Log("ADDED DINOSAUR");
            collectedDinosaurs.Add(dinosaurName);

            
            SaveCollectedDinosaurs();

 
            Debug.Log("Collected Dinosaur: " + dinosaurName);
        }
        else
        {
    
            Debug.Log("Dinosaur already collected: " + dinosaurName);
        }
    }


    public List<string> GetCollectedDinosaurs()
    {
        return collectedDinosaurs;
    }

    private void SaveCollectedDinosaurs()
    {
        PlayerPrefs.SetString(CollectedDinosaursKey, string.Join(",", collectedDinosaurs.ToArray()));
        Debug.Log("Saved Collected Dinosaurs: " + string.Join(",", collectedDinosaurs.ToArray()));
        PlayerPrefs.Save();
    }


    private void LoadCollectedDinosaurs()
    {
        string collectedDinosaursString = PlayerPrefs.GetString(CollectedDinosaursKey, "");
        string[] dinosaurArray = collectedDinosaursString.Split(',');


        collectedDinosaurs = new List<string>(dinosaurArray);
    }

    public bool IsDinosaurCollected(string dinosaurName)
    {
        Debug.Log("Checking if dinosaur is collected: " + dinosaurName);
        Debug.Log("Collected Dinosaurs: " + string.Join(",", collectedDinosaurs.ToArray()));
        return collectedDinosaurs.Contains(dinosaurName);
    }
}
