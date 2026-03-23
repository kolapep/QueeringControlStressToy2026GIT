using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformerWinPopUp : MonoBehaviour
{
    public GameObject winPopUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winPopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            winPopUp.SetActive(true);
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        }
    }
}
