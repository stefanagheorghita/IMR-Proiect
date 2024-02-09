using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SceneTransitionNamespace;
public class ButtonInteraction : MonoBehaviour
{
    public Transform hand;
    public Button[] buttons;
    public float interactionAngleThreshold = 10f; 
    private Dictionary<Button, ColorBlock> originalColors = new Dictionary<Button, ColorBlock>();
    public KeyCode key = KeyCode.Space;
    public SceneTransition sceneTransition;
    

    void Start()
    {
        sceneTransition = GameObject.FindObjectOfType<SceneTransition>();
         foreach (Button button in buttons)
        {
            originalColors.Add(button, button.colors);
        }
    }

    // Update is called once per frame
    

    void Update()
    {
        foreach (Button button in buttons)
        {
            Vector3 buttonDirection = button.transform.position - hand.position;
            float angle = Vector3.Angle(hand.forward, buttonDirection);


            if (angle < interactionAngleThreshold)
            {
                ColorBlock colors = button.colors;
                colors.normalColor = new Color(0f, 0.5f, 0f);;
                button.colors = colors; 
                if (Input.GetKeyDown(key))
            {
                Action(button);
            }

            }
             else
            {
                button.colors = originalColors[button];
            }
        }
    }

    void Action(Button button)
    {
       if (button.name == "Button-Collection")
       {
            
            if (sceneTransition != null) 
            {
                // sceneTransition.ChangeSceneWithFade("Collection");
                SceneManager.LoadScene("Collection");
            }
            else
            {
                print("SceneTransition is null");
            }
       }
         else if (button.name == "Button-Dino")
         {
            if (sceneTransition != null) 
            {
                // sceneTransition.ChangeSceneWithFade("sceneHub");
                SceneManager.LoadScene("sceneHub");

            }
            else
            {
                print("SceneTransition is null");
            }
         }
         else if (button.name == "Button-Menu")
         {
            if (sceneTransition != null) 
            {
                // sceneTransition.ChangeSceneWithFade("MainMenu");
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                print("SceneTransition is null");
            }
         }
        
       
    }
}
