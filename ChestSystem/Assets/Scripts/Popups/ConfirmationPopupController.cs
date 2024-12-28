using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationPopupController : MonoBehaviour
{
    private Action onConfirm;
    private Action onCancel;

    [SerializeField] private Button confirmButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private TextMeshProUGUI messageText;
    public void Show(string message, Action onConfirm, Action onCancel)
    {
        this.onConfirm = onConfirm;
        this.onCancel = onCancel;
        this.messageText.text = message;


        this.gameObject.SetActive(true);
        confirmButton.onClick.AddListener(Confirm);
        cancelButton.onClick.AddListener(Cancel);
    }

    public void Hide()
    {
        onConfirm = null;
        onCancel = null;
        this.gameObject.SetActive(false);
    }

    public void Confirm()
    {
        onConfirm?.Invoke();
        Hide();
    }

    public void Cancel()
    {
        onCancel?.Invoke();
        Hide();
    }
}
