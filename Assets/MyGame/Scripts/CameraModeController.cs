using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class CameraModeController : MonoBehaviour
{
    [SerializeField] CinemachineBrain m_brain;
    [SerializeField] CinemachineCamera m_combatCam;
    [SerializeField] CinemachineCamera m_buildCam;
    private PlayerInput m_playerInput;

    private void Awake()
    {
        m_playerInput = GetComponent<PlayerInput>();
    }

    /*
     * ビルドモード、戦闘モードを切り替え.
     * モードに応じてプレイヤー操作、カメラ操作のAcitionMapを切り替え.
     */
    public void SetCombat()
    {
        m_combatCam.Priority = 20;
        m_buildCam.Priority = 10;

        m_playerInput.SwitchCurrentActionMap("Player");
    }

    public void SetBuild()
    {
        m_combatCam.Priority = 10;
        m_buildCam.Priority = 20;

        m_playerInput.SwitchCurrentActionMap("BuildMode");
    }
}
