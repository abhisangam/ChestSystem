using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ChestView : MonoBehaviour
{
    [SerializeField] private Button chestButton;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI gemsToUnlockText;
    [SerializeField] private GameObject unlockPrompt;
    [SerializeField] private GameObject collectPrompt;
    [SerializeField] private GameObject forceUnlockPrompt;

    private AnimatedChest animatedChest;

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

    public void SetAnimatedChest(AnimatedChest animatedChest)
    {
        this.animatedChest = animatedChest;
    }
    public virtual void ShowLocked() {
        animatedChest.ShowLocked();
        ShowUnlockPrompt();
    }
    public virtual void ShowUnlocked() {
        animatedChest.ShowUnlocked();
        ShowCollectPrompt();
        timerText.gameObject.SetActive(false);
    }
    public virtual void ShowOpenAnimation() {
        animatedChest.PlayOpenAnimation();
    }

    public void ShowUnlocking()
    {
        animatedChest.ShowUnlocking();
        ShowForceUnlockPrompt();
    }

    public void SetTimeRemaining(float timeRemaining)
    {
        
        timerText.text = 
            "Time Left:\n" + 
            ((int)(timeRemaining/3600)).ToString() +":" +
            ((int)(timeRemaining / 60) % 60).ToString() + ":" + 
            ((int)timeRemaining % 60).ToString();
    }

    public void SetGemsNeededToUnlock(int gemsToUnlock)
    {
        gemsToUnlockText.text = gemsToUnlock.ToString();
    }

    public void HideTimer()
    {
        timerText.gameObject.SetActive(false);
    }

    public void ShowTimer()
    {
        timerText.gameObject.SetActive(true);
    }

    private void ShowUnlockPrompt()
    {
        unlockPrompt.SetActive(true);
        forceUnlockPrompt.SetActive(false);
        collectPrompt.SetActive(false);
    }

    private void ShowCollectPrompt()
    {
        collectPrompt.SetActive(true);
        unlockPrompt.SetActive(false);
        forceUnlockPrompt.SetActive(false);
    }

    private void ShowForceUnlockPrompt()
    {
        forceUnlockPrompt.SetActive(true);
        unlockPrompt.SetActive(false);
        collectPrompt.SetActive(false);
    }
}