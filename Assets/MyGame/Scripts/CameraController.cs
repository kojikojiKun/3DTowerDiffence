using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject m_buildCam;
    [SerializeField] float m_moveSpeed;
    [SerializeField] Vector3 m_moveRange;
    [SerializeField] LayerMask m_groundMask;
    private BuildCamMotor m_motor;
    private Vector2 m_moveInput;
    private Vector2 m_scroll;

    private void Awake()
    {
        m_motor = new BuildCamMotor(m_buildCam, m_moveRange, m_moveSpeed, m_groundMask);
    }

    public void OnMoveCam(InputAction.CallbackContext context)
    {
        m_moveInput = context.ReadValue<Vector2>();
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        m_scroll = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        m_motor.Move(m_moveInput);
        m_motor.Zoom(m_scroll);
    }
}
