using UnityEngine;

public class BuildMode : IGameMode
{
    CameraModeController m_camera;

    public BuildMode (CameraModeController camera)
    {
        m_camera = camera;
    }

    public void Enter() { }
    public void Exit() { }
    public void Update() { }
}
