using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public int m_PlayerNumber = 1;

    [SerializeField]
    private float m_PlayerSpeed = 20.0f;

    private CharacterController controller;
    private string m_VerticalAxisName;
    private string m_HorizontalAxisName;
    private float m_VerticalInputValue;
    private float m_HorizontalInputValue;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        m_VerticalAxisName = "Vertical" + m_PlayerNumber;
        m_HorizontalAxisName = "Horizontal" + m_PlayerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        m_VerticalInputValue = Input.GetAxis(m_VerticalAxisName);
        m_HorizontalInputValue = Input.GetAxis(m_HorizontalAxisName);

        Vector3 move = new Vector3(m_VerticalInputValue, 0, m_HorizontalInputValue);
        controller.Move(move * Time.deltaTime * m_PlayerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }    
    }
}
