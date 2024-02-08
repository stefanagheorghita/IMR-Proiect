using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject trophy;
    public GameObject torches;

    public GameObject player;

    public float distance = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(Vector3.Distance(player.transform.position, this.transform.position));
        if (Vector3.Distance(player.transform.position, this.transform.position) < distance)
        {
            this.gameObject.SetActive(false);
            torches.SetActive(true);
            trophy.SetActive(true);
        }
        
    }
}
