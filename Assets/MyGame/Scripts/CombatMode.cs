public class CombatMode : IGameMode
{
    ModeController m_camera;

    public CombatMode (ModeController camera)
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
