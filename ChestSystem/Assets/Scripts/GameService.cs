using StatePattern.Utilities;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private PlayerController playerController;
    public PlayerController PlayerController { get { return playerController; } private set { } }

    [SerializeField] private UIService uiService;
    public UIService UIService { get { return  uiService; } private set { } }

    [SerializeField] private GameConfigSO gameConfigSO;
    private GameConfig gameConfig;
    public GameConfig GameConfig { get { return gameConfig; } private set { } }

    private new void Awake()
    {
        base.Awake();
        gameConfig = new GameConfig(gameConfigSO);
    }
}