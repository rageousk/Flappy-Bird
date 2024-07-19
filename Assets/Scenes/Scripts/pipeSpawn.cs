using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipe;
    public GameObject piranhaPipe; // Regular Piranha Pipe (Bottom)
    public GameObject topPiranhaPipe; // New Top Piranha Pipe

    public float spawnRate = 3;
    private float timer = 0;
    public float heightOffset = 10;
    private int pipeCount = 0; // Track the number of spawned pipes
    private int minPipesBeforePiranha = 2; // Minimum regular pipes before PiranhaPipe
    private int maxPipesBeforePiranha = 5; // Maximum regular pipes before PiranhaPipe

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (pipeCount % 3 == 0) // Spawn Top Piranha Pipe after every 3 normal pipes
            {
                //spawnTopPiranhaPipe();
                spawnPiranhaPipe();
            }
            else
            {
                // Choose spawn type based on probability and pipe count
                bool spawnPiranha = decideSpawnType();

                if (spawnPiranha)
                {
                    spawnTopPiranhaPipe();
                    // spawnPiranhaPipe();
                }
                else
                {
                    spawnPipe();
                }
            }

            pipeCount++;
            timer = 0;
        }
    }

    bool decideSpawnType()
    {
        int randomValue = Random.Range(1, 101); // Range from 1 to 100 (inclusive)

        // Adjust these probabilities as needed
        int piranhaSpawnProbability = 20; // 20% chance of spawning regular PiranhaPipe

        if (pipeCount >= minPipesBeforePiranha && randomValue <= piranhaSpawnProbability)
        {
            return true; // Spawn regular PiranhaPipe
        }
        else if (pipeCount >= maxPipesBeforePiranha) // Force spawn of regular pipe after exceeding max limit
        {
            pipeCount = 0; // Reset pipe count to allow for PiranhaPipe chance again
            return false; // Spawn regular pipe
        }
        else
        {
            return false; // Spawn regular pipe (default)
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Ensure pipes don't spawn on top of each other (optional)
        Vector3 newPosition = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
        while (Physics.Raycast(newPosition, Vector3.up, 1f)) // Check for overlapping colliders within 1 unit above
        {
            newPosition.y = Random.Range(lowestPoint, highestPoint); // Re-randomize position if overlap detected
        }

        Instantiate(pipe, newPosition, transform.rotation);
    }

    void spawnPiranhaPipe()
    {
        // Choose a specific Y position for PiranhaPipe (adjust as needed)
        float piranhaY = transform.position.y; // Spawn at the same height as regular pipes (optional)
                                               // float piranhaY = someOtherHeight; // Spawn at a different height
        Instantiate(piranhaPipe, new Vector3(transform.position.x, piranhaY, 0), transform.rotation);
    }

    void spawnTopPiranhaPipe()
    {
        // Define the offset for Top Piranha Pipe position
        float topPiranhaOffset = 5f; // Adjust this value to control the distance above regular pipes

        // Calculate Y position for Top Piranha Pipe
        float topPiranhaY = transform.position.y + topPiranhaOffset;

        Instantiate(topPiranhaPipe, new Vector3(transform.position.x, topPiranhaY, 0), transform.rotation);
    }
}







/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipe;
    public GameObject piranhaPipe;
    public float spawnRate = 3;
    private float timer = 0;
    public float heightOffset = 10;
    private int pipeCount = 0; // Track the number of spawned pipes
    private int minPipesBeforePiranha = 2;  // Minimum regular pipes before PiranhaPipe
    private int maxPipesBeforePiranha = 5;  // Maximum regular pipes before PiranhaPipe

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            int randomPiranhaThreshold = Random.Range(minPipesBeforePiranha, maxPipesBeforePiranha + 1);
            if (pipeCount >= randomPiranhaThreshold) // Spawn PiranhaPipe if threshold reached
            {
                spawnPiranhaPipe();
                pipeCount = 0; // Reset pipe count
            }
            else // Spawn regular pipe
            {
                spawnPipe();
                pipeCount++;
            }
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Ensure pipes don't spawn on top of each other (optional)
        Vector3 newPosition = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
        while (Physics.Raycast(newPosition, Vector3.up, 1f)) // Check for overlapping colliders within 1 unit above
        {
            newPosition.y = Random.Range(lowestPoint, highestPoint); // Re-randomize position if overlap detected
        }

        Instantiate(pipe, newPosition, transform.rotation);
    }

    void spawnPiranhaPipe()
        {
            // Choose a specific Y position for PiranhaPipe (adjust as needed)
            float piranhaY = transform.position.y; // Spawn at the same height as regular pipes (optional)
                                                   // float piranhaY = someOtherHeight; // Spawn at a different height
            Instantiate(piranhaPipe, new Vector3(transform.position.x, piranhaY, 0), transform.rotation);
        }
} */