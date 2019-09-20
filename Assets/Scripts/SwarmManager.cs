using System;
using UnityEngine;
using System.Collections;

public class SwarmManager : MonoBehaviour {

    // External parameters/variables
    public GameObject enemyTemplate;
    public int enemyRows;
    public int enemyCols;
    public float enemySpacing;
    public float stepSize;
    public float stepTime;
    public float maxXDeviation; // Largest/smallest X-coordinate the edge of the swarm should reach

    // Internal parameters/variables
    private float stepCountdown;
    private bool movingLeft = false;

    // Use this for initialization
    void Start () {
        GenerateSwarm();

        // Initial parameters
        this.stepCountdown = this.stepTime;
        this.transform.localPosition = Vector3.left * maxXDeviation; // Start at far left
	}
	
	// Update is called once per frame
	void Update () {
        this.stepCountdown -= Time.deltaTime;
        if (this.stepCountdown < 0.0f)
        {
            // Perform a single step to move the swarm across (or down)
            // Then reset the timer to periodically perform such steps
            this.StepSwarm();
            this.stepCountdown = this.stepTime;
        }
    }

    // Method to automatically generate swarm of enemies based on the set public attributes
    private void GenerateSwarm()
    {
        // Task 4b ...
        for (int i = 0; i < enemyRows; i++)
        {
            for (int j = 0; j < enemyCols; j++)
            {
                var enemy = Instantiate(enemyTemplate);
                enemy.transform.SetParent(this.transform); // set the enemy as a child of this object
                enemy.transform.position = new Vector3(1.5f*i, 0.0f, 1.5f*j+5f);
            }
        }
    }

    // Method to step a swarm across the screen (or down & reverse when it reaches the edge)
    private void StepSwarm()
    {
        // Task 4c ...
        if (!movingLeft)
        {
            float nextX = this.transform.position.x + stepSize;
            float nextZ = this.transform.position.z;
            if (nextX < stepSize*maxXDeviation)
            {
                this.transform.position = new Vector3(nextX, 0.0f, nextZ);
                movingLeft = false;
            }
            else
            {
                this.transform.position = new Vector3(nextX-stepSize, 0.0f, nextZ-1f);
                movingLeft = true;
            }
        }
        else
        {
            float nextX = this.transform.position.x - stepSize;
            float nextZ = this.transform.position.z;
            if (nextX > -stepSize*maxXDeviation)
            {
                this.transform.position = new Vector3(nextX, 0.0f, nextZ);
                movingLeft = true;
            }
            else
            {
                this.transform.position = new Vector3(nextX + stepSize, 0.0f, nextZ-1f);
                movingLeft = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("destroy this bullet");
        Destroy(other.gameObject);
    }
    
}
