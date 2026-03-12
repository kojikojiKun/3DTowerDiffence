public class BuildMode : IGameMode
{
    ModeController m_camera;

    public BuildMode(ModeController camera)
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
