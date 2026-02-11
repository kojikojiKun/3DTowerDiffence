using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent (typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData m_data;
    PlayerStatus m_status;
    PlayerCore m_core;
    PlayerMove m_move;
    CharacterController m_characterController;

    Vector2 m_moveInput;

    private void Awake()
    {
        m_status = new PlayerStatus(m_data);
        m_core = new PlayerCore(m_status);
        m_move = new PlayerMove(m_characterController = GetComponent<CharacterController>(), m_status);
    }

    private void Start()
    {
        m_move.SetWalkSpeed();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //移動入力受け取り.
        m_moveInput = context.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        //移動速度を切り替える（走る⇔歩く）
        if (context.started)
        {
            m_move.SetRunSpeed();
        }
        else if (context.canceled)
        {
            m_move.SetWalkSpeed();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started && m_characterController.isGrounded)
        {
            //プレイヤーをジャンプさせる.
            m_move.Jump();
        }
    }

    private void Update()
    {
        //移動可能状態であればプレイヤーを入力に応じて移動させる.
        if (m_core.CanMove)
            m_move.Move(m_moveInput,Camera.main.transform);
    }
}
