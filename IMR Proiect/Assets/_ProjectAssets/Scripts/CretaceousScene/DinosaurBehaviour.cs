using UnityEngine;

public class DinosaurBehaviour : MonoBehaviour {
    public Animator dinosaurAnimator; 
    public string runAnimationTrigger = "Run"; 
    public Transform player; 
    public float detectionRange = 10f; 

    void Update() {
        if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRange) {
            StartRunning();
        } else {
            StopRunning();
        }
    }

    void StartRunning() {
        if (dinosaurAnimator != null) {

            dinosaurAnimator.SetBool("shouldRun", true);
        }
    }

    void StopRunning() {
        if (dinosaurAnimator != null) {
            dinosaurAnimator.SetBool("shouldRun", false);
        }
    }
}
