using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StegaSoundEffects : MonoBehaviour
{
    //Variables

    AudioSource audioSource;


    //Sound Variants

    public AudioClip[] growlClips;

    public AudioClip[] yelpClips;

    public AudioClip[] barkClips;

    public AudioClip[] roarClips;

    public AudioClip[] deathClips;

    public float delayBetweenSounds = 2.0f;

    private bool isPlaying = false;

    //Gather variables

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Growl Sounds (Random)

    void Update()
    {
        if (audioSource.isPlaying || !audioSource.enabled || isPlaying)
        {
            return;
        }
        int random = Random.Range(1,5);
          StartCoroutine(PlayWithDelay(() =>
        {
            if (random == 1)
            {
                Growl();
               
            }
            else if (random == 2)
            {
                Bark();

            }
            else if (random == 3)
            {
                Roar();
            }
            else if (random == 4)
            {
                Yelp();
            }
        }));
    }

   IEnumerator PlayWithDelay(System.Action soundAction)
    {
        soundAction.Invoke(); 
        isPlaying = true;
        yield return new WaitForSeconds(delayBetweenSounds);
        isPlaying = false;
    }
    public void Growl()
    {
        int Index = Random.Range(0, growlClips.Length);

        AudioClip clip = growlClips[Index];
        audioSource.PlayOneShot(clip);
    }

    //Yelp Sounds (Random)

    public void Yelp()
    {
        int Index = Random.Range(0, yelpClips.Length);

        AudioClip clip = yelpClips[Index];
        audioSource.PlayOneShot(clip);
    }

    //Bark Sounds (Random)

    public void Bark()
    {
        int Index = Random.Range(0, barkClips.Length);

        AudioClip clip = barkClips[Index];
        audioSource.PlayOneShot(clip);
    }

    //Roar Sounds (Random)

    public void Roar()
    {
        int Index = Random.Range(0, roarClips.Length);

        AudioClip clip = roarClips[Index];
        audioSource.PlayOneShot(clip);
    }

    


}
