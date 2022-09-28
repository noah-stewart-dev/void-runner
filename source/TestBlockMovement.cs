using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlockMovement : MonoBehaviour
{
    public float moveSpeed; // Set the speed of the moving object

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move obstacle towards player
        transform.Translate(Vector3.forward * Time.deltaTime * -moveSpeed);
    }

    public float GetSpeed()
    {
        return moveSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        this.moveSpeed = newSpeed;
    }
}
