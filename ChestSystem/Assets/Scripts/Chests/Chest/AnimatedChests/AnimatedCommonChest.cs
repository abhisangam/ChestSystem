using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedCommonChest : AnimatedChest
{
    [SerializeField] private Image ChestImage;
    [SerializeField] private Sprite LockedSprite;
    [SerializeField] private Sprite UnlockedSprite;
    [SerializeField] private GameObject LoadingSprite;

    private bool isUnlocking = false;
    public override void ShowLocked()
    {
        ChestImage.sprite = LockedSprite;
        LoadingSprite.SetActive(false);
        isUnlocking = false;
    }

    public override void ShowUnlocked()
    {
        ChestImage.sprite = UnlockedSprite;
        LoadingSprite.SetActive(false);
        isUnlocking = false;
    }

    public override void ShowUnlocking()
    {
        LoadingSprite.SetActive(true);
        isUnlocking = true;
    }

    public override void PlayOpenAnimation()
    {
        LoadingSprite.SetActive(false);
        isUnlocking = false;
    }

    private void Update()
    {
        if (isUnlocking)
        {
            LoadingSprite.transform.Rotate(0, 0, 1);
        }
    }
}