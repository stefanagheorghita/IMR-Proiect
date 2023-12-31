using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Transform player; 
    public float proximityDistance = 1.5f; 

    public string sceneToLoad;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        Debug.Log("Distance to player: " + distance);
        if (distance < proximityDistance)
        {
            Debug.Log("Player is close to portal");
            LoadScene();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
