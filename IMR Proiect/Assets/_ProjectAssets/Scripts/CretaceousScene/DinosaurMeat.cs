using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class DinosaurMeat : MonoBehaviour
{
public GameObject dinosaurPrefab;
public ParticleSystem explosionParticleSystem;

void Start()
    {
       if (explosionParticleSystem != null)
            explosionParticleSystem.Stop();
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Dinosaur meat collided with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Meat"))
        {
            Debug.Log("Dinosaur meat collided with meat");
            TriggerExplosion(transform.position);
            StartCoroutine(DisableExplosionAfterSeconds(0.5f)); 
            DinosaurDisappear();
        }
    }
    
      IEnumerator DisableExplosionAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (explosionParticleSystem != null)
            explosionParticleSystem.Stop();
    }

    void DinosaurDisappear()
    {
         Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = transform.rotation;

        GameObject newDinosaur = Instantiate(dinosaurPrefab, spawnPosition, spawnRotation);
         newDinosaur.transform.localScale = transform.localScale * 0.5f;

        Destroy(gameObject);
    }

   void TriggerExplosion(Vector3 position)
    {
        if (explosionParticleSystem != null)
        {
            explosionParticleSystem.transform.position = position;
            explosionParticleSystem.Play();
        }
    }



}
