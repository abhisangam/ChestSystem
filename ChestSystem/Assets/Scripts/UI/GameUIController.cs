using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI gemText;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = GameService.Instance.PlayerController.GetCoins().ToString();
        gemText.text = GameService.Instance.PlayerController.GetGems().ToString();
        GameService.Instance.PlayerController.OnCoinsChanged += OnCoinsChanged;
        GameService.Instance.PlayerController.OnGemsChanged += OnGemsChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCoinsChanged(int currency)
    {
        coinText.text = currency.ToString();
    }

    private void OnGemsChanged(int currency)
    {
        gemText.text = currency.ToString();
    }

    private void OnDestroy()
    {
        GameService.Instance.PlayerController.OnCoinsChanged = OnCoinsChanged;
    }
}
