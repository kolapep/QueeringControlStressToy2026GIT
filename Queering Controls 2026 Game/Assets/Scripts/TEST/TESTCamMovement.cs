using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TESTCamMovement : MonoBehaviour
{
//     public float speed = 1f;
//     private float endPos = 50f;
//     public GameObject replayButton;

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         Camera.main.transform.position = new Vector3(speed + transform.position.x, transform.position.y, transform.position.z);

//         if (Camera.main.transform.position.x >= endPos)
//         {
//             speed = 0;
//             replayButton.SetActive(true);
//         }
//     }
// }
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;
    public GameObject replayButton;

    private bool reachedEnd = false;

    void Start()
    {
        transform.position = pointA.position;
    }

    void Update()
    {
        if (reachedEnd) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            pointB.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, pointB.position) < 0.01f)
        {
            reachedEnd = true;

            if (replayButton != null)
                replayButton.SetActive(true);
        }
    }
}
