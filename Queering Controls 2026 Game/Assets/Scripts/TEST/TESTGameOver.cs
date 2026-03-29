using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TESTGameOver : MonoBehaviour
{
    public GameObject restartButton;
    public ArduinoReader arduino;
    private bool playerDied;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (arduino != null && arduino.pressureDown > 100 && playerDied == true) // return to homepage
        {
            SceneManager.LoadScene("HomeScene");
        }

        if (arduino != null && arduino.pressureLeft > 100 && playerDied == true) // replay game
        {
            SceneManager.LoadScene("FlappyBirdGameScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            restartButton.SetActive(true);
            playerDied = true;
            GameObject.Find("Main Camera").GetComponent<TESTCamMovement>().enabled = false;
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        }
    }
}
