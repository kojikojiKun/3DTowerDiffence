using UnityEngine;
using Unity.Cinemachine;

public class CombatCameraMotor : MonoBehaviour
{
    CinemachineBrain m_brain;
    CinemachineInputAxisController m_axisInput;

    private void Awake()
    {
        m_brain = Camera.main.GetComponent<CinemachineBrain>();
        m_axisInput = GetComponent<CinemachineInputAxisController>();
    }

    //ƒJƒƒ‰‚ªØ‚è‘Ö‚¦’†‚È‚çtrue‚ğ•Ô‚·.
    public bool IsBrending()
    {
        return m_brain.IsBlending;
    }

    private void Update()
    {
        m_axisInput.enabled = !IsBrending();
    }
}
