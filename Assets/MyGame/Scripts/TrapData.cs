using UnityEngine;

[CreateAssetMenu(menuName ="Game/Trap Data")]
public class TrapData : ScriptableObject
{
    public int Price;
    public int Hp;
    public int AttackPower;
    public float AttackRate;
}
