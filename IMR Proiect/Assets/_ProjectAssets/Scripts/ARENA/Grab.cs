using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grab : MonoBehaviour
{
    private XRGrabInteractable interactable;

    private Transform interactorTransform;

    private Transform originalParent;


    private void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnGrab);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        GameManager.Instance.CollectTrophy("trophySurvival");
        Destroy(this.gameObject);
    }
}
