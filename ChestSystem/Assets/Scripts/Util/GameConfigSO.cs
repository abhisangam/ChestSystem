
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfigSO", menuName = "GameConfigSO", order = 0)]
public class GameConfigSO : ScriptableObject
{
    public int intialChestSlots = 4;
    public int maxChestSlots = 8;
    
}
