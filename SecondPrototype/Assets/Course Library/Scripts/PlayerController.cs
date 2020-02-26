using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerProjectile;
    public float horizontalInput;
    public float speed = 10f;
    public float playerXLimit = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        if (transform.position.x <  -playerXLimit)
        {
            transform.position = new Vector3(-playerXLimit, transform.position.y, transform.position.z);
        }

        if (transform.position.x > playerXLimit)
        {
            transform.position = new Vector3(playerXLimit, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerProjectile, transform.position, transform.rotation);
        }
    }
}
