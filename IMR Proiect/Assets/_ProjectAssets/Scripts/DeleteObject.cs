using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 15f)
        {
            Destroy(this.gameObject);
        }
    }
}
