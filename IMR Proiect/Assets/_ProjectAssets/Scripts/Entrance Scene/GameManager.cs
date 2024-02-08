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

    private List<string> collectedTrophies = new List<string>();
    private const string CollectedTrophiesKey = "CollectedTrophies";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.DeleteAll();
        LoadCollectedDinosaurs();
        LoadCollectedTrophies();
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


      public void CollectTrophy(string trophyName)
    {
        if (!collectedTrophies.Contains(trophyName))
        {
            Debug.Log("ADDED TROPHY");
            collectedTrophies.Add(trophyName);
            SaveCollectedTrophies();
            Debug.Log("Collected Trophy: " + trophyName);
        }
        else
        {
            Debug.Log("Trophy already collected: " + trophyName);
        }
    }

    public List<string> GetCollectedTrophies()
    {
        return collectedTrophies;
    }

    private void SaveCollectedTrophies()
    {
        PlayerPrefs.SetString(CollectedTrophiesKey, string.Join(",", collectedTrophies.ToArray()));
        PlayerPrefs.Save();
        Debug.Log("Saved Collected Trophies: " + string.Join(",", collectedTrophies.ToArray()));
    }

    private void LoadCollectedTrophies()
    {
        string collectedTrophiesString = PlayerPrefs.GetString(CollectedTrophiesKey, "");
        string[] trophyArray = collectedTrophiesString.Split(',');
        collectedTrophies = new List<string>(trophyArray);
    }

    public bool IsTrophyCollected(string trophyName)
    {
        Debug.Log("Checking if trophy is collected: " + trophyName);
        Debug.Log("Collected Trophies: " + string.Join(",", collectedTrophies.ToArray()));
        return collectedTrophies.Contains(trophyName);
    }

}
