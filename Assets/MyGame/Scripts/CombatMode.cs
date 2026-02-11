public class CombatMode : IGameMode
{
    CameraModeController m_camera;

    public CombatMode (CameraModeController camera)
    {
        m_camera = camera;
    }

    //í“¬ƒJƒƒ‰—LŒø.
    public void Enter()
    {
        m_camera.SetCombat();
    }

    public void Exit() { }
    public void Update() { }
}
