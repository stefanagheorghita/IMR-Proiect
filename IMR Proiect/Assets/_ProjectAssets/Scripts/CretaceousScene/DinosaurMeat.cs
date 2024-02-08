using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class DinosaurMeat : MonoBehaviour
{
    public static int dinosaurCount = 0;
    public GameObject dinosaurPrefab;
    public ParticleSystem explosionParticleSystem;

    void Start()
        {
        if (explosionParticleSystem != null)
                explosionParticleSystem.Stop();
        }
    void Update()
        {
            if (dinosaurCount == 3)
            {
                Debug.Log("You have collected 3 dinosaurs!");
                DinosaurCollectedManager.Instance.ShowInstructionsForDuration(InstructionsManager.Instance.GetCurrentDinosaur(), 5f);
                GameManager.Instance.CollectDinosaur(InstructionsManager.Instance.GetCurrentDinosaur());
            }
        }

    static void CollectDinosaur(string dinosaur)
        {
            InstructionsManager.Instance.ChangeDinosaur("aaaa");

        }
    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Meat"))
            {
                TriggerExplosion(transform.position);
                StartCoroutine(DisableExplosionAfterSeconds(0.5f)); 
                dinosaurCount++;
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
