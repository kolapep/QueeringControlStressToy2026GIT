using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ArduinoReader arduino;

    public float speed = 5f;

    void Update()
    {
        if (arduino == null) return;

        float x = (arduino.pressureRight - arduino.pressureLeft) / 1023f;
        float y = (arduino.pressureUp - arduino.pressureDown) / 1023f;

        Vector2 move = new Vector2(x, y);

        transform.Translate(move * speed * Time.deltaTime);
    }
}
