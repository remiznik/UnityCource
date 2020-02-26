using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float bottomZLimit;
    public float topZLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topZLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < bottomZLimit)
        {
            Destroy(gameObject);
        }
    }
}
