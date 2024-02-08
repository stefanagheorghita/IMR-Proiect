using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class AnimateHands : MonoBehaviour
{
    public InputActionProperty pinchAnimation;
    public InputActionProperty gripAnimation;
    public Animator handAnimator;

    void Update()
    {
        float triggerValue = pinchAnimation.action.ReadValue<float>();
        
        handAnimator.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimation.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);

    }
}