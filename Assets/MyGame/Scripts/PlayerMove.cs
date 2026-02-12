using UnityEngine;
public class PlayerMove
{
    CharacterController m_controller;
    PlayerStatus m_status;
    private float velocity_Y;
    private const float GRAVITY = -9.81f;
    private float m_moveSpeed;

    public PlayerMove(CharacterController controller, PlayerStatus status)
    {
        m_controller = controller;
        m_status = status;
    }

    private void Rotate(Vector3 dir)
    {
        if (dir.sqrMagnitude < 0.01f)
            return;

        Vector3 desiredForward = Vector3.RotateTowards(
            m_controller.transform.forward,
            dir,
            m_status.TurnSpeed * Time.deltaTime,
            0f
        );

        if (desiredForward.sqrMagnitude > 0.01f)
            m_controller.transform.rotation = Quaternion.LookRotation(desiredForward);
    }

    private void FreeFall()
    {
        velocity_Y += GRAVITY * Time.deltaTime;
        m_controller.Move(Vector3.up * velocity_Y * Time.deltaTime);

        if (m_controller.isGrounded && velocity_Y < 0)
            velocity_Y = -2f;
    }

    //入力に応じてカメラの正面を基準にプレイヤーを移動させる.
    public void Move(Vector2 input, Transform cam)
    {
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 dir = forward * input.y + right * input.x;

        if (dir.magnitude > 1)
            dir.Normalize();

        m_controller.Move(dir * m_moveSpeed * Time.deltaTime);
        Rotate(dir);
        FreeFall();
    }

    public void SetRunSpeed()
    {
        m_moveSpeed = m_status.RunSpeed;
    }

    public void SetWalkSpeed()
    {
        m_moveSpeed = m_status.WalkSpeed;
    }

    public void Jump()
    {
        velocity_Y = m_status.JumpSpeed;
    }
}
