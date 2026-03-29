using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoPausePopUp : MonoBehaviour
{
    public ArduinoReader arduino;

    public float pressureMin = 0.1f;

    public GameObject exitPopUp;
    public float idleTime = 10f;
    private float idleTimer;
    private bool isIdle;

    void Start()
    {
        exitPopUp.SetActive(false);
        isIdle = false;
    }

    void Update()
    {
        if (arduino == null) return;

        float x = (arduino.pressureRight - arduino.pressureLeft) / 1023f;
        float y = (arduino.pressureUp - arduino.pressureDown) / 1023f;
        Vector2 input = new Vector2(x, y);

        if (input.magnitude > pressureMin)
        {
            idleTimer = 0f; // reset timer when active
        }
        else
        {
            idleTimer += Time.deltaTime;
        }

        if (idleTimer >= idleTime && !isIdle)
        {
            ShowPopup();
            isIdle = true;
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        }

        if (arduino.pressureDown > 100 && isIdle)
        {
            SceneManager.LoadScene("HomeScene");
        }

        if (arduino.pressureLeft > 100 && isIdle)
        {
            isIdle = false;
            idleTimer = 0f;

            GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
            HidePopup();
        }
    }

    void ShowPopup()
    {
        exitPopUp.SetActive(true);
    }

    void HidePopup()
    {
        exitPopUp.SetActive(false); 
    }
}