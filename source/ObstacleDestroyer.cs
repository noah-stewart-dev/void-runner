using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public GameObject obstacleDestructionPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Assign destruction point
        obstacleDestructionPoint = GameObject.Find("ObstacleDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if obstacle with attatched script has moved passed the destruction point
        if (transform.position.z < obstacleDestructionPoint.transform.position.z)
        {
            // Set game object to be inactive
            gameObject.SetActive(false);
        }
    }
}
