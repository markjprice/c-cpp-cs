using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float gravity = -20f;

    private CharacterController controller;
    private Vector3 verticalVelocity;
    private GameManager gameManager;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        if (gameManager is not null && gameManager.IsGameOver)
        {
            return;
        }

        Vector2 input = ReadKeyboardInput();
        Vector3 movement = new(input.x, 0f, input.y);

        if (movement.sqrMagnitude > 1f)
        {
            movement.Normalize();
        }

        controller.Move(movement * moveSpeed * Time.deltaTime);
        ApplyGravity();
    }

    private static Vector2 ReadKeyboardInput()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard is null)
        {
            return Vector2.zero;
        }

        Vector2 input = Vector2.zero;

        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            input.x -= 1f;
        }

        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {
            input.x += 1f;
        }

        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
        {
            input.y -= 1f;
        }

        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
        {
            input.y += 1f;
        }

        return input;
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded && verticalVelocity.y < 0f)
        {
            verticalVelocity.y = -2f;
        }

        verticalVelocity.y += gravity * Time.deltaTime;

        controller.Move(verticalVelocity * Time.deltaTime);
    }
}
