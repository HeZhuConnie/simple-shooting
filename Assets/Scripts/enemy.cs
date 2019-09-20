using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 2;

    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("destroy this bullet");
        if (this.health > 1)
        {
            // shortens the health point by 1
            this.transform.GetComponent<Renderer>().material.color = Color.red;
            health -= 1;
        }
        else
        {
            Instantiate(particle, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }

        Destroy(other.gameObject);
    }
}
