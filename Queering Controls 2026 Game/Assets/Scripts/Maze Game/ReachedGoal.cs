using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class ReachedGoal : MonoBehaviour
{
    public GameObject winPanel;
    public ArduinoReader arduino;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (arduino != null && arduino.pressureDown > 100 && GameObject.Find("Player").GetComponent<PlayerController>().enabled == false) 
        {
            SceneManager.LoadScene("HomeScene");
            Debug.Log("pressed");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        }
    }
}
