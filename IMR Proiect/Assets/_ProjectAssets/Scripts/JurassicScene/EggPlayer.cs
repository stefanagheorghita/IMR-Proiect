using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class EggPlayer : MonoBehaviour
{
    public Transform player;

    public float distance = 2f;
    private bool activated = false;
    public GameObject[] dinosaurs;

    public GameObject candyPrefab;

    public int candiesPerSpawn = 20;

    public int maxCandies = 500;

    private int candies = 0;
  
    public ParticleSystem[] particleToCreate;
    void Start()
    {
        
    }

  
    void Update()
    {
        if (activated) Effects();
        else {
        if (Vector3.Distance(transform.position, player.position) <  distance)
        {
            activated = true;
        foreach (GameObject dino in dinosaurs)
        {
            Destroy(dino);
        }
        
        foreach (ParticleSystem particle in particleToCreate)
        {
            particle.Play();
        }
            if (InstructionsManager.Instance.GetCurrentDinosaur() == "diplodocus")

           { DinosaurCollectedManager.Instance.ShowInstructionsForDuration(InstructionsManager.Instance.GetCurrentDinosaur(), 5f);
            InstructionsManager.Instance.ChangeDinosaur("aaa");
           }
           Destroy(gameObject, 5f);
        }
        } 
    }

    void Effects()
    {
        if (candies < maxCandies)
        {
         
        for (int i = 0; i < candiesPerSpawn; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(280f, 360f), 10f, Random.Range(340f, 400f));
            Instantiate(candyPrefab, spawnPosition, Quaternion.identity);
        }
        candies += candiesPerSpawn;
        }


    }
}
