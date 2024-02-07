using UnityEngine;

public class EggCollector : MonoBehaviour
{
    public float collectionDistance = 5f;
    public KeyCode collectKey = KeyCode.G;
    
    private  int eggCollected = 0;



    public float displayDuration = 3f;
    void Update()
    {
        if (Input.GetKeyDown(collectKey))
        {
            
            Vector3 raycastOrigin = Camera.main.transform.position;
            Vector3 raycastDirection = Camera.main.transform.forward;

            RaycastHit hit;
            if (Physics.Raycast(raycastOrigin, raycastDirection, out hit, collectionDistance))
            {
                if (hit.collider.CompareTag("Egg"))
                {
                    CollectEgg(hit.collider.gameObject);
                }
            }
        }
    }

    void CollectEgg(GameObject egg)
    {   eggCollected++;
        egg.SetActive(false);
        if (eggCollected == 4)
        {
            Debug.Log("You collected all the eggs!");
           
        }
    }
  
}
