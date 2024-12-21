using UnityEngine;
using UnityEngine.UI;

public enum ChestType
{
    Common,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "Chest", menuName = "Chests/ChestSO", order = 1)]
public class ChestSO: ScriptableObject
{
    public ChestType Type;
    public IAnimatedChest AnimatedChest;
    public float UnlockTime;
    public int CoinRewardRangeMin;
    public int CoinRewardRangeMax;
    public int GemRewardRangeMin;
    public int GemRewardRangeMax;
}