using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ReachedGoal : MonoBehaviour
{
    public GameObject winPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
