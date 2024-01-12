using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitialDinosaur : MonoBehaviour
{
    public string initialDinosaur;
    // Start is called before the first frame update
    void Start()
    {
        InstructionsManager.Instance.ChangeDinosaur(initialDinosaur);
        
    }

 
}
