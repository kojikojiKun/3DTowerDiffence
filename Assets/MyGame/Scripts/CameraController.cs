using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject m_buildCam;
    [SerializeField] float m_moveSpeed;
    [SerializeField] Vector3 m_moveRange;
    private BuildCamMotor m_motor;
    private Vector2 m_input;

    private void Awake()
    {
        m_motor = new BuildCamMotor(m_buildCam, m_moveRange, m_moveSpeed);
    }

    public void OnMoveCam(InputAction.CallbackContext context)
    {
        m_input = context.ReadValue<Vector2>();
    }

    public void OnZoom(InputAction.CallbackContext context)
    {

    }

    private void Update()
    {
        m_motor.Move(m_input);
    }
}
