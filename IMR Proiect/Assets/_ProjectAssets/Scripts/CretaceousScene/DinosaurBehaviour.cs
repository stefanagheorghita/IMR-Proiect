using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;
public class DinosaurBehaviour : MonoBehaviour {
    public Animator dinosaurAnimator; 
    public string runAnimationTrigger = "Run"; 
    public Transform player; 
    public float detectionRange = 5f; 

    void Start() {
        AdjustToTerrain(); 
    
    }

    void Update() {
        if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRange) {
            AdjustToTerrain(); 
            StartRunning(); 
                     
           
           
        } else {
            StopRunning();
        }
    }

    void StartRunning() {
        if (dinosaurAnimator != null) {

            dinosaurAnimator.SetBool("shouldRun", true);
        }
    }

    void StopRunning() {
        if (dinosaurAnimator != null) {
            dinosaurAnimator.SetBool("shouldRun", false);
        }
    }
    void AdjustToTerrain()
    {
    
    Terrain terrain = Terrain.activeTerrain;

        if (terrain != null)
        {
            float terrainHeight = terrain.SampleHeight(transform.position);
            transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }


    }
}
