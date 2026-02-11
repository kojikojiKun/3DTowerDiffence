using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent (typeof(CameraModeController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData m_data;
    private PlayerStatus m_status;
    private PlayerCore m_core;
    private PlayerMove m_move;
    private CameraModeController m_modeController;
    private GameModeSystem m_modeSystem;
    private CombatMode m_comatMode;
    private BuildMode m_buildMode;
    private CharacterController m_characterController;

    Vector2 m_moveInput;
    private bool m_isBuildMode;

    private void Awake()
    {
        m_status = new PlayerStatus(m_data);
        m_core = new PlayerCore(m_status);
        m_move = new PlayerMove(m_characterController = GetComponent<CharacterController>(), m_status);
        m_modeController = GetComponent<CameraModeController>();
        m_modeSystem = new GameModeSystem();
        m_comatMode = new CombatMode(m_modeController);
        m_buildMode = new BuildMode(m_modeController);
    }

    private void Start()
    {
        m_modeSystem.ChangeMode(m_comatMode);
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
        if (context.started && m_characterController.isGrounded)
        {
            //プレイヤーをジャンプさせる.
            m_move.Jump();
        }
    }

    public void OnToggleChangeMode(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        m_isBuildMode = !m_isBuildMode;

        //直前のモードと違うモードに切り替え..
        m_modeSystem.ChangeMode(m_isBuildMode ? m_comatMode : m_buildMode);
    }

    private void Update()
    {
        //移動可能状態であればプレイヤーを入力に応じて移動させる.
        if (m_core.CanMove)
            m_move.Move(m_moveInput, Camera.main.transform);
    }
}
