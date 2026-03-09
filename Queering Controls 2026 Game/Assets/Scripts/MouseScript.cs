using Unity.VisualScripting;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public Transform player;

    public float runDistance = 4f;
    public float stopDistance = 10f;
    public float catchDistance = 1f;
    public float respawnDistance = 6f;
    public float mouseSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position); //Update distance from the player

        //Detect player
        if (distance > runDistance)
        {
            if (distance < stopDistance)
            {
                RunFromPlayer();
            }
        }

        // Player Catches Mouse
        if (distance < catchDistance)
        {
            Respawn();
        }
    }

    void RunFromPlayer()
    {
        Vector3 direction = (transform.position - player.position).normalized;
        transform.position += direction * mouseSpeed * Time.deltaTime;
    }
    void Respawn()
    {
        Vector2 newLocation = Random.insideUnitCircle * respawnDistance; //Random direction + set distance
        Vector3 newPos = player.position + new Vector3(newLocation.x, newLocation.y, 0);

        transform.position = newPos; //Reset position
    }




}
