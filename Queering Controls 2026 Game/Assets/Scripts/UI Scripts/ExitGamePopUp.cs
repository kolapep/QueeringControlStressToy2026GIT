using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGamePopUp : MonoBehaviour
{
    public ArduinoReader arduino;

    public float pressureMin = 0.1f; //Min amount of pressure needed

    public GameObject exitPopUp;
    private bool inputLocked = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exitPopUp.SetActive(false);
        inputLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (arduino == null) return;

        float x = (arduino.pressureRight - arduino.pressureLeft) / 1023f;
        float y = (arduino.pressureUp - arduino.pressureDown) / 1023f;

        // Detect activity
        if (y > pressureMin)
        {
            inputLocked = true;
            HidePopup();
        }
        else if (y < pressureMin)
        {
            if (inputLocked == false)
            {
                SceneManager.LoadScene("Home Scene");
            }
            else
            {
                ShowPopup();
                inputLocked = false;
            }
               
        }

    }
    void ShowPopup()
    {
        if (!exitPopUp.activeSelf)
        {
            exitPopUp.SetActive(true);
        }
    }
    void HidePopup()
    {
        if (!exitPopUp.activeSelf)
        {
            exitPopUp.SetActive(true);
        }
    }
}
