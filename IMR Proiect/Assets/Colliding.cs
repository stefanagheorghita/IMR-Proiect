using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Colliding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] private GameObject _thisHandModel;
    public void OnCollisionEnter(Collision collision)
    {  
        Debug.Log("Colliding");
        if(collision.collider.gameObject.layer != 0)
        {        
            return;
        }
 
        if (collision.collider.transform.GetComponent<XRGrabInteractable>())
            return;
        _thisHandModel.transform.parent = null;
    }
 
    public void OnCollisionExit(Collision collision)
    {  
        if (collision.collider.gameObject.layer != 0)
        {    
            return;
        }
 
       
        _thisHandModel.transform.position = transform.parent.position;
        _thisHandModel.transform.rotation = transform.parent.rotation;
        _thisHandModel.transform.parent = transform.parent;
    }
}
