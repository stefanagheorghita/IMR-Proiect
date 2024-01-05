using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AdjustObjectPosition : MonoBehaviour
{
    private XRGrabInteractable interactable;

    private Transform interactorTransform;

    private Transform originalParent;

    private  bool isHeld = false;

    private void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
        isHeld = false;
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        if (!isHeld){
            originalParent = transform.parent;
            interactorTransform = args.interactorObject.transform;
            transform.parent = interactorTransform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        else {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = true;
            transform.parent = originalParent;
            isHeld = false;
        }

    }

    void OnRelease(SelectExitEventArgs args)
    {
        if (!isHeld){        
         Rigidbody rb = GetComponent<Rigidbody>();
         rb.useGravity = false;
         transform.parent = interactorTransform;
         isHeld = true;
        }
        else
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = true;
            transform.parent = originalParent;
            isHeld = false;
        }
    }

    void Update()
    {
        if (isHeld)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.useGravity = true;
                transform.parent = originalParent;
                isHeld = false;
            }
        }
    }
}
