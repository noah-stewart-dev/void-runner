using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject deathScreen;
    public GameObject playerBound;
    public AudioSource music;
    public AudioSource threeAudio;
    public AudioSource twoAudio;
    public AudioSource oneAudio;
    public AudioSource goAudio;

    public float pointsPerSecond; // Points given to the player per second
    private float runScore; // Player's total score for the given run
    
    public Text scoreText;

    private int countdownTime;
    public Text threeText;
    public Text twoText;
    public Text oneText;
    public Text goText;

    // Start is called before the first frame update
    void Start()
    {
        countdownTime = 3;

        // Init score to 0
        runScore = 0;
        scoreText.text = "Score: 0";

        // Pause game at start
        Time.timeScale = 0f;

        StartCoroutine(CountDownToStart());

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerHandler>().IsDead() == true)
        {
            music.Stop();
            Time.timeScale = 0f;
            playerBound.gameObject.SetActive(false);
            deathScreen.SetActive(true);
        }

        // Increase score based time of run
        runScore += pointsPerSecond * Time.deltaTime;
        scoreText.text = (Mathf.Round(runScore)).ToString();
    }

    IEnumerator CountDownToStart()
    {
        while (countdownTime > 0)
        {
            if (countdownTime == 3)
            {
                threeText.gameObject.SetActive(true);
                threeAudio.Play();
            } 
            else if (countdownTime == 2)
            {
                threeText.gameObject.SetActive(false);
                twoText.gameObject.SetActive(true);
                twoAudio.Play();
            } 
            else
            {
                twoText.gameObject.SetActive(false);
                oneText.gameObject.SetActive(true);
                oneAudio.Play();
            } 

            yield return new WaitForSecondsRealtime(1f);

            countdownTime--;
        }
        oneText.gameObject.SetActive(false);
        goText.gameObject.SetActive(true);
        goAudio.Play();

        yield return new WaitForSecondsRealtime(1f);

        goText.gameObject.SetActive(false);

        Time.timeScale = 1f;
        music.Play();
    }
}
