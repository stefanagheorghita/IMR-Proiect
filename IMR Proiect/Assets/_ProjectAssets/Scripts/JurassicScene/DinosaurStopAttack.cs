using UnityEngine;
using System.Collections;

public class DinosaurStopAttack : MonoBehaviour
{
    public GameObject[] targets; 
    public float followRange = 3f;

    public GameObject dinoPrefab;
   

    private Animator animator;

    public GameObject dino;

    public GameObject effect;

    public float explosionForce = 10f;

    public float effectDuration = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

  void Update()
    {
        if (targets.Length != 0)
        {
            float distance = Vector3.Distance(transform.position, dino.transform.position);

            Vector3[] locations = new Vector3[targets.Length];

            if (distance < followRange)
            {
                for (int i=0;i<targets.Length;i++)
                {
                    locations[i] = targets[i].transform.position;
                    Destroy(targets[i]);
                }
                Rigidbody[] newdinos = new Rigidbody[targets.Length * 3];
                int k = 0;
                for (int i=0;i<targets.Length;i++)
                {
                    GameObject newEffect = Instantiate(effect, locations[i], Quaternion.identity);
                    Destroy(newEffect, effectDuration);
                    Rigidbody rd = SpawnWithForce(dinoPrefab, locations[i], Quaternion.identity);
                    newdinos[k++] = rd;

                    newEffect = Instantiate(effect, locations[i] - new Vector3(4f, 0f, 0f), Quaternion.identity);
                    Destroy(newEffect, effectDuration);
                    rd = SpawnWithForce(dinoPrefab, locations[i] - new Vector3(4f, 0f, 0f), Quaternion.identity);
                    newdinos[k++] = rd;

                    newEffect = Instantiate(effect, locations[i] + new Vector3(4f, 0f, 0f), Quaternion.identity);
                    Destroy(newEffect, effectDuration);
                    rd = SpawnWithForce(dinoPrefab, locations[i] + new Vector3(4f, 0f, 0f), Quaternion.identity);
                    newdinos[k++] = rd;
                                   
                }
                targets = new GameObject[0];
                DinosaurCollectedManager.Instance.ShowInstructionsForDuration(InstructionsManager.Instance.GetCurrentDinosaur(), 5f);
                GameManager.Instance.CollectDinosaur(InstructionsManager.Instance.GetCurrentDinosaur());
                InstructionsManager.Instance.ChangeDinosaur("diplodocus");
                ReactivateKinematicAfterDelay(newdinos,k, 1.5f); 
            }
        }
        
    }
      private Rigidbody SpawnWithForce(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject newObject = Instantiate(prefab, position, rotation);
        Animator animator = newObject.GetComponent<Animator>(); 
        if (animator != null)
        {
            animator.enabled = false;
        }
        Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();

        
        rigidbody.isKinematic = false;

        
        rigidbody.mass = 1f;

        Vector3 explosionForceVector = Random.onUnitSphere * explosionForce;

    
        float power = 1000f; 
        float radius = 1000f; 
        rigidbody.AddExplosionForce(power, position, radius, 500.0F);


       
        if (animator != null)
        {
            animator.enabled = true;
        }
        return rigidbody;
       
    }

      void ReactivateKinematicAfterDelay(Rigidbody[] rigidbody, int k, float delay)
    {
       
        for (int i=0;i<k;i++)
        {
            rigidbody[i].isKinematic = true;
            rigidbody[i].velocity = Vector3.zero;
            rigidbody[i].angularVelocity = Vector3.zero;
            
            rigidbody[i].mass = 300f;
            rigidbody[i].useGravity = true;;
            float terrainHeight = Terrain.activeTerrain.SampleHeight(rigidbody[i].position);
            
            Quaternion newRotation = Quaternion.Euler(0f, 0f, 0f);
            rigidbody[i].MovePosition(new Vector3(rigidbody[i].position.x, terrainHeight, rigidbody[i].position.z));
            rigidbody[i].MoveRotation(newRotation);

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
