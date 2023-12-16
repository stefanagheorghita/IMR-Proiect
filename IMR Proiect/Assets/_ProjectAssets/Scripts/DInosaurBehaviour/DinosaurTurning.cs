using UnityEngine;

public class DinosaurTurning : MonoBehaviour
{
    Rigidbody rb; 
    bool isColliding = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (isColliding)
        {
            Debug.Log("isColliding");
            Debug.Log(transform.position);
            Quaternion targetRotation = Quaternion.LookRotation(rb.velocity.normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 100f);

            Debug.Log(transform.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (!collision.gameObject.CompareTag("Terrain"))
        {
            Debug.Log("Collision Enter");
            Debug.Log(transform.position);
            isColliding = true;
            rb.AddForce(transform.forward * 5f, ForceMode.Impulse);
            Debug.Log("lala");
            Debug.Log(transform.position);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit");
        if (!collision.gameObject.CompareTag("Terrain"))
        {
            isColliding = false;
        }
    }
}
