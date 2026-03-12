using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class ModeController : MonoBehaviour
{
    [SerializeField] CinemachineBrain m_brain;
    [SerializeField] CinemachineCamera m_combatCam;
    [SerializeField] LayerMask m_combatCamMask;
    [SerializeField] LayerMask m_buildCamMask;
    [SerializeField] CinemachineCamera m_buildCam;
    [SerializeField] GameObject m_combatModeUI;
    [SerializeField] GameObject m_buildModeUI;
    Camera m_mainCam;
    private PlayerInput m_playerInput;

    private void Awake()
    {
        m_playerInput = GetComponent<PlayerInput>();
        m_mainCam = Camera.main;
    }

    /*
     * ビルドモード、戦闘モードを切り替え.
     * モードに応じてプレイヤー操作、カメラ操作のAcitionMapを切り替え.
     */
    public void SetCombat()
    {
        m_combatCam.Priority = 20;
        m_buildCam.Priority = 10;

        m_combatModeUI.SetActive(true);
        m_buildModeUI.SetActive(false);

        //CullingMask変更.
        m_mainCam.cullingMask = m_combatCamMask;

        m_playerInput.SwitchCurrentActionMap("Player");
    }

    public void SetBuild()
    {
        m_combatCam.Priority = 10;
        m_buildCam.Priority = 20;

        m_combatModeUI.SetActive(false);
        m_buildModeUI.SetActive(true);

        //CullingMask変更.
        m_mainCam.cullingMask = m_buildCamMask;

        m_playerInput.SwitchCurrentActionMap("BuildMode");
    }
}
