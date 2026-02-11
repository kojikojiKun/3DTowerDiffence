using UnityEngine;

public enum PlayerType
{
    Valance,
    Speed,
    Power
}

public class PlayerData : MonoBehaviour
{
    public PlayerType Type;
    public int Hp;
    public float MoveSpeed;
    public float AttackPower;
    
    //çUåÇë¨ìx.
    //public float AttackSpeed;
}
