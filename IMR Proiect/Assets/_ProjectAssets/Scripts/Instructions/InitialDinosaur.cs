using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitialDinosaur : MonoBehaviour
{
    public string[] initialDinosaur;
    // Start is called before the first frame update
    void Start()
    {
        bool collected = GameManager.Instance.IsDinosaurCollected(initialDinosaur[0]);
        if (collected)
        {
            if (initialDinosaur.Length > 1)
            {
                collected = GameManager.Instance.IsDinosaurCollected(initialDinosaur[1]);
                if (collected)
                {   
                    if (initialDinosaur.Length > 2)
                    {
                        collected = GameManager.Instance.IsDinosaurCollected(initialDinosaur[2]);
                        if (collected)
                        {
                            InstructionsManager.Instance.ChangeDinosaur("aaa");
                        }
                        else
                        {
                            InstructionsManager.Instance.ChangeDinosaur(initialDinosaur[2]);
                        }
                    }
                    else
                    {
                        InstructionsManager.Instance.ChangeDinosaur("aaa");
                    }
                }
                else
                {
                    InstructionsManager.Instance.ChangeDinosaur(initialDinosaur[1]);
                }
            }
            else
            {
                InstructionsManager.Instance.ChangeDinosaur("aaa");
            }
        }
        else
        {
            InstructionsManager.Instance.ChangeDinosaur(initialDinosaur[0]);
        }

    }

 
}
