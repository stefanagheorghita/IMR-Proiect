using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;


public class DinosaurPath : MonoBehaviour
{
    private Transform[] waypoints; 
    public float movementSpeed = 3f;
    public int currentWaypoint = 0;


    void Start()
    {
        
        if (this.gameObject.name == "Pachy2")
        {
             GameObject pachy2Wp = GameObject.Find("WaypointsPachy2"); 
            if (pachy2Wp != null)
            {   waypoints = pachy2Wp.GetComponentsInChildren<Transform>()
            .Where(child => child != pachy2Wp.transform) 
            .OrderBy(child => int.Parse(Regex.Match(child.name, @"\d+").Value)) 
            .ToArray();
                
            }
           
          
        }
       // if (this.gameObject.name.StartsWith("Raptor"))
       else
        {
            GameObject raptorWp = GameObject.Find("WaypointsRaptor"); 
            if (raptorWp != null)
            {   waypoints = raptorWp.GetComponentsInChildren<Transform>()
            .Where(child => child != raptorWp.transform) 
            .OrderBy(child => int.Parse(Regex.Match(child.name, @"\d+").Value)) 
            .ToArray();
                
            }
          
        }
        
       
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        if (waypoints.Length > 0)
        {
            MoveTowardsWaypoint();
        }
       AdjustToTerrain();
    }

void MoveTowardsWaypoint()
{
    Vector3 direction = waypoints[currentWaypoint].position - transform.position;
    direction.y = 0f;
    
    if (direction != Vector3.zero)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
        float rotationSpeed = 2.0f; 
       
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
    
    transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 2f)
    {
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
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
