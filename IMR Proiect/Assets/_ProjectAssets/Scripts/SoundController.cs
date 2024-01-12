using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class SoundController : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;
    public float delayBetweenLoops = 2.0f; 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;

        //audioSource.loop = true;

        StartCoroutine(PlaySoundLoopWithDelay());
    }

    IEnumerator PlaySoundLoopWithDelay()
    {
        while (true)
        {
            if (audioSource != null && audioSource.enabled)
            {
                audioSource.Play();
            }

    
            yield return new WaitForSeconds(delayBetweenLoops);
        }
    }
}
