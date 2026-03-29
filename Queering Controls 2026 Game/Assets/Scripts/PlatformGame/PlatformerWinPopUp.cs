using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlatformerWinPopUp : MonoBehaviour
{
    public GameObject winPopUp;
    private bool playerWin;
    public ArduinoReader arduino;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winPopUp.SetActive(false);
        playerWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (arduino != null && arduino.pressureDown > 100 && playerWin == true) // return to homepage
        {
            SceneManager.LoadScene("HomeScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            winPopUp.SetActive(true);
            playerWin = true;
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        }
    }
}
