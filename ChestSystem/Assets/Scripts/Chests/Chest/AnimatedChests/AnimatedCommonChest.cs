using UnityEngine;
using UnityEngine.UI;

public class AnimatedCommonChest : MonoBehaviour, IAnimatedChest
{
    [SerializeField] private Image ChestImage;
    [SerializeField] private Sprite LockedSprite;
    [SerializeField] private Sprite UnlockedSprite;
    public void ShowLocked()
    {
        Debug.Log("ShowLocked");
    }

    public void ShowUnlocked()
    {
        Debug.Log("ShowUnlocked");
    }

    public void ShowUnlocking()
    {
        Debug.Log("ShowUnlocking");
    }

    public void PlayOpenAnimation()
    {
        Debug.Log("PlayOpenAnimation");
    }
}