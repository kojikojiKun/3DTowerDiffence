public class PlayerCore : IDamageable
{
    public PlayerStatus Status { get; private set; }

    public PlayerCore(PlayerStatus status)
    {
        //プレイヤーのステータスをセットする.
        Status = status;
    }

    public void TakeDamage(int value)
    {
        //ダメージを受ける.
        Status.Hp -= value;
    }

    //移動可能かを返す.
    public bool CanMove => Status.Hp > 0;

    //死亡状態かどうかを返す.
    public bool IsDead => Status.Hp < 0;
}
