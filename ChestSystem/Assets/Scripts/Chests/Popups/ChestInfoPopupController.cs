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

    public Action<ChestAction, int> OnChestAction; //chest action and chest slot id

    public void Show(ChestController chestController, bool isOtherChestOpening)
    {
        closeButton.onClick.AddListener(() => Hide());

        HideAllContent();

        gameObject.SetActive(true);

        if (isOtherChestOpening)
        {
            message.text = "Another chest is already opening";
            message.gameObject.SetActive(true);
            return;
        }

        switch (chestController.GetChestState())
        {
            case ChestStates.Locked:
                startUnlockingButton.gameObject.SetActive(true);
                startUnlockingButton.onClick.AddListener(() => OnChestAction?.Invoke(ChestAction.StartUnlocking, chestController.ChestSlotID));
                break;
            case ChestStates.Unlocking:
                unlockNowButton.gameObject.SetActive(true);
                unlockNowButton.onClick.AddListener(() => OnChestAction?.Invoke(ChestAction.UnlockNow, chestController.ChestSlotID));
                break;
            case ChestStates.Unlocked:
                collectButton.gameObject.SetActive(true);
                collectButton.onClick.AddListener(() => OnChestAction?.Invoke(ChestAction.Collect, chestController.ChestSlotID));
                if(chestController.IsForceOpened)
                {
                    revertForceUnlockButton.gameObject.SetActive(true);
                    revertForceUnlockButton.onClick.AddListener(() => OnChestAction?.Invoke(ChestAction.RevertForceUnlock, chestController.ChestSlotID));
                }
                break;
        }
    }

    public void Hide()
    {
        closeButton.onClick.RemoveAllListeners();
        HideAllContent();
        UnsubscribeAllButtonEvents();
        gameObject.SetActive(false);
    }

    private void HideAllContent()
    {
        startUnlockingButton.gameObject.SetActive(false);
        unlockNowButton.gameObject.SetActive(false);
        collectButton.gameObject.SetActive(false);
        revertForceUnlockButton.gameObject.SetActive(false);
        message.gameObject.SetActive(false);
    }

    private void UnsubscribeAllButtonEvents()
    {
        startUnlockingButton.onClick.RemoveAllListeners();
        unlockNowButton.onClick.RemoveAllListeners();
        collectButton.onClick.RemoveAllListeners();
        revertForceUnlockButton.onClick.RemoveAllListeners();
    }
}