public class PlayerStatus {
    public int MaxHp;
    public int Hp;
    public float WalkSpeed;
    public float RunSpeed;
    public int AtkPower;
    public float AtkRate;
    public float JumpSpeed = 5f;
    public float TurnSpeed = 10f;

    //ステータスをセット.
    public PlayerStatus(PlayerData data)
    {
        MaxHp = data.MaxHp;
        Hp = data.MaxHp;
        WalkSpeed = data.WalkSpeed;
        RunSpeed = data.RunSpeed;
        AtkPower = data.AttackPower;
        AtkRate = data.AttackRate;
    }
}
