using UnityEngine;
using UnityEngine.SceneManagement;


public class AutoPausePopUp : MonoBehaviour
{
    public ArduinoReader arduino;

    public float pressureMin = 0.1f; //Min amount of pressure needed

    public GameObject exitPopUp;
    public float idleTime = 20f;
    private float idleTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exitPopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (arduino == null) return;

        float x = (arduino.pressureRight - arduino.pressureLeft) / 1023f;
        float y = (arduino.pressureUp - arduino.pressureDown) / 1023f;
        Vector2 input = new Vector2(x, y);

        // Detect activity
        if (input.magnitude > pressureMin)
        {
            idleTimer = 0f;

            // Hide popup if player becomes active again
            HidePopup();
        }
        else
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleTime)
            {
                ShowPopup();
                if (idleTimer >= idleTime + 5f)
                    SceneManager.LoadScene("Home Scene");

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
