using UnityEngine;

public class ProximityCheck : MonoBehaviour
{
    public float proximityRadius = 2f; 
    public LayerMask dinosaurLayer;   

    public int startingLives = 3;
    public int currentLives = 3;

    public Transform initialPosition;

    public Transform teleporting;

    private void Update()
    {
        CheckForDinosaurs();
    }

    private void CheckForDinosaurs()
    {
        Collider[] nearbyDinosaurs = Physics.OverlapSphere(transform.position, proximityRadius, dinosaurLayer);

        if (nearbyDinosaurs.Length > 0)
        {
            
            HandleProximityWithDinosaur();
        }
    }

    private void HandleProximityWithDinosaur()
    {
        
        currentLives--;

       
        if (currentLives <= 0)
        {
           
            RespawnPlayer();
        }
        else
        {
            
            Debug.Log("Player lost a life. Remaining lives: " + currentLives);
        }
}
void RespawnPlayer()
{
   
   transform.position = GetRespawnPosition();
   teleporting.position = GetRespawnPosition();


    currentLives = startingLives;

  
}

Vector3 GetRespawnPosition()
{
    
    Vector3 respawnPosition = initialPosition.position;

   return respawnPosition;
}
}
