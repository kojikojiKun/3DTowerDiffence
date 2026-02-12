public class PlayerCore : IDamageable
{
    public PlayerStatus Status { get; private set; }

    public PlayerCore(PlayerStatus status)
    {
        Status = status;
    }

    public void TakeDamage(int value)
    {
        Status.Hp -= value;
    }

    //ˆÚ“®‰Â”\‚©‚ð•Ô‚·.
    public bool CanMove => Status.Hp > 0;

    //Ž€–Só‘Ô‚©‚Ç‚¤‚©‚ð•Ô‚·.
    public bool IsDead => Status.Hp < 0;
}
