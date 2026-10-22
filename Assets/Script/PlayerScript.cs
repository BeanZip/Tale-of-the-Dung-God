using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float jumpForce = 20f;
    public float speedMultiplier;
    private Rigidbody2D rb;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        if (jumpAction.WasPressedThisFrame())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        speedMultiplier = (sprintAction.IsPressed()) ? 2.3f : 1f;
        
        transform.Translate(new Vector3(move.x * speedMultiplier, 0, move.y) * Time.deltaTime);
    }

    
    
    
}
