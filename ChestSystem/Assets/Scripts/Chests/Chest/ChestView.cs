using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ChestView : MonoBehaviour
{
    [SerializeField] private Button chestButton;
    private AnimatedCommonChest animatedChest;
    private TextMeshProUGUI timerText;

    public Action OnChestClicked;
    private ChestController controller;

    public Action OnUpdate;

    private void Awake()
    {
        chestButton.onClick.AddListener(() => OnChestClicked?.Invoke());
    }

    private void Update()
    {
        OnUpdate?.Invoke();
    }

    public void SetController(ChestController controller)
    {
        this.controller = controller;
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

    public void SetTimeRemaining(float timeRemaining)
    {
        
        timerText.text = 
            "Time Left:\n" + 
            ((int)(timeRemaining/3600)).ToString() +":" +
            ((int)(timeRemaining / 60) % 60).ToString() + ":" + 
            ((int)timeRemaining % 60).ToString();
    }
}