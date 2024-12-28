using UnityEngine;

public class ChestCollectCommand : ChestCommand
{
    int gemsRewarded = 0;
    int coinsRewarded = 0;
    public ChestCollectCommand(ChestController chest) : base(chest) { }

    public override void Execute()
    {
        //Generate random numbers for rewards
        ChestSO chestSO = chest.ChestSO;
        gemsRewarded = Random.Range(chestSO.GemRewardRangeMin, chestSO.GemRewardRangeMax);
        coinsRewarded = Random.Range(chestSO.CoinRewardRangeMin, chestSO.CoinRewardRangeMax);
        GameService.Instance.PlayerController.AddGems(gemsRewarded);
        GameService.Instance.PlayerController.AddCoins(coinsRewarded);
        chest.Collect(coinsRewarded, gemsRewarded);
    }

    public override void Undo()
    {
        //To Do
    }
}