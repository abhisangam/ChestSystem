using StatePattern.Utilities;
using UnityEngine;

public class GameConfig: GenericMonoSingleton<GameConfig>
{
    [SerializeField] private GameConfigSO GameConfigSO;

    public int MaxChestSlots => GameConfigSO.maxChestSlots;
    public int InitialChestSlots => GameConfigSO.intialChestSlots;
}