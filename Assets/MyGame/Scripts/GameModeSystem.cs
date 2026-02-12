public class GameModeSystem
{
    IGameMode m_currentMode;

    //プレイヤーのゲームモード切り替えボタンの入力に応じてゲームモードをトグル式で変更する.
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
