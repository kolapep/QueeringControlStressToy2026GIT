using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothPosition;
    }
}
