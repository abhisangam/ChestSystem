using UnityEngine;
using UnityEngine.UI;

public class AnimatedEpicChest : AnimatedChest
{
    [SerializeField] private Image ChestImage;
    [SerializeField] private Sprite LockedSprite;
    [SerializeField] private Sprite UnlockedSprite;
    public override void ShowLocked()
    {
        Debug.Log("ShowLocked");
    }

    public override void ShowUnlocked()
    {
        Debug.Log("ShowUnlocked");
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