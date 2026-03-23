using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadJourney : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJourney()
    {
        SceneManager.LoadScene("FlappyBirdGameScene");
    }
}
