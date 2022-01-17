using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public float m_Speed = 12f;
    public float m_RotationSpeed = 180f;

    [SerializeField]
    private Camera Camera;

    private string m_VerticalAxisName;
    private string m_HorizontalAxisName;
    private Rigidbody m_Rigidbody;
    private float m_VerticalInputValue;
    private float m_HorizontalInputValue;


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_VerticalInputValue = 0f;
        m_HorizontalInputValue = 0f;
    }


    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        m_VerticalAxisName = "Vertical" + m_PlayerNumber;
        m_HorizontalAxisName = "Horizontal" + m_PlayerNumber;
    }


    private void Update()
    {
        // Store the player's input and make sure the audio for the engine is playing.
        m_VerticalInputValue = Input.GetAxis(m_VerticalAxisName);
        m_HorizontalInputValue = Input.GetAxis(m_HorizontalAxisName);

        var targetVector = new Vector3(m_HorizontalInputValue, 0, m_VerticalInputValue);
        var movementVector = MoveTowardTarget(targetVector);
    }

    private void FixedUpdate()
    {
       /* var targetVector = new Vector3(m_HorizontalInputValue, 0, m_VerticalInputValue);
        var movementVector = MoveTowardTarget(targetVector); */

    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = m_Speed * Time.deltaTime;
        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if (movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, m_RotationSpeed);
    }
}