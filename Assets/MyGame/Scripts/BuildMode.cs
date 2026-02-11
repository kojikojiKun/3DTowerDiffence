public class BuildMode : IGameMode
{
    CameraModeController m_camera;

    public BuildMode(CameraModeController camera)
    {
        m_camera = camera;
    }

    //ビルドカメラ有効.
    public void Enter()
    {
        m_camera.SetBuild();
    }
    public void Exit() { }
    public void Update() { }
}
