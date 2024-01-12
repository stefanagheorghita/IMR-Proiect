using UnityEngine;

public class DinosaurFollow : MonoBehaviour
{
    public Transform target; 
    public float followRange = 3f;
    public float speed = 5f;

    public float minDistance = 2f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

  void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        float rotationSpeed = 2f;
        if (distance < followRange && distance > minDistance)
        {

            Vector3 directionToTarget = target.position - transform.position;
            directionToTarget.y = 0f; 

            Vector3 normalizedDirection = directionToTarget.normalized;

    
            Vector3 targetPosition = target.position - normalizedDirection * minDistance;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(normalizedDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (animator != null)
            {
                animator.Play("Walk");
            }
        }
        else
        {

            if (animator != null)
            {
                animator.Play("Idle");
            }
        }

        AdjustToTerrain();
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
