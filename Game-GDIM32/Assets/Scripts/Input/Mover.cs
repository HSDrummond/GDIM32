using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 3f;

    [SerializeField]
    private int playerIndex = 0;

    private Rigidbody2D controller;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<Rigidbody2D>();
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    void Update()
    {
        moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= MoveSpeed;

        controller.MovePosition(moveDirection * Time.deltaTime);
    }
}