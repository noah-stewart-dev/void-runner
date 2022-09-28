using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : MonoBehaviour
{
    public GameObject pooledObject; // Object to be stored in obstacle pool

    public int pooledAmount; // Number of items in obstacle pool

    private List<GameObject> pooledObjects; // List of pooled objects

    // Start is called before the first frame update
    void Start()
    {
        // Init pooled objects to empty list
        pooledObjects = new List<GameObject>();

        // Init pooled objects list to contain obstacles
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        // Return first obstacle in pool not already active
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // Create new obstacle if all obstacles are active
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        //obj.GetComponent<TestBlockMovement>().SetSpeed(pooledObjects[0].GetComponent<TestBlockMovement>().GetSpeed());
        pooledObjects.Add(obj);

        return obj;
    }

    // Check if all pooled objects are inactive
    public bool AllPooledObjectsInactive()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                return false;
            }
        }

        return true;
    }

    public void SetSpeed(float speed)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            pooledObjects[i].GetComponent<TestBlockMovement>().SetSpeed(speed);
        }
    }
}
