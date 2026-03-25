using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneSwitchControl : MonoBehaviour
{
    public ArduinoReader arduino;

    //Replace with Scene names
    public string topLeftScene;
    public string topRightScene;
    public string bottomLeftScene;

    public float pressureMin; //Min amount of pressure needed
    private bool inputLocked = false;

    void Update()
    {
        if (arduino == null || inputLocked) return;

        float x = (arduino.pressureRight - arduino.pressureLeft) / 1023f;
        float y = (arduino.pressureUp - arduino.pressureDown) / 1023f;

        if (x > pressureMin)
        {
            LoadScene(topLeftScene);
        }
        else if (x < pressureMin)
        {
            LoadScene(bottomLeftScene);
            Debug.Log("bottom left");
        }
        else if (y > pressureMin)
        {
            LoadScene(topRightScene);
        }
        
    }
    void LoadScene(string sceneName)
    {
        inputLocked = true; // stop multiple triggers
        SceneManager.LoadScene(sceneName);
    }
}

