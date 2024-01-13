using UnityEngine;

public class DiplodocusController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 2f;
    public float changeTargetInterval = 3f;
    public float maxDistanceFromInitial = 20f; 
    private Vector3 initialPosition;
    private Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position;
        SetNewRandomTarget();
    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
       
            SetNewRandomTarget();
        }
    }

      private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Dinosaur"))
        {
            
            RepositionDinosaur();
        }
    }

    private void RepositionDinosaur()
    {
        SetNewRandomTarget();
        
    }

    void SetNewRandomTarget()
    {
        targetPosition = initialPosition + Random.insideUnitSphere * maxDistanceFromInitial;
        targetPosition.y = initialPosition.y; 
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
