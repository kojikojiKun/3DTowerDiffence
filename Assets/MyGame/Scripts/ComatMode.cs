using UnityEngine;

public class ComatMode : IGameMode
{
    CameraModeController m_camera;

    public ComatMode (CameraModeController camera)
    {
        m_camera = camera;
    }

    public void Enter()
    {

    }

    public void Exit() { }
    public void Update() { }
}
