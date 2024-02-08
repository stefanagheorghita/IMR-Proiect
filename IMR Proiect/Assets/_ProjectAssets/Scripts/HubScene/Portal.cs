using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Transform player; 
    public float proximityDistance = 1.5f; 

    public string sceneToLoad;

    public GameObject toDestroy;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < proximityDistance)
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if (toDestroy != null)
        {
            Destroy(toDestroy);
        }
        SceneManager.LoadScene(sceneToLoad);

    }
}
