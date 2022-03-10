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

    public AudioSource dirtWalk;

    public AudioSource bridgeWalk;

    private bool onBridge = false;

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


        if (onBridge == false)
        {
            bridgeWalk.Stop();

            if (movement.sqrMagnitude > 0.01)
            {
                dirtWalk.Play();
            }
            if (movement.sqrMagnitude < 0.01)
            {
                dirtWalk.Stop();
            }
        }
        else
        {
            dirtWalk.Stop();

            if (movement.sqrMagnitude > 0.01)
            {
                bridgeWalk.Play();
            }
            if (movement.sqrMagnitude < 0.01)
            {
                bridgeWalk.Stop();
            }
        }


        //Allows Idle to be direction specific 
        if (context.ReadValue<Vector2>().x == 1 || context.ReadValue<Vector2>().x == -1 || 
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Bridge"))
            {
            onBridge = true;
            }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bridge"))
        {
            onBridge = false;
        }
        
    }




}