using StatePattern.Utilities;
using UnityEngine;

public class GameConfig
{
    [SerializeField] private GameConfigSO GameConfigSO;

    public GameConfig(GameConfigSO gameConfigSO)
    {
        this.GameConfigSO = gameConfigSO;
    }
    public int MaxChestSlots => GameConfigSO.maxChestSlots;
    public int InitialChestSlots => GameConfigSO.intialChestSlots;
}