using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    public Transform head; // Track player's head position
    public Transform feet; // Track player's feet position

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update player collider position
        gameObject.transform.position = new Vector3(head.position.x, feet.position.y, head.position.z);
    }
}
