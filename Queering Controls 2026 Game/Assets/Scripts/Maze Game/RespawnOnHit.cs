using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnOnHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Maze_Wall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (col.gameObject.CompareTag("End_Wall"))
        {
            SceneManager.LoadScene("Maze Game Scene");
        }
    }
}
