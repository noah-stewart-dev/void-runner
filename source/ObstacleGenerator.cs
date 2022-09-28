using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject grid; // Grid platforms are generated onto
    public GameObject sun; // Sun in the background
    private bool notInPulse;

    public GameObject theObstacle; // Not sure if we'll need this. Keep it for now
    public Transform generationPoint; // Point where obstacles should be created if generator moves passed
    public float distanceBetween; // Not sure if we'll need this. Keep it for now

    private float obstacleWidth;

    //public GameObject[] thePlatforms; // Not sure if we'll need this. keep it for now
    private int obstacleSelector; // Random int to select an obstacle type
    private float[] obstacleWidths; // Widths of each obstacle

    public ObstaclePooler[] theObstaclePools; // Array of obstacle pools

    private int doubleSelector; // Random int to decide if obstacle should be two or one wide

    public int generatedThreshold; // How many platforms should be generated before game speeds up
    private int generatedCount; // Count number of platforms generated
    private bool continueGeneration; // Check if obstacles should continue to be generated
    private int currentDifficulty; // 0 easy, 1 medium, 2 hard


    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        continueGeneration = true;
        generatedCount = 0;
        currentDifficulty = 0;
        notInPulse = true;

        sun.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.yellow * 10);

        // Init obstacleWidths array
        obstacleWidths = new float[theObstaclePools.Length];

        // Fill obstacleWidths with the width of each obstacle
        for (int i = 0; i < theObstaclePools.Length; i++)
        {
            obstacleWidths[i] = theObstaclePools[i].pooledObject.GetComponent<BoxCollider>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Stop platform generation
        if (generatedCount >= generatedThreshold && continueGeneration == true)
        {
            Debug.Log("STOP");
            continueGeneration = false;
        }

        // Check if obstacle generator has moved passed the generation point
        if (transform.position.z < generationPoint.position.z && continueGeneration == true)
        {
            generatedCount++;

            // Set double selector and obstacle selector to random ints
            doubleSelector = Random.Range(0, 1000);
            // Remove - 1 to add back in jump obstacles
            obstacleSelector = Random.Range(0, theObstaclePools.Length - 1);

            // Create instance of pooled object
            GameObject newPlatform = theObstaclePools[obstacleSelector].GetPooledObject();

            // Move obstacle generator behind obstacle generation point
            transform.position = new Vector3(newPlatform.transform.position.x, newPlatform.transform.position.y, transform.position.z + obstacleWidths[obstacleSelector] + distanceBetween);

            // This is where the statement outside of the if statement was before.
            //GameObject newPlatform = theObstaclePools[platformSelector].GetPooledObject();

            // Position obstacle
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = newPlatform.transform.rotation;
            newPlatform.SetActive(true);

            // Create second obstacle randomly
            if (doubleSelector < 500)
            {
                // Create another instance of pooled object to place alongside the first
                GameObject newPlatform2 = theObstaclePools[Random.Range(0, theObstaclePools.Length)].GetPooledObject();

                // Position obstacle if not an obstacle that would cause double collision
                if ((!newPlatform.name.Contains("Jump(Clone)") && !newPlatform2.name.Contains("Duck(Clone)")) || (!newPlatform.name.Contains("Duck(Clone)") && !newPlatform2.name.Contains("Jump(Clone)"))) 
                {
                    newPlatform2.transform.position = new Vector3(newPlatform2.transform.position.x, newPlatform2.transform.position.y, transform.position.z);
                    newPlatform2.transform.rotation = newPlatform2.transform.rotation;
                    newPlatform2.SetActive(true);
                }
            }
        }

        // Move obstacle generator if it is behind the generation point
        if (transform.position.z >= generationPoint.position.z)
        {
            transform.position = new Vector3(-1, 2, transform.position.z - (theObstaclePools[obstacleSelector].GetPooledObject().GetComponent<TestBlockMovement>().GetSpeed()) * Time.deltaTime);
        }
        
        // Set higher speed
        if (continueGeneration == false && AllObstaclesInactive() && notInPulse == true)
        {
            currentDifficulty++;

            // Change sun color based on difficulty
            if (currentDifficulty == 1)
            {
                notInPulse = false;
                StartCoroutine(SunPulse(currentDifficulty));
            } 
            else if (currentDifficulty == 2)
            {
                notInPulse = false;
                StartCoroutine(SunPulse(currentDifficulty));
            }

            // Set new grid speed
            //grid.GetComponent<Renderer>().material.SetFloat("_ScrollSpeed", theObstaclePools[0].GetPooledObject().GetComponent<TestBlockMovement>().GetSpeed() + 1);

            // Set new speed for all obstacles
            //SetAllObstaclesSpeed(theObstaclePools[0].GetPooledObject().GetComponent<TestBlockMovement>().GetSpeed() + 1);

            // Continue generation
            generatedCount = 0;
            if (currentDifficulty > 2)
            {
                continueGeneration = true;
            }

        }

    }

    // Check if all platforms in all the obstacle pools are inactive
    public bool AllObstaclesInactive()
    {
        for (int i = 0; i < theObstaclePools.Length; i++)
        {
            if (!theObstaclePools[i].AllPooledObjectsInactive())
            {
                return false;
            }
        }

        return true;
    }

    public void SetAllObstaclesSpeed(float speed)
    {
        for (int i = 0; i < theObstaclePools.Length; i++)
        {
            theObstaclePools[i].SetSpeed(speed);
        }
    }


    IEnumerator SunPulse(int difficulty)
    {
        if (difficulty == 1)
        {
            grid.GetComponent<Renderer>().material.SetFloat("_ScrollSpeed", 0);
            sun.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.blue * 10);
            yield return new WaitForSeconds(1f);
            sun.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.yellow * 10);
            yield return new WaitForSeconds(1f);
            sun.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.blue * 10);
            SetAllObstaclesSpeed(theObstaclePools[0].GetPooledObject().GetComponent<TestBlockMovement>().GetSpeed() + 1);
            grid.GetComponent<Renderer>().material.SetFloat("_ScrollSpeed", theObstaclePools[0].GetPooledObject().GetComponent<TestBlockMovement>().GetSpeed());
            continueGeneration = true;
            notInPulse = true;

        }
        else if (difficulty == 2)
        {
            grid.GetComponent<Renderer>().material.SetFloat("_ScrollSpeed", 0);
            sun.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red * 10);
            yield return new WaitForSeconds(1f);
            sun.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.blue * 10);
            yield return new WaitForSeconds(1f);
            sun.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red * 10);
            SetAllObstaclesSpeed(theObstaclePools[0].GetPooledObject().GetComponent<TestBlockMovement>().GetSpeed() + 1);
            grid.GetComponent<Renderer>().material.SetFloat("_ScrollSpeed", theObstaclePools[0].GetPooledObject().GetComponent<TestBlockMovement>().GetSpeed());
            continueGeneration = true;
            notInPulse = true;

        }
    }
}
