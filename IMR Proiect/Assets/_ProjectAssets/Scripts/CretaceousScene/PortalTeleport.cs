using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform teleportDestination; 
    public float proximityDistance = 2f;

    public Transform teleporting;


    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < proximityDistance)
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        player.position = teleportDestination.position;
        teleporting.position = teleportDestination.position;
        Debug.Log(teleporting.position);
        Debug.Log(player.position); 
    }
}
