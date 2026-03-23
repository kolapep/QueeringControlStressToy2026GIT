using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TESTCamMovement : MonoBehaviour
{
    public float speed = 1f;
    private float endPos = 50f;
    public GameObject replayButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(speed + transform.position.x, transform.position.y, transform.position.z);

        if (Camera.main.transform.position.x >= endPos)
        {
            speed = 0;
            replayButton.SetActive(true);
        }
    }
}
