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

    //戦闘カメラ有効.
    public void SetCombat()
    {
        m_combatCam.Priority = 20;
        m_buildCam.Priority = 10;

        //アクションマップを切り替え.
        m_playerInput.SwitchCurrentActionMap("Player");

        Debug.Log("combat mode");
    }

    //ビルドモードのカメラ有効.
    public void SetBuild()
    {
        m_combatCam.Priority = 10;
        m_buildCam.Priority = 20;

        //アクションマップを切り替え.
        m_playerInput.SwitchCurrentActionMap("BuildMode");

        Debug.Log("build mode");
    }
}
