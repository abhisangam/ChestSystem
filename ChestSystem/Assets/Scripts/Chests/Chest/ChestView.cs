using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ChestView : MonoBehaviour
{
    [SerializeField] private Button chestButton;
    private AnimatedCommonChest animatedChest;

    public Action OnChestClicked;

    private void Awake()
    {
        chestButton.onClick.AddListener(() => OnChestClicked?.Invoke());
    }

    public void SetAnimatedChest(AnimatedCommonChest animatedChest)
    {
        this.animatedChest = animatedChest;
    }
    public virtual void ShowLocked() {
        animatedChest.ShowLocked();
    }
    public virtual void ShowUnlocked() {
        animatedChest.ShowUnlocked();
    }
    public virtual void ShowOpenAnimation() {
        animatedChest.PlayOpenAnimation();
    }

    public void StartUnlocking()
    {
        animatedChest.ShowUnlocking();
    }
}