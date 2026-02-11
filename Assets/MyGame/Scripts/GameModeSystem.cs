public class GameModeSystem
{
    IGameMode m_currentMode;

    //ÉÇÅ[Éhêÿë÷.
    public void ChangeMode(IGameMode next)
    {
        m_currentMode?.Exit();
        m_currentMode = next;
        m_currentMode.Enter();
    }

    public void Update()
    {
        m_currentMode?.Update();
    }
}
