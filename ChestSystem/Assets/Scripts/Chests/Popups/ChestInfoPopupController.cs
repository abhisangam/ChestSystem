using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum ChestAction
{
    StartUnlocking,
    UnlockNow,
    RevertForceUnlock,
    Collect
}
public class ChestInfoPopupController : MonoBehaviour
{
    [SerializeField] private Button startUnlockingButton;
    [SerializeField] private Button unlockNowButton;
    [SerializeField] private Button revertForceUnlockButton;
    [SerializeField] private Button collectButton;
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private Button closeButton;

    //Content
    [SerializeField] private Image chestIcon;
    [SerializeField] private TextMeshProUGUI chestName;
    [SerializeField] private TextMeshProUGUI timeToUnlock;
    [SerializeField] private TextMeshProUGUI coinRewards;
    [SerializeField] private TextMeshProUGUI gemRewards;

    [SerializeField] ConfirmationPopupController confirmationPopupController;

    private bool isShowing = false;
    private ChestController chestController;

    public Action<ChestAction, int> OnChestAction; //chest action and chest slot id

    public void Show(ChestController chestController, bool isOtherChestOpening)
    {
        if (isShowing) return;
        isShowing = true;

        this.chestController = chestController;
        closeButton.onClick.AddListener(() => Hide());

        HideAllContent();

        gameObject.SetActive(true);

        if (isOtherChestOpening)
        {
            message.text = "Another chest is already opening";
            message.gameObject.SetActive(true);
            return;
        }

        PopulateContent(chestController);

        switch (chestController.GetChestState())
        {
            case ChestStates.Locked:
                startUnlockingButton.gameObject.SetActive(true);
                startUnlockingButton.onClick.AddListener(this.OnStartUnlockingClicked);
                timeToUnlock.gameObject.SetActive(true);
                break;
            case ChestStates.Unlocking:
                unlockNowButton.gameObject.SetActive(true);
                unlockNowButton.onClick.AddListener(OnUnlockNowClicked);
                timeToUnlock.gameObject.SetActive(true);
                chestController.OnChestUnlocked += OnChestUnlocked;
                break;
            case ChestStates.Unlocked:
                collectButton.gameObject.SetActive(true);
                collectButton.onClick.AddListener(OnCollectClicked);
                if(chestController.IsForceOpened)
                {
                    revertForceUnlockButton.gameObject.SetActive(true);
                    revertForceUnlockButton.onClick.AddListener(OnRevertForceUnlockClicked);
                }
                break;
        }
    }

    private void Update()
    {
        if (isShowing)
        {
            float timeRemaining = this.chestController.GetTimeRemaining();
            timeToUnlock.text =
                "Time to unlock: " +
                ((int)(timeRemaining / 3600)).ToString() + ":" +
                ((int)(timeRemaining / 60) % 60).ToString() + ":" +
                ((int)timeRemaining % 60).ToString();
        }
    }

    public void Hide()
    {
        isShowing = false;
        closeButton.onClick.RemoveAllListeners();
        HideAllContent();
        UnsubscribeAllButtonEvents();
        chestController.OnChestUnlocked -= OnChestUnlocked;
        gameObject.SetActive(false);
    }

    private void PopulateContent(ChestController chestController)
    {
        ChestSO chestSO = chestController.ChestSO;
        chestIcon.sprite = chestSO.chestIcon;
        chestName.text = chestSO.name;

        timeToUnlock.text = "Tie to unlock: " + chestController.GetTimeRemaining().ToString();
        coinRewards.text = + chestSO.CoinRewardRangeMin + " - " + chestSO.CoinRewardRangeMax;
        gemRewards.text = chestSO.GemRewardRangeMin + " - " + chestSO.GemRewardRangeMax;
    }

    private void HideAllContent()
    {
        startUnlockingButton.gameObject.SetActive(false);
        unlockNowButton.gameObject.SetActive(false);
        collectButton.gameObject.SetActive(false);
        revertForceUnlockButton.gameObject.SetActive(false);
        message.gameObject.SetActive(false);
        timeToUnlock.gameObject.SetActive(false);
    }

    private void UnsubscribeAllButtonEvents()
    {
        startUnlockingButton.onClick.RemoveAllListeners();
        unlockNowButton.onClick.RemoveAllListeners();
        collectButton.onClick.RemoveAllListeners();
        revertForceUnlockButton.onClick.RemoveAllListeners();
    }

    private void OnStartUnlockingClicked()
    {
        OnChestAction?.Invoke(ChestAction.StartUnlocking, chestController.ChestSlotID);
    }

    private void OnUnlockNowClicked()
    {
        if (GameService.Instance.PlayerController.GetGems() < chestController.GetGemsNeededToOpen())
        {
            GameService.Instance.UIService.WarningPopup.Show("Not enough gems", 1.0f);
        }
        else
        {
            confirmationPopupController.Show(
                "Do you want to unlock now for " + chestController.GetGemsNeededToOpen().ToString() + " gems?",
                () => OnChestAction?.Invoke(ChestAction.UnlockNow, chestController.ChestSlotID),
                () => confirmationPopupController.Hide());
        }
    }

    private void OnRevertForceUnlockClicked()
    {
        OnChestAction?.Invoke(ChestAction.RevertForceUnlock, chestController.ChestSlotID);
    }

    private void OnCollectClicked()
    {
        OnChestAction?.Invoke(ChestAction.Collect, chestController.ChestSlotID);
    }

    private void OnChestUnlocked()
    {
        timeToUnlock.gameObject.SetActive(false);
        unlockNowButton.gameObject.SetActive(false);
        collectButton.gameObject.SetActive(true);
        collectButton.onClick.AddListener(OnCollectClicked);

        confirmationPopupController.Hide();

        chestController.OnChestUnlocked -= OnChestUnlocked;
    }
}