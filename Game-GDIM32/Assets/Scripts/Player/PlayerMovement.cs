using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    public int m_PlayerNumber = 0;

    [SerializeField]
    private float moveSpeed = 15f;

    [SerializeField]
    private Rigidbody2D rb;

    private Vector2 movement = Vector2.zero;

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        //Input
        //movement.x = Input.GetAxisRaw("Horizontal");
       // movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //Physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    

}
/*private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        //Input
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //Physics
        Vector3 move = new Vector3(movement.x, movement.y, 0);
        controller.Move(move * Time.deltaTime * moveSpeed);
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
*/