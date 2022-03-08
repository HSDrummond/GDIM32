//PlayerMovement: Duncan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 15f;

    [SerializeField]
    private Rigidbody2D rb;

    public Animator animator;

    private Vector2 movement = Vector2.zero;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>().normalized;

        //Sets Animation
        animator.SetFloat("Horizontal", context.ReadValue<Vector2>().x);
        animator.SetFloat("Vertical", context.ReadValue<Vector2>().y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //Allows Idle to be direction specific 
        if(context.ReadValue<Vector2>().x == 1 || context.ReadValue<Vector2>().x == -1 || 
           context.ReadValue<Vector2>().y == 1 || context.ReadValue<Vector2>().y == -1)
        {
            animator.SetFloat("LastHorizontal", context.ReadValue<Vector2>().x);
            animator.SetFloat("LastVertical", context.ReadValue<Vector2>().y);
        }

    }

    private void FixedUpdate()
    {
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }



}