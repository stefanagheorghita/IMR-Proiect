using UnityEngine;

public class DinosaurStopAttack : MonoBehaviour
{
    public GameObject[] targets; 
    public float followRange = 3f;

    public GameObject dinoPrefab;
   

    private Animator animator;

    public GameObject dino;

    public GameObject effect;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

  void Update()
    {
        if (targets.Length != 0)
        {
            float distance = Vector3.Distance(transform.position, dino.transform.position);
            Debug.Log("Distance: " + distance);
            Vector3[] locations = new Vector3[targets.Length];
            if (distance < followRange)
            {
                for (int i=0;i<targets.Length;i++)
                {
                    locations[i] = targets[i].transform.position;
                    Destroy(targets[i]);
                }
                
                for (int i=0;i<targets.Length;i++)
                {
                    GameObject newDinoLeft = Instantiate(dinoPrefab, locations[i] - new Vector3(4f, 0f, 0f), Quaternion.identity);
                    int random = Random.Range(0, 15);
                    float scale = 0.1f * random;
                    newDinoLeft.transform.localScale = dino.transform.localScale * scale;

                    GameObject newDinoRight = Instantiate(dinoPrefab, locations[i] + new Vector3(4f, 0f, 0f), Quaternion.identity);
                    random = Random.Range(0, 15);
                    scale = 0.1f * random;
                    newDinoRight.transform.localScale = dino.transform.localScale * scale;
                    random = Random.Range(0, 15);
                    scale = 0.1f * random;
                    GameObject newDino = Instantiate(dinoPrefab, locations[i], Quaternion.identity);
                    newDino.transform.localScale = dino.transform.localScale * scale;

                    GameObject newEffect = Instantiate(effect, locations[i], Quaternion.identity);
                    GameObject newEffect2 = Instantiate(effect, locations[i] - new Vector3(4f, 0f, 0f), Quaternion.identity);
                    GameObject newEffect3 = Instantiate(effect, locations[i] + new Vector3(4f, 0f, 0f), Quaternion.identity);
                }
                targets = new GameObject[0];
                DinosaurCollectedManager.Instance.ShowInstructionsForDuration(InstructionsManager.Instance.GetCurrentDinosaur(), 5f);
                InstructionsManager.Instance.ChangeDinosaur("diplodocus");
            }
        }
        
       

    }


}
