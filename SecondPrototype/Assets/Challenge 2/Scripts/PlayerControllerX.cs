﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float delta = 0;
    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (delta > 1)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                delta = 0;
            }              
        }
        
    }
}
