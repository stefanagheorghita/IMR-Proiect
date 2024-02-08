using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollide : MonoBehaviour
{
    private int number = 0; 
    private List<GameObject> collidedApples = new List<GameObject>();

    public GameObject[] gameObjects;
    public float displayDuration = 5f;

    void Start()
    {
       
    }

    // void HideCanvas()
    // {
    //     canvasToDisplay.enabled = false;
    //     canvasToDisplay.gameObject.SetActive(false);
    // }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Apple"))
        {
            if (!collidedApples.Contains(collision.gameObject))
            {
                collidedApples.Add(collision.gameObject);

                Debug.Log("You have collected an apple!");
                number++;

                if (number % 3 == 0)
                {
                    activateObjects();
                }
            }
        }
    }

    void activateObjects()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }

        DinosaurCollectedManager.Instance.ShowInstructionsForDuration(InstructionsManager.Instance.GetCurrentDinosaur(), 5f);
        GameManager.Instance.CollectDinosaur(InstructionsManager.Instance.GetCurrentDinosaur());
        InstructionsManager.Instance.ChangeDinosaur("raptor");
    }
}
