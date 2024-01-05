using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class DinosaurAudio : MonoBehaviour
{
    public Transform player;
    public AudioSource[] audioSources; 
    private int currentClipIndex = 0;
    public float maxDistance = 2f;

    void Update()
    {
       
        float distance = Vector3.Distance(transform.position, player.position);
        Vector3 directionToDinosaur = (transform.position - player.position).normalized;
        Vector3 playerForward = player.forward;
        if (currentClipIndex >= audioSources.Length)
        {
            currentClipIndex = 0;
        }
        float dotProduct = Vector3.Dot(playerForward, directionToDinosaur);
        if (distance <= maxDistance && dotProduct > 0.5f)
        {
            Debug.Log("Player is close to dinosaur");
            if (!audioSources[currentClipIndex].isPlaying)
        {
            PlayNextClip();
        }
        }
        else
        {
    
            if (audioSources[0].isPlaying)
            {
                audioSources[0].Stop();
            }
            if (audioSources[1].isPlaying)
            {
                audioSources[1].Stop();
            }
        }
    }
      void PlayNextClip()
    {
        if (currentClipIndex < audioSources.Length)
        {
            audioSources[currentClipIndex].Play();
            currentClipIndex++;
        }
        else
        {
            currentClipIndex = 0;
        }
    }
}
