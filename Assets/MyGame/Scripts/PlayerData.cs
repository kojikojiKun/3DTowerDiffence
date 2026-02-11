using UnityEngine;

[CreateAssetMenu(menuName ="Game/Player Data")]
public class PlayerData : ScriptableObject
{
    public int MaxHp;
    public float WalkSpeed;
    public float RunSpeed;
    public int AttackPower;
    public float AttackRate;
}
