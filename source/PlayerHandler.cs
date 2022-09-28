using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public int playerHealth;
    public GameObject deathScreen;
    private bool isDead;

    public AudioSource twoHealth;
    public AudioSource oneHealth;
    public AudioSource lowHealth;
    public AudioSource gameOver;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player health is zero
        if (playerHealth <= 0) 
        {
            // Show death screen upon death and pause game
            //deathScreen.SetActive(true);
            //Time.timeScale = 0;
            isDead = true;
        }
    }

    // Detect obstacle collision with player
    private void OnTriggerEnter(Collider other) 
    {
        // Check if the object player is colliding with is an obstacle
        if (other.tag == "Obstacle") 
        {
            other.gameObject.SetActive(false);
            playerHealth--;
            if (playerHealth == 2)
            {
                twoHealth.Play();
            }
            else if (playerHealth == 1)
            {
                oneHealth.Play();
                lowHealth.Play();
            }
            else
            {
                lowHealth.Stop();
                gameOver.Play();
            }
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
