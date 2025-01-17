using UnityEngine;
using UnityEngine.UI;

public class AnimatedRareChest : AnimatedChest
{
    [SerializeField] private Image ChestImage;
    [SerializeField] private Sprite LockedSprite;
    [SerializeField] private Sprite UnlockedSprite;
    public override void ShowLocked()
    {
        ChestImage.sprite = LockedSprite;
    }

    public override void ShowUnlocked()
    {
        ChestImage.sprite = UnlockedSprite;
    }

    public override void ShowUnlocking()
    {
        Debug.Log("ShowUnlocking");
    }

    public override void PlayOpenAnimation()
    {
        Debug.Log("PlayOpenAnimation");
    }
}