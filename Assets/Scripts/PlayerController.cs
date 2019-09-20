using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 1.0f; // Default speed sensitivity
    // public Rigidbody rg;
    
    public GameObject projectileTemplate;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
	        var projectile = Instantiate(projectileTemplate, this.transform.position, this.transform.rotation);
	        // projectile.transform.position = this.transform.position;
	        projectile.GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
	        
        }
	}
	
}
