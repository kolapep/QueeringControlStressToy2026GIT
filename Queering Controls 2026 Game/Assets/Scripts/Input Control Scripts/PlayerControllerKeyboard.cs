using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerKeyboard : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 moveInput;

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move");
    }

    void Update()
    {
        Vector2 move = moveInput;
        transform.Translate(move * speed * Time.deltaTime);
    }

   
}

