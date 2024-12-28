using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestRewardPopupController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gemText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Button closeButton;
    public void Show(int coins, int gems)
    {
        gameObject.SetActive(true);
        gemText.text = gems.ToString();
        coinText.text = coins.ToString();

        closeButton.onClick.AddListener(Hide);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}