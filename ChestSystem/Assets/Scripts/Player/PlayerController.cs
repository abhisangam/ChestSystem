using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private int coins;
    private int gems;

    public Action<int> OnCoinsChanged;
    public Action<int> OnGemsChanged;

    private void Awake()
    {
        coins = 100;
        gems = 10;
        OnCoinsChanged?.Invoke(coins);
        OnGemsChanged?.Invoke(gems);
    }

    public int GetCoins()
    {
        return coins;
    }
    public int GetGems()
    {
        return gems;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        OnCoinsChanged?.Invoke(coins);
    }

    public void DeductCoins(int amount)
    {
        coins -= amount;
        OnCoinsChanged?.Invoke(coins);
    }

    public void AddGems(int amount)
    {
        gems += amount;
        OnGemsChanged?.Invoke(gems);
    }

    public void DeductGems(int amount)
    {
        gems -= amount;
        OnGemsChanged?.Invoke(gems);
    }
}