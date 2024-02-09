using UnityEngine;

public class DinosaurView : MonoBehaviour
{
    private bool collected = false;
    private Renderer dinosaurRenderer;
    public Material material;
    private Color colore;

    void Start()
    {
    
        collected = GameManager.Instance.IsDinosaurCollected(gameObject.name);
        SetMaterialProperties();
    }

    void SetMaterialProperties()
    {

        if (collected)
        {
            Debug.Log("Dinosaur collected: " + gameObject.name);    
            
           
        }
        else
        {   
            Debug.Log("Dinosaur not collected: " + gameObject.name);
            Animator animator = GetComponent<Animator>();
            animator.enabled = false;
            gameObject.SetActive(false);
        }
           
        
    }

}

